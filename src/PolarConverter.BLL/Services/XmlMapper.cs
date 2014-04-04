using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Factories;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class XmlMapper: IFileMapper
    {
        private readonly IStorageHelper _storageHelper;
        private readonly GpxService _gpxService;

        public XmlMapper(Activity_t activity1)
        {
            _storageHelper = new LocalStorageHelper();
            _gpxService = new GpxService();
        }

        public XmlMapper(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _gpxService = new GpxService();
        }

        public byte[] MapData(PolarFile xmlFile, UploadViewModel model)
        {
            var polarExercise = _storageHelper.ReadXmlDocument(xmlFile.Reference, typeof(polarexercisedata)) as polarexercisedata;
            if (polarExercise != null && polarExercise.calendaritems != null)
            {
                foreach (calendaritem calendaritem in polarExercise.calendaritems.Items)
                {
                    var offsetInMinutes = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                    var polarDateTime = calendaritem.time.ToPolarDateTime();
                    var startTime = polarDateTime.HasValue ? polarDateTime.Value.AddMinutes(offsetInMinutes) : DateTime.Now;
                    var activity = ActivityFactory.CreateActivity(xmlFile.Sport, model.Notes, startTime);

                    var type = calendaritem.GetType();
                    switch (type.FullName)
                    {
                        case "exercisedata":
                            {
                                var data = calendaritem as exercisedata;
                                if (data != null && data.result != null)
                                {
                                    var v02max = 0d;
                                    if (data.result.usersettings != null && data.result.usersettings.vo2maxSpecified)
                                    {
                                        v02max = data.result.usersettings.vo2max;
                                    }
                                    if (data.result.laps != null)
                                    {
                                        activity.Lap = CollectLapsData(data.result.laps, startTime, v02max);
                                    }
                                    if (data.result.samples != null)
                                    {
                                        var intervall = data.result.recordingrate == 238
                                            ? 5
                                            : data.result.recordingrate == 0 ? 5 : data.result.recordingrate;
                                        activity.Lap[0].Track = CollectSampleData(data.result.samples, startTime,
                                            intervall);
                                    }
                                }
                                if (xmlFile.GpxFile != null)
                                {
                                    var gpsData = _gpxService.MapGpxFile(xmlFile.GpxFile, model);
                                    // Add gpsData til lap.track...
                                    //lap.Track[j].Position = new Position_t
                                    //{
                                    //    LatitudeDegrees = Convert.ToDouble(gpsData[j].trkseg[i].lat),
                                    //    LongitudeDegrees = Convert.ToDouble(gpsData[j].trkseg[i].lon)
                                    //};                            

                                }
                                var trainingCenter = TrainingCenterFactory.CreateTrainingCenterDatabase(activity);


                                var serializer = new XmlSerializer(typeof(TrainingCenterDatabase_t));

                                using (var memStream = new MemoryStream())
                                {
                                    serializer.Serialize(memStream, trainingCenter);
                                    return memStream.ToArray();
                                }
                                //return _fileService.WriteToMemoryStream(polarData).ToArray();

                                break;
                            }
                        default:
                            {
                                throw new Exception("Invalid XML file");
                            }
                    }
                }
            }
            return null;
        }

        private ActivityLap_t[] CollectLapsData(IEnumerable<lap> laps, DateTime startTime, double v02max)
        {
            var lapList = new List<ActivityLap_t>();
            var lapStartTime = startTime;
            foreach (var lap in laps)
            {
                var lapDuration = lap.duration.ToTimeSpan();
                var activityLap = new ActivityLap_t();
                activityLap.StartTime = lapStartTime;

                if (lap.heartrate != null)
                {
                    if (lap.heartrate.averageSpecified)
                    {
                        activityLap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = System.Convert.ToByte(lap.heartrate.average) };
                    }
                    if (lap.heartrate.maximumSpecified)
                    {
                        activityLap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = System.Convert.ToByte(lap.heartrate.maximum) };
                    }
                    if (v02max > 0 && lap.heartrate.maximumSpecified && lap.heartrate.averageSpecified)
                    {
                        activityLap.Calories = Calculators.CalulateCalories(v02max, lap.heartrate.maximum, lap.heartrate.average, lapDuration.TotalSeconds);
                    }
                }
                if (lap.cadence != null)
                {
                    activityLap.CadenceSpecified = lap.cadence.averageSpecified;
                    if (activityLap.CadenceSpecified)
                    {
                        activityLap.Cadence = System.Convert.ToByte(lap.cadence.average);
                    }
                }
                else
                {
                    activityLap.CadenceSpecified = false;
                }

                activityLap.DistanceMeters = lap.distance;
                // TODO: Extensions
                // TODO: Calculate intensity based on heartrate
                activityLap.Intensity = Intensity_t.Active;

                if (lap.speed != null)
                {
                    activityLap.MaximumSpeedSpecified = lap.speed.maximumSpecified;
                    if (activityLap.MaximumSpeedSpecified)
                    {
                        activityLap.MaximumSpeed = lap.speed.maximum;
                    }
                }
                activityLap.TotalTimeSeconds = lapDuration.TotalSeconds;

                lapList.Add(activityLap);
                lapStartTime = lapStartTime.Add(lapDuration);
            }
            return lapList.ToArray();
        }

        private ActivityLap_t[] CollectLapsData(IEnumerable<Runde> laps, DateTime startTime, double v02max, int interval)
        {
            var lapList = new List<ActivityLap_t>();
            var lapStartTime = startTime;
            foreach (var lap in laps)
            {
                var lapDuration = lap.AntallSekunder;
                var activityLap = new ActivityLap_t();
                activityLap.StartTime = lapStartTime;

                activityLap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = System.Convert.ToByte(lap.SnittHjerteFrekvens) };
                activityLap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = System.Convert.ToByte(lap.MaksHjertefrekvens) };
                if (v02max > 0 && lap.MaksHjertefrekvens > 0 && lap.SnittHjerteFrekvens > 0)
                {
                    activityLap.Calories = Calculators.CalulateCalories(v02max, lap.MaksHjertefrekvens, lap.SnittHjerteFrekvens, lapDuration);
                }
                if (lap.CadenseData != null)
                {
                    activityLap.CadenceSpecified = true;
                    activityLap.Cadence = System.Convert.ToByte(lap.SnittCadense);
                }
                else
                {
                    activityLap.CadenceSpecified = false;
                }

                activityLap.DistanceMeters = lap.AntallMeterData.Last();
                // TODO: Extensions
                // TODO: Calculate intensity based on heartrate
                activityLap.Intensity = Intensity_t.Active;

                if (lap.SpeedData != null)
                {
                    activityLap.MaximumSpeedSpecified = true;
                    activityLap.MaximumSpeed = lap.SpeedData.Max(sd => Double.Parse(sd));
                }
                activityLap.TotalTimeSeconds = lapDuration;

                var tracks = new List<Trackpoint_t>();

                var maximumDataLength = lap.AntallMeterData.Count;
                var trackPoints = new Trackpoint_t[maximumDataLength];
                var meters = 0d;
                for (int i = 0; i < maximumDataLength; i++)
                {
                    trackPoints[i] = new Trackpoint_t { Time = lapStartTime.AddSeconds(i * interval) };
                    if (lap.AltitudeData != null)
                    {
                        trackPoints[i].AltitudeMetersSpecified = true;
                        trackPoints[i].AltitudeMeters = System.Convert.ToDouble(lap.AltitudeData[i]);
                    }
                    else
                    {
                        trackPoints[i].AltitudeMetersSpecified = false;
                    }
                    if (lap.AntallMeterData != null)
                    {
                        trackPoints[i].DistanceMetersSpecified = true;
                        trackPoints[i].DistanceMeters = lap.AntallMeterData[i];
                    }
                    else
                    {
                        trackPoints[i].DistanceMetersSpecified = false;
                    }
                    if (lap.CadenseData != null)
                    {
                        trackPoints[i].CadenceSpecified = true;
                        trackPoints[i].Cadence = System.Convert.ToByte(lap.CadenseData[i]);
                    }
                    else
                    {
                        trackPoints[i].CadenceSpecified = false;
                    }
                    if (lap.HeartRateData != null)
                    {
                        trackPoints[i].HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = lap.HeartRateData[i].HjerteFrekvens };
                    }
                    if (lap.PowerData != null)
                    {
                        trackPoints[i].Extensions = DataHelper.WritePowerData(lap.PowerData[i]);
                    }
                    if (lap.SpeedData != null)
                    {
                        // Distance set by sample Distance
                        if (trackPoints[i].DistanceMetersSpecified)
                            break;
                        meters = meters + (System.Convert.ToDouble(lap.SpeedData[i]) / 0.06d / 60 * interval);
                        trackPoints[i].DistanceMetersSpecified = true;
                        trackPoints[i].DistanceMeters = meters;
                    }
                }
                //foreach (var sampleData in sampleDic)
                //{
                //    switch (sampleData.Key)
                //    {
                //        case sampleType.HEARTRATE:
                //            for (int i = 0; i < sampleData.Value.Length; i++)
                //            {
                //                trackPoints[i].HeartRateBpm = new HeartRateInBeatsPerMinute_t
                //                {
                //                    Value = System.Convert.ToByte
                //                }
                //            }
                //    }
                //}
                activityLap.Track = tracks.ToArray();
                lapList.Add(activityLap);
                lapStartTime = lapStartTime.AddSeconds(lapDuration);
            }
            return lapList.ToArray();
        }

        private Trackpoint_t[] CollectSampleData(IEnumerable<sample> samples, DateTime starTime, int recordingRate)
        {
            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
            var sampleDic = samples.ToDictionary(sample => sample.type, sample => Array.ConvertAll(sample.values.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries), s => float.Parse(s, numberFormatInfo)));

            var maximumDataLength = FindMaximumLength(sampleDic);
            var trackPoints = new Trackpoint_t[maximumDataLength];
            for (int i = 0; i < maximumDataLength; i++)
            {
                trackPoints[i] = new Trackpoint_t { Time = starTime.AddSeconds(i * recordingRate) };
            }
            foreach (var sampleData in sampleDic)
            {
                switch (sampleData.Key)
                {
                    case sampleType.HEARTRATE:
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            trackPoints[i].HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = System.Convert.ToByte(sampleData.Value[i]) };
                        }
                        break;
                    case sampleType.SPEED:
                        var meters = 0f;
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            // Distance set by sample Distance
                            if (trackPoints[i].DistanceMetersSpecified)
                                break;
                            meters = meters + (sampleData.Value[i] / 0.06f / 60 * recordingRate);
                            trackPoints[i].DistanceMetersSpecified = true;
                            trackPoints[i].DistanceMeters = meters;
                        }
                        break;
                    case sampleType.CADENCE:
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            trackPoints[i].CadenceSpecified = true;
                            trackPoints[i].Cadence = System.Convert.ToByte(sampleData.Value[i]);
                        }
                        break;
                    case sampleType.ALTITUDE:
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            trackPoints[i].AltitudeMetersSpecified = true;
                            trackPoints[i].AltitudeMeters = sampleData.Value[i];
                        }
                        break;
                    case sampleType.POWER:
                        var doc = new XmlDocument();
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            var tpxElement = doc.CreateElement("TPX", @"http://www.garmin.com/xmlschemas/ActivityExtension/v2");
                            var wattElement = doc.CreateElement("Watts");
                            wattElement.Value = sampleData.Value[i].ToString();
                            tpxElement.AppendChild(wattElement);
                            trackPoints[i].Extensions = new Extensions_t { Any = new[] { tpxElement } };
                        }
                        break;
                    case sampleType.POWER_PI:
                        break;
                    case sampleType.POWER_LRB:
                        break;
                    case sampleType.AIR_PRESSURE:
                        break;
                    case sampleType.RUN_CADENCE:
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            trackPoints[i].CadenceSpecified = true;
                            trackPoints[i].Cadence = System.Convert.ToByte(sampleData.Value[i]);
                        }
                        break;
                    case sampleType.TEMPERATURE:
                        break;
                    case sampleType.DISTANCE:
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            trackPoints[i].DistanceMetersSpecified = true;
                            trackPoints[i].DistanceMeters = sampleData.Value[i];
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return trackPoints;
        }

        private int FindMaximumLength(Dictionary<sampleType, float[]> sampleDic)
        {
            return sampleDic.Select(keyValue => keyValue.Value.Length).Concat(new[] { 0 }).Max();
        }
    }
}
