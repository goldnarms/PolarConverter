using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Web.WebSockets;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Ionic.Zip;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;
using Spring.Collections;

namespace PolarConverter.BLL.Services
{
    public class ConversionService
    {
        private FileService _fileService;
        private BlobStorageHelper _blobStorageHelper;
        private GpxService _gpxService;

        public ConversionService()
        {
            _fileService = new FileService();
            _blobStorageHelper = new BlobStorageHelper("polarfiles");
            _gpxService = new GpxService();
        }

        public ConversionResult Convert(UploadViewModel model)
        {
            var readable =
                GetPipedStream(output =>
                {
                    using (var zip = new ZipFile())
                    {
                        zip.FlattenFoldersOnExtract = true;
                        var userInfo = new UserInfo
                        {
                            Weight = model.WeightMode == "kg" ? model.Weight : model.Weight * 0.45359237,
                            TimeZoneOffset = model.TimeZoneOffset,
                            ForceGarmin = model.ForceGarmin
                        };
                        foreach (var hrmFile in model.PolarFiles.Where(pf => pf.FileType == "hrm"))
                        {
                            zip.AddEntry(StringHelper.Filnavnfikser(hrmFile.Name, FilTyper.Tcx), MapHrmData(hrmFile, model, userInfo));
                        }

                        foreach (var xmlFile in model.PolarFiles.Where(pf => pf.FileType == "xml"))
                        {
                            var fileName = StringHelper.Filnavnfikser(xmlFile.Name, FilTyper.Tcx);
                            var stream = MapXmlFile(xmlFile, model, userInfo);
                            zip.AddEntry(fileName, stream);
                        }
                        zip.Save(output);
                        //if (model.SendToStrava)
                        //    EpostHelper.SendTilStrava(model.StravaUsername, tcxFilstier);
                    }
                });

            var fileReference = _blobStorageHelper.SaveStream(readable, "TcxFiles.zip", "application/zip", "zip");
            return new ConversionResult
            {
                ErrorMessages = new List<string>(),
                FileName = "TcxFiles.zip",
                Reference = fileReference
            };
        }

        private byte[] MapHrmData(PolarFile hrmFile, UploadViewModel model, UserInfo userInfo)
        {
            var hrmData = _blobStorageHelper.ReadFile(hrmFile.Reference);

            var startTime = System.Convert.ToDateTime(StringHelper.HentVerdi("StartTime=", 10, hrmData));
            startTime = startTime.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneOffset));

            var trainingCenter = CreateTrainingCenterDatabaseT();
            var activity = CreateActivity(hrmFile.Sport, model.Notes, startTime);
            var laps = KonverteringsHelper.VaskIntTimes(hrmData);

