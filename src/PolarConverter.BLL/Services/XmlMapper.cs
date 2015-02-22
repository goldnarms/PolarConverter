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
        private readonly DropboxService _dropboxService;

        public XmlMapper()
        {
            _storageHelper = new BlobStorageHelper("polarfiles");
            _gpxService = new GpxService(_storageHelper);
            _dropboxService = new DropboxService();
        }

        public XmlMapper(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _gpxService = new GpxService(_storageHelper);
            _dropboxService = new DropboxService();
        }

        public byte[] MapData(PolarFile xmlFile, UploadViewModel model)
        {
            polarexercisedata polarExercise;
            if (xmlFile.FromDropbox)
            {
                polarExercise = _dropboxService.ReadXmlDocument(xmlFile.Reference, typeof(polarexercisedata)) as polarexercisedata;
            }
            else
            {
                polarExercise = _storageHelper.ReadXmlDocument(xmlFile.Reference, typeof(polarexercisedata)) as polarexercisedata;
            }
            if (polarExercise != null && polarExercise.calendaritems != null)
            {
                var activites = new List<Activity_t>();
                foreach (calendaritem calendaritem in polarExercise.calendaritems.Items)
                {
                    var polarDateTime = calendaritem.time.ToPolarDateTime();
                    var startTime = polarDateTime.HasValue ? polarDateTime.Value.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneOffset * -1)) : DateTime.Now;
                    var activity = ActivityFactory.CreateActivity(xmlFile.Sport, model.Notes, startTime);

                    var type = calendaritem.GetType();
                    switch (type.Name)
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
                                        var totalLapDuration = activity.Lap.Sum(l => l.TotalTimeSeconds);
                                        var lastIndex = Convert.ToInt32(Math.Floor(totalLapDuration / recordingRate));
                                        var valueData = data.result.samples;
                                        if (valueData != null)
                                        {
                                            var valueLength = valueData.Max(vd => vd.values.Count(c => c == ',')) + 1;
                                            if (IsAbundantRemainingData(valueLength, lastIndex))
                                            {
                                                var lapDuration = (valueLength - lastIndex) * recordingRate;
                                                var laps = activity.Lap.ToList();
                                                laps.Add(GenerateExtraLap(valueData, lapDuration, startTime.AddSeconds(totalLapDuration), v02max, recordingRate, lastIndex));
                                                // use generateLapFromData to fill in values.
                                                activity.Lap = laps.ToArray();
                                            }
                                        }
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
                                if (xmlFile.GpxFile != null && recordingRate > 0)
                                {
                                    var startRange = 0;
                                    var polardata = new PolarData
                                    {
                                        RecordingRate = recordingRate,
                                        StartTime = startTime,
                                        GpxData = _gpxService.MapGpxFile(xmlFile.GpxFile, model.TimeZoneOffset * -1, model.Uid),
                                        UploadViewModel = model
                                    };
                                    foreach (var lap in activity.Lap.Where(l => l != null))
                                    {
                                        var length = Convert.ToInt32(Math.Floor(lap.TotalTimeSeconds / recordingRate));
                                        var gpsData = _gpxService.CollectGpxData(polardata, lap.StartTime, startRange, startRange +                 length);
                                        startRange += lap.Track.Length;
                                        for (int i = 0; i < lap.Track.Length; i++)
                                        {
                                            if (gpsData.Length <= i || gpsData[i] == null) break;
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

        private static bool IsAbundantRemainingData(int valueLength, int startRange)
        {
            return valueLength > startRange + 10;
        }

        private ActivityLap_t GenerateExtraLap(IEnumerable<sample> samples, int lapDurationInSeconds, DateTime starTime, double v02max, int recordingRate, int valuesToskip)
        {
            var timeSpan = new TimeSpan(0, 0, lapDurationInSeconds);
            short zero = 0;
            var lap = new lap
            {
                duration = string.Format("{0}:{1}:{2}.000", timeSpan.Hours.ToString("00"), timeSpan.Minutes.ToString("00"),
                    timeSpan.Seconds.ToString("00"))
            };
            foreach (var sample in samples)
            {
                switch (sample.type)
                {
                    case sampleType.HEARTRATE:
                        {
                            var values = ConvertToValues(sample.values).Skip(valuesToskip);
                            lap.heartrate = new heartraterange
                            {
                                averageSpecified = true,
                                average = values.Count() > 0 ? (short)values.Average() : zero,
                                endingSpecified = true,
                                ending = values.Count() > 0 ? (short)values.Last() : zero,
                                maximumSpecified = true,
                                maximum = values.Count() > 0 ? (short)values.Max() : zero,
                                minimumSpecified = true,
                                minimum = values.Count() > 0 ? (short)values.Min() : zero,
                                restingSpecified = false
                            };
                            break;
                        }
                    case sampleType.SPEED:
                        {
                            var values = ConvertToValues(sample.values).Skip(valuesToskip).ToList();
							if (values.Count > 0)
							{
								lap.speed = new floatrange
								{
									averageSpecified = true,
									average = (float)values.Average(),
									maximumSpecified = true,
									maximum = (float)values.Max(),
									minimumSpecified = true,
									minimum = (float)values.Min()
								};
								if (!samples.Any(s => s.type == sampleType.DISTANCE))
								{
									var meters = values.Sum() / 0.06f / 60 * recordingRate;
									lap.distanceSpecified = true;
									lap.distance = (float)meters;
								}
							}
							else
							{
								lap.speed = new floatrange
								{
									averageSpecified = false,
									maximumSpecified = false,
									minimumSpecified = false
								};
								lap.distanceSpecified = false;
							}
                            break;
                        }
                    case sampleType.CADENCE:
                        {
                            var values = ConvertToValues(sample.values).Skip(valuesToskip);
                            lap.cadence = new shortrange
                            {
                                averageSpecified = true,
                                average = values.Count() > 0 ? (short)values.Average() : zero,
                                maximumSpecified = true,
                                maximum = values.Count() > 0 ? (short)values.Max() : zero,
                                minimumSpecified = true,
                                minimum = values.Count() > 0 ? (short)values.Min() : zero
                            };
                            break;
                        }
                    case sampleType.ALTITUDE:
                        {
                            var values = ConvertToValues(sample.values).Skip(valuesToskip);
                            lap.altitudeSpecified = true;
                            lap.altitude = (float)values.Average();
                            break;
                        }
                    case sampleType.POWER:
                        {
                            var values = ConvertToValues(sample.values).Skip(valuesToskip);
                            lap.power = new power
                            {
                                power1 = new shortrange
                                {
                                    averageSpecified = true,
                                    average = (short)values.Average(),
                                    maximumSpecified = true,
                                    maximum = (short)values.Max(),
                                    minimumSpecified = true,
                                    minimum = (short)values.Min()
                                }
                            };
                            break;
                        }
                    case sampleType.POWER_PI:
                        break;
                    case sampleType.POWER_LRB:
                        break;
                    case sampleType.AIR_PRESSURE:
                        break;
                    case sampleType.RUN_CADENCE:
                        {
                            var values = ConvertToValues(sample.values).Skip(valuesToskip);
                            lap.cadence = new shortrange
                            {
                                averageSpecified = true,
                                average = (short)values.Average(),
                                maximumSpecified = true,
                                maximum = (short)values.Max(),
                                minimumSpecified = true,
                                minimum = (short)values.Min()
                            };
                            break;
                        }
                    case sampleType.TEMPERATURE:
                        break;
                    case sampleType.DISTANCE:
                        {
                            var values = ConvertToValues(sample.values).Skip(valuesToskip);
                            lap.distance = values.Last() - values.First();
                            lap.distanceSpecified = true;
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return GenerateLap(lap, starTime, v02max);
        }

        private static IEnumerable<float> ConvertToValues(string values)
        {
            return values.Split(',').Where(v => !string.IsNullOrEmpty(v)).Select(v => float.Parse(v, CultureInfo.InvariantCulture.NumberFormat));
        }

        private ActivityLap_t[] GenerateLapFromData(result result, DateTime startTime, double v02Max)
        {
            var lap = new ActivityLap_t();
            int interval = result.recordingrateSpecified ? result.recordingrate : 0;
            var lapDuration = result.duration != null ? result.duration.ToTimeSpan() : new TimeSpan(0);
            lap.StartTime = startTime;
            lap.TotalTimeSeconds = lapDuration.TotalSeconds;
            int recordingLength = interval > 0 ? Convert.ToInt32(Math.Floor(lapDuration.TotalSeconds / interval)) : 0;
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
            activityLap.StartTime = lapStartTime.ToUniversalTimeZone();
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

            var maximumDataLength = FindMaximumLength(sampleDic, startRange, endRange);
            var trackPoints = new Trackpoint_t[maximumDataLength];
            for (int i = startRange; i < maximumDataLength + startRange; i++)
            {
                trackPoints[i - startRange] = new Trackpoint_t
                {
                    Time = starTime.AddSeconds(i * recordingRate).ToUniversalTimeZone()
                };
            }
            foreach (var sampleData in sampleDic)
            {
                var indexStart = startRange;
                var indexEnd = sampleData.Value.Length > maximumDataLength + startRange ? maximumDataLength + startRange : sampleData.Value.Length;
                switch (sampleData.Key)
                {
                    case sampleType.HEARTRATE:
                        for (int i = indexStart; i < indexEnd; i++)
                        {
                            trackPoints[i - startRange].HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(sampleData.Value[i]) };
                        }
                        break;
                    case sampleType.SPEED:
                        var meters = 0f;
                        for (int i = indexStart; i < indexEnd; i++)
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
                        for (int i = indexStart; i < indexEnd; i++)
                        {
                            trackPoints[i - startRange].CadenceSpecified = true;
                            trackPoints[i - startRange].Cadence = Convert.ToByte(sampleData.Value[i]);
                        }
                        break;
                    case sampleType.ALTITUDE:
                        for (int i = indexStart; i < indexEnd; i++)
                        {
                            trackPoints[i - startRange].AltitudeMetersSpecified = true;
                            trackPoints[i - startRange].AltitudeMeters = sampleData.Value[i];
                        }
                        break;
                    case sampleType.POWER:
                        var doc = new XmlDocument();
                        for (int i = indexStart; i < indexEnd; i++)
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
                        for (int i = indexStart; i < indexEnd; i++)
                        {
                            trackPoints[i - startRange].CadenceSpecified = true;
                            trackPoints[i - startRange].Cadence = Convert.ToByte(sampleData.Value[i]);
                        }
                        break;
                    case sampleType.TEMPERATURE:
                        break;
                    case sampleType.DISTANCE:
                        for (int i = indexStart; i < indexEnd; i++)
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

        private int FindMaximumLength(Dictionary<sampleType, float[]> sampleDic, int startRange, int endRange)
        {
            var dataMaxLength = sampleDic.Select(keyValue => keyValue.Value.Length).Concat(new[] { 0 }).Max();
            var rangeLength = endRange - startRange;
            return dataMaxLength > rangeLength ? dataMaxLength : rangeLength;
        }
    }
}
