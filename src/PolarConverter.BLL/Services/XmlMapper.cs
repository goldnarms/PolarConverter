using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Factories;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class XmlMapper : IFileMapper
    {
        private readonly IStorageHelper _storageHelper;
        private readonly GpxService _gpxService;

        public XmlMapper()
        {
            _storageHelper = new BlobStorageHelper("polarfiles");
            _gpxService = new GpxService(_storageHelper);
        }

        public XmlMapper(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _gpxService = new GpxService(_storageHelper);
        }

        public byte[] MapData(PolarFile xmlFile, UploadViewModel model)
        {
            var polarExercise = _storageHelper.ReadXmlDocument(xmlFile.Reference, typeof(polarexercisedata)) as polarexercisedata;
            if (polarExercise != null && polarExercise.calendaritems != null)
            {
                var activites = new List<Activity_t>();
                foreach (calendaritem calendaritem in polarExercise.calendaritems.Items)
                {
                    var polarDateTime = calendaritem.time.ToPolarDateTime();
                    var startTime = polarDateTime.HasValue ? polarDateTime.Value.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneOffset)) : DateTime.Now;
                    var activity = ActivityFactory.CreateActivity(xmlFile.Sport, model.Notes, startTime);

                    var type = calendaritem.GetType();
                    switch (type.FullName)
                    {
                        case "exercisedata":
                            {
                                var data = calendaritem as exercisedata;
                                var recordingRate = data != null && data.result != null &&
                                                    data.result.recordingrateSpecified
                                    ? data.result.recordingrate
                                    : 1;
                                if (data != null && data.result != null)
                                {
                                    var v02max = 0d;
                                    if (data.result.usersettings != null && data.result.usersettings.vo2maxSpecified)
                                    {
                                        v02max = data.result.usersettings.vo2max;
                                        if (data.result.usersettings.weightSpecified)
                                        {
                                            v02max = v02max * data.result.usersettings.weight;
                                        }
                                        else
                                        {
                                            v02max = v02max * 80;
                                        }
                                    }
                                    if (data.result.laps != null)
                                    {
                                        activity.Lap = CollectLapsData(data.result.laps, startTime, v02max);
                                    }
                                    else if (data.result.autolaps != null)
                                    {
                                        activity.Lap = CollectLapsData(data.result.autolaps, startTime, v02max);
                                    }
                                    else
                                    {
                                        activity.Lap = GenerateLapFromData(data.result, startTime, v02max);
                                    }
                                    if (data.result.samples != null)
                                    {
                                        var startRange = 0;
                                        foreach (var lap in activity.Lap)
                                        {
                                            lap.Track = CollectSampleData(data.result.samples, startTime,
                                                recordingRate, startRange, startRange + Convert.ToInt32(Math.Floor(lap.TotalTimeSeconds / recordingRate)));
                                            startRange += lap.Track.Length;
                                        }
                                    }
                                    else if (data.sportresults != null)
                                    {
                                        var startRange = 0;
                                        foreach (var sportResult in data.sportresults)
                                        {
                                            if (sportResult.samples != null)
                                            {
                                                foreach (var lap in activity.Lap)
                                                {
                                                    lap.Track = CollectSampleData(sportResult.samples, startTime,
                                                        recordingRate, startRange, startRange + Convert.ToInt32(Math.Floor(lap.TotalTimeSeconds / recordingRate)));
                                                    startRange += lap.Track.Length;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xmlFile.GpxFile != null)
                                {
                                    var startRange = 0;
                                    foreach (var lap in activity.Lap)
                                    {
                                        var polardata = new PolarData
                                        {
                                            RecordingRate = recordingRate,
                                            StartTime = startTime,
                                            GpxData = _gpxService.MapGpxFile(xmlFile.GpxFile, model),
                                            UploadViewModel = model
                                        };
                                        var gpsData =
                                            _gpxService.CollectGpxData(polardata,
                                                startRange, startRange + Convert.ToInt32(Math.Floor(lap.TotalTimeSeconds / recordingRate)));

                                        if (lap.Track == null)
                                        {
                                            continue;
                                        }
                                        startRange += lap.Track.Length;
                                        if (gpsData != null)
                                        {
                                            for (int i = 0; i < lap.Track.Length; i++)
                                            {
                                                if (gpsData.Length > i && gpsData[i] != null)
                                                {
                                                    lap.Track[i].Position = new Position_t
                                                    {
                                                        LatitudeDegrees = Convert.ToDouble(gpsData[i].Lat),
                                                        LongitudeDegrees = Convert.ToDouble(gpsData[i].Lon)
                                                    };
                                                    if (gpsData[i].Altitude.HasValue)
                                                    {
                                                        lap.Track[i].AltitudeMetersSpecified = true;
                                                        lap.Track[i].AltitudeMeters = Convert.ToDouble(gpsData[i].Altitude.Value);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                activites.Add(activity);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                var trainingCenter = TrainingCenterFactory.CreateTrainingCenterDatabase(activites.ToArray());
                var serializer = new XmlSerializer(typeof(TrainingCenterDatabase_t));

                using (var memStream = new MemoryStream())
                {
                    serializer.Serialize(memStream, trainingCenter);
                    return memStream.ToArray();
                }
            }
            return null;
        }

        private ActivityLap_t[] GenerateLapFromData(result result, DateTime startTime, double v02Max)
        {
            var lap = new ActivityLap_t();
            int recordingLength = 0;
            int interval = result.recordingrateSpecified && result.recordingrate > 0 ? result.recordingrate : 5;
            var lapDuration = result.duration.ToTimeSpan();
            lap.StartTime = startTime;
            lap.TotalTimeSeconds = lapDuration.TotalSeconds;
            recordingLength = Convert.ToInt32(Math.Floor(lapDuration.TotalSeconds / interval));
            lap.Track = new Trackpoint_t[recordingLength];
            for (int i = 0; i < lap.Track.Length; i++)
            {
                lap.Track[i] = new Trackpoint_t { Time = startTime.AddSeconds(i * interval) };
            }
            if (result.heartrate != null)
            {
                if (result.heartrate.averageSpecified)
                {
                    lap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t
                    {
                        Value = Convert.ToByte(result.heartrate.average)
                    };
                    for (int i = 0; i < lap.Track.Length; i++)
                    {
                        lap.Track[i].HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(result.heartrate.average) };
                    }
                }
                if (result.heartrate.maximumSpecified)
                {
                    lap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t
                    {
                        Value = Convert.ToByte(result.heartrate.maximum)
                    };
                }
            }
            if (result.distanceSpecified)
            {
                lap.DistanceMeters = result.distance;
                for (int i = 0; i < lap.Track.Length; i++)
                {
                    lap.Track[i].DistanceMetersSpecified = true;
                    lap.Track[i].DistanceMeters = result.distance / lap.Track.Length * i;
                }

            }
            if (result.altitude != null)
            {
                for (int i = 0; i < lap.Track.Length; i++)
                {
                    lap.Track[i].AltitudeMetersSpecified = true;
                    if (result.altitude.averageSpecified)
                    {
                        lap.Track[i].AltitudeMeters = result.altitude.average;
                    }
                }
            }
            if (result.speed != null)
            {
                if (result.speed.speed1 != null)
                {
                    if (result.speed.speed1.maximumSpecified)
                    {
                        lap.MaximumSpeedSpecified = result.speed.speed1.maximumSpecified;
                        var maximumSpeedKph = result.speed.speed1.maximum;
                        lap.MaximumSpeed = maximumSpeedKph * 1000 / 60 / 60;
                    }
                    else
                    {
                        lap.MaximumSpeedSpecified = false;
                    }
                    if (result.speed.cadence != null)
                    {
                        if (result.speed.cadence.averageSpecified)
                        {
                            lap.CadenceSpecified = true;
                            for (int i = 0; i < lap.Track.Length; i++)
                            {
                                lap.Track[i].CadenceSpecified = true;
                                lap.Track[i].Cadence = Convert.ToByte(result.speed.cadence.average);
                            }
                        }
                        else
                        {
                            lap.CadenceSpecified = false;
                        }
                    }
                }
            }
            ushort cal = 0;
            if (result.calories != null && ushort.TryParse(result.calories, out cal))
            {
                lap.Calories = cal;
            }
            else if (result.heartrate != null && result.heartrate.averageSpecified && result.heartrate.maximumSpecified)
            {
                lap.Calories = Calculators.CalulateCalories(v02Max, result.heartrate.maximum, result.heartrate.average, lapDuration.TotalSeconds);
            }
            return new[] { lap };
        }

        private ActivityLap_t[] CollectLapsData(IEnumerable<lap> laps, DateTime startTime, double v02max)
        {
            var lapList = new List<ActivityLap_t>();
            var lapStartTime = startTime;
            foreach (var lap in laps)
            {
                lapList.Add(GenerateLap(lap, lapStartTime, v02max));
                lapStartTime = lapStartTime.Add(lap.duration.ToTimeSpan());
            }
            return lapList.ToArray();
        }

        private ActivityLap_t GenerateLap(lap lap, DateTime lapStartTime, double v02max)
        {
            var lapDuration = lap.duration.ToTimeSpan();
            var activityLap = new ActivityLap_t();
            activityLap.StartTime = lapStartTime.ToUniversalTime();
            if (lap.heartrate != null)
            {
                if (lap.heartrate.averageSpecified)
                {
                    activityLap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(lap.heartrate.average) };
                }
                if (lap.heartrate.maximumSpecified)
                {
                    activityLap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(lap.heartrate.maximum) };
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
                    activityLap.Cadence = Convert.ToByte(lap.cadence.average);
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
            return activityLap;
        }

        private Trackpoint_t[] CollectSampleData(IEnumerable<sample> samples, DateTime starTime, int recordingRate, int startRange, int endRange)
        {
            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
            var sampleDic = samples.ToDictionary(sample => sample.type, sample => Array.ConvertAll(sample.values.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries), s => float.Parse(s, numberFormatInfo)));

            var maximumDataLength = FindMaximumLength(sampleDic);
            if (endRange > maximumDataLength)
            {
                endRange = maximumDataLength;
            }
            var trackPoints = new Trackpoint_t[endRange - startRange];
            for (int i = startRange; i < endRange; i++)
            {
                trackPoints[i - startRange] = new Trackpoint_t
                {
                    Time = starTime.AddSeconds(i * recordingRate).ToUniversalTime()
                };
            }
            foreach (var sampleData in sampleDic)
            {
                switch (sampleData.Key)
                {
                    case sampleType.HEARTRATE:
                        for (int i = startRange; i < endRange; i++)
                        {
                            trackPoints[i - startRange].HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(sampleData.Value[i]) };
                        }
                        break;
                    case sampleType.SPEED:
                        var meters = 0f;
                        for (int i = startRange; i < endRange; i++)
                        {
                            // Distance set by sample Distance
                            if (trackPoints[i - startRange].DistanceMetersSpecified)
                                break;
                            meters = meters + (sampleData.Value[i] / 0.06f / 60 * recordingRate);
                            trackPoints[i - startRange].DistanceMetersSpecified = true;
                            trackPoints[i - startRange].DistanceMeters = meters;
                        }
                        break;
                    case sampleType.CADENCE:
                        for (int i = startRange; i < endRange; i++)
                        {
                            trackPoints[i - startRange].CadenceSpecified = true;
                            trackPoints[i - startRange].Cadence = Convert.ToByte(sampleData.Value[i]);
                        }
                        break;
                    case sampleType.ALTITUDE:
                        for (int i = startRange; i < endRange; i++)
                        {
                            trackPoints[i - startRange].AltitudeMetersSpecified = true;
                            trackPoints[i - startRange].AltitudeMeters = sampleData.Value[i];
                        }
                        break;
                    case sampleType.POWER:
                        var doc = new XmlDocument();
                        for (int i = startRange; i < sampleData.Value.Length; i++)
                        {
                            var tpxElement = doc.CreateElement("TPX", @"http://www.garmin.com/xmlschemas/ActivityExtension/v2");
                            var wattElement = doc.CreateElement("Watts");
                            wattElement.Value = sampleData.Value[i].ToString();
                            tpxElement.AppendChild(wattElement);
                            trackPoints[i - startRange].Extensions = new Extensions_t { Any = new[] { tpxElement } };
                        }
                        break;
                    case sampleType.POWER_PI:
                        break;
                    case sampleType.POWER_LRB:
                        break;
                    case sampleType.AIR_PRESSURE:
                        break;
                    case sampleType.RUN_CADENCE:
                        for (int i = startRange; i < endRange; i++)
                        {
                            trackPoints[i - startRange].CadenceSpecified = true;
                            trackPoints[i - startRange].Cadence = Convert.ToByte(sampleData.Value[i]);
                        }
                        break;
                    case sampleType.TEMPERATURE:
                        break;
                    case sampleType.DISTANCE:
                        for (int i = startRange; i < endRange; i++)
                        {
                            trackPoints[i - startRange].DistanceMetersSpecified = true;
                            trackPoints[i - startRange].DistanceMeters = sampleData.Value[i];
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