            var v02max = 0d;
            v02max = System.Convert.ToDouble(StringHelper.HentVerdi("VO2max=", 3, hrmData).Trim());

            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusValue = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var trackTimes = KonverteringsHelper.VaskIntTimes(hrmData);
            var interval = System.Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim());

            var polarData = new PolarData
            {
                HrmData = hrmData,
                UserInfo = userInfo,
                Sport = hrmFile.Sport,
                Note = "",
                Modus = modus,
                ModusVerdi = modusValue,
                HarCadence = modus == "SMode" ? (modusValue.Substring(1, 1) == "1") : modusValue.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusValue.Substring(2, 1) == "1") : modusValue.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusValue.Substring(7, 1) == "1") : modusValue.Substring(2, 1) == "1",
                HarSpeed = (modus == "SMode" && modusValue.Substring(0, 1) == "1") || (modus == "Mode" && modusValue.Substring(1, 1) == "1"),
                HarPower = modus == "SMode" && modusValue.Substring(3, 1) == "1",
                Device = System.Convert.ToInt32(StringHelper.HentVerdi("Monitor=", 2, hrmData).Trim()),
                Intervall = System.Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            //polarData.StartTime = startTime;
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(hrmData);

            //if (hrmFile.GpxFile != null)
            //{
            //    var gpxfil = hrmFile.GpxFile;
            //    var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
            //    polarData.GpxDataString = KonverteringsHelper.VaskGpxString(_blobStorageHelper.ReadFile(gpxfil.Reference), timeKorreksjon);
            //    //SlettFil(gpxfil.hrmKey);
            //}

            //polarData.VaskHrData();
            activity = CollectHrmData(polarData, activity);
            //polarData.Runder = KonverteringsHelper.GenererRunder(polarData);
            activity.Lap = CollectLapsData(polarData.Runder, startTime, v02max, polarData.Intervall);
            //var intervall = polarData.Intervall == 238 ? 5 : polarData.Intervall == 0 ? 5 : polarData.Intervall;
            //activity.Lap[0].Track = CreateTrackData(polarData.Runder);

            if (hrmFile.GpxFile != null)
            {
                trainingCenter.Activities = new ActivityList_t
                {
                    Activity = new[] { MapGpxFile(hrmFile.GpxFile, model, activity) }
                };
            }
            else
            {
                trainingCenter.Activities.Activity = new[] { activity };
            }

            var serializer = new XmlSerializer(typeof(TrainingCenterDatabase_t));

            using (var memStream = new MemoryStream())
            {
                serializer.Serialize(memStream, trainingCenter);
                return memStream.ToArray();
            }

            //return _fileService.WriteToMemoryStream(polarData).ToArray();
            //if (model.SendToStrava)
            //{
            //    using (var fs = File.OpenWrite(filSti))
            //    {
            //        fs.Write(memStreamArray, 0, memStreamArray.Length);
            //    }
            //    tcxFilstier.Add(filSti);
            //}
        }

        private Activity_t CollectHrmData(PolarData polarData, Activity_t activity)
        {
            int antallTabs;
            var hrmVerdier = StringHelper.LesLinjer(polarData.HrmData, "[HRData]", out antallTabs, true);

            if (polarData.RundeTider.Count == 1)
            {
                var lap = CollectLapForHrmData(polarData, hrmVerdier, antallTabs);
                activity.Lap = new[] {lap};
            }
            else if (polarData.Versjon == "102")
            {
                activity.Lap = new ActivityLap_t[1];
                //activity.Lap = KonverteringsHelper.CalculateOldIntTimes();
                //runder.AddRange(CalculateOldIntTimes(runde, polarData, startTime, forrigeRundetidISekunder,
                //    antallIntervalPrRunde, antallSekunderPrRunde, forrigeDistanser, startDate));
            }
            else
            {
                activity.Lap = KonverteringsHelper.CalculateIntTimes(polarData, activity.Id, KonverteringsHelper.HentStartDato(polarData));
            }
            return activity;
        }

        private ActivityLap_t CollectLapForHrmData(PolarData polarData, List<string> hrmVerdier, int antallTabs)
        {
            var lap = new ActivityLap_t();
            var maximumDataLength = hrmVerdier.Count;
            lap.Track = new Trackpoint_t[maximumDataLength];
            var meters = 0d;
            for (var i = 0; i < hrmVerdier.Count; i++)
            {
                lap.Track[i] = new Trackpoint_t();
                if (i%antallTabs == 0)
                {
                    lap.Track[i].HeartRateBpm = new HeartRateInBeatsPerMinute_t
                    {
                        Value = KonverteringsHelper.BeregnHjerteFrekvense(polarData.Intervall, hrmVerdier[i])
                    };
                }
                else if (i%antallTabs == 1)
                {
                    if (polarData.HarSpeed)
                    {
                        var speed = hrmVerdier[i].PolarConvertToDouble();
                        if (speed > 1400)
                            speed = i > antallTabs ? hrmVerdier[i - antallTabs].PolarConvertToDouble() : 200;
                        meters += (speed/0.6/60*polarData.Intervall);
                        lap.Track[i].DistanceMeters = meters;
                    }
                    else if (polarData.HarCadence)
                    {
                        lap.Track[i].CadenceSpecified = true;
                        lap.Track[i].Cadence = System.Convert.ToByte(hrmVerdier[i]);
                    }
                    else if (polarData.HarAltitude)
                    {
                        lap.Track[i].AltitudeMetersSpecified = true;
                        lap.Track[i].AltitudeMeters = System.Convert.ToDouble(hrmVerdier[i]);
                    }
                    else if (polarData.HarPower)
                    {
                        lap.Track[i].Extensions = WritePowerData(hrmVerdier[i]);
                    }
                }
                else if (i%antallTabs == 2)
                {
                    if (polarData.HarSpeed && polarData.HarCadence)
                    {
                        lap.Track[i].CadenceSpecified = true;
                        lap.Track[i].Cadence = System.Convert.ToByte(hrmVerdier[i]);
                    }
                    else if (polarData.HarSpeed && polarData.HarAltitude)
                    {
                        lap.Track[i].AltitudeMetersSpecified = true;
                        lap.Track[i].AltitudeMeters = System.Convert.ToDouble(hrmVerdier[i]);
                    }
                    else if (polarData.HarSpeed && polarData.HarPower)
                    {
                        lap.Track[i].Extensions = WritePowerData(hrmVerdier[i]);
                    }
                    else if (polarData.HarCadence && polarData.HarAltitude)
                    {
                        lap.Track[i].AltitudeMetersSpecified = true;
                        lap.Track[i].AltitudeMeters = System.Convert.ToDouble(hrmVerdier[i]);
                    }
                    else if (polarData.HarCadence && polarData.HarPower)
                    {
                        lap.Track[i].Extensions = WritePowerData(hrmVerdier[i]);
                    }
                    else if (polarData.HarAltitude && polarData.HarPower)
                    {
                        lap.Track[i].Extensions = WritePowerData(hrmVerdier[i]);
                    }
                }
                else if (i%antallTabs == 3)
                {
                    if (polarData.HarSpeed && polarData.HarCadence && polarData.HarAltitude)
                    {
                        lap.Track[i].AltitudeMetersSpecified = true;
                        lap.Track[i].AltitudeMeters = System.Convert.ToDouble(hrmVerdier[i]);
                    }
                    else if (polarData.HarSpeed && polarData.HarCadence && polarData.HarPower)
                    {
                        lap.Track[i].Extensions = WritePowerData(hrmVerdier[i]);
                    }
                }
                else if (i%antallTabs == 4)
                {
                    if (polarData.HarSpeed && polarData.HarCadence && polarData.HarAltitude && polarData.HarPower)
                    {
                        lap.Track[i].Extensions = WritePowerData(hrmVerdier[i]);
                    }
                }
            }
            return lap;
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
                        trackPoints[i].Extensions = WritePowerData(lap.PowerData[i]);
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

        private Extensions_t WritePowerData(string powerValue)
        {
            var doc = new XmlDocument();
            var tpxElement = doc.CreateElement("TPX", @"http://www.garmin.com/xmlschemas/ActivityExtension/v2");
            var wattElement = doc.CreateElement("Watts");
            wattElement.Value = powerValue;
            tpxElement.AppendChild(wattElement);
            return new Extensions_t { Any = new[] { tpxElement } };
        }

        private byte[] MapXmlFile(PolarFile xmlFile, UploadViewModel model, UserInfo userInfo)
        {
            var trainingCenter = CreateTrainingCenterDatabaseT();
            var polarExercise = _blobStorageHelper.ReadXmlDocument(xmlFile.Reference, typeof(polarexercisedata)) as polarexercisedata;
            if (polarExercise != null && polarExercise.calendaritems != null)
            {
                foreach (calendaritem calendaritem in polarExercise.calendaritems.Items)
                {
                    var offsetInMinutes = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                    var polarDateTime = calendaritem.time.ToPolarDateTime();
                    var startTime = polarDateTime.HasValue ? polarDateTime.Value.AddMinutes(offsetInMinutes) : DateTime.Now;
                    var activity = CreateActivity(xmlFile.Sport, model.Notes, startTime);

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
                                    trainingCenter.Activities = new ActivityList_t
                                    {
                                        Activity = new[] { MapGpxFile(xmlFile.GpxFile, model, activity) }
                                    };
                                }

                                trainingCenter.Activities.Activity = new[] { activity };


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

        private Activity_t MapGpxFile(GpxFile gpxFile, UploadViewModel model, Activity_t activity)
        {
            var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
            var gpxData = _gpxService.ReadGpxFile(gpxFile.Reference, timeKorreksjon);
            var maxLength = activity.Lap[0].Track.Length;
            if (gpxData.trk[0].trkseg.Length < maxLength)
                maxLength = gpxData.trk[0].trkseg.Length;
            for (int i = 0; i < maxLength; i++)
            {
                activity.Lap[0].Track[i].Position = new Position_t
                {
                    LatitudeDegrees = System.Convert.ToDouble(gpxData.trk[0].trkseg[i].lat),
                    LongitudeDegrees = System.Convert.ToDouble(gpxData.trk[0].trkseg[i].lon)
                };
            }
            return activity;
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

        private TrainingCenterDatabase_t CreateTrainingCenterDatabaseT()
        {
            return new TrainingCenterDatabase_t { Author = new Application_t { Name = "www.polarconverter.com" }, Activities = new ActivityList_t() };
        }

        private Activity_t CreateActivity(string sport, string notes, DateTime starTime)
        {
            return new Activity_t { Id = starTime, Sport = SetSport(sport), Notes = notes };
        }

        private static Sport_t SetSport(string sport)
        {
            switch (sport)
            {
                case "Biking":
                    return Sport_t.Biking;
                case "Other":
                    return Sport_t.Other;
                case "Running":
                    return Sport_t.Running;
                default:
                    return Sport_t.Other;
            }
        }

        private double[] ConvertToDoubleArray(string[] array)
        {
            var tmpArray = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                tmpArray[i] =
                    System.Convert.ToDouble(array[i]);
            }
            return tmpArray;
        }

        private int[] ConvertToIntArray(string[] array)
        {
            var tmpArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                tmpArray[i] =
                    System.Convert.ToInt32(array[i]);
            }
            return tmpArray;
        }

        static Stream GetPipedStream(Action<Stream> writeAction)
        {
            var pipeServer = new AnonymousPipeServerStream();
            ThreadPool.QueueUserWorkItem(s =>
            {
                using (pipeServer)
                {
                    writeAction(pipeServer);
                    pipeServer.WaitForPipeDrain();
                }
            });
            return new AnonymousPipeClientStream(pipeServer.GetClientHandleAsString());
        }
    }
}
