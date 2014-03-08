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
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);

            var polarData = new PolarData
            {
                HrmData = hrmData,
                UserInfo = userInfo,
                Sport = hrmFile.Sport,
                Note = "",
                Modus = modus,
                ModusVerdi = modusVerdi,
                HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                HarSpeed = (modus == "SMode" && modusVerdi.Substring(0, 1) == "1") || (modus == "Mode" && modusVerdi.Substring(1, 1) == "1"),
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Device = System.Convert.ToInt32(StringHelper.HentVerdi("Monitor=", 2, hrmData).Trim()),
                Intervall = System.Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            var startTid = System.Convert.ToDateTime(StringHelper.HentVerdi("StartTime=", 10, hrmData));
            startTid = startTid.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneOffset));
            var startDato = StringHelper.HentVerdi("Date=", 8, hrmData).KonverterTilDato();
            polarData.StartTime = new DateTime(startDato.Year, startDato.Month, startDato.Day, startTid.Hour, startTid.Minute, startTid.Second);
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);

            if (hrmFile.GpxFile != null)
            {
                var gpxfil = hrmFile.GpxFile;
                var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                polarData.GpxDataString = KonverteringsHelper.VaskGpxString(_blobStorageHelper.ReadFile(gpxfil.Reference), timeKorreksjon);
                //SlettFil(gpxfil.hrmKey);
            }

            polarData.VaskHrData();
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);
            return _fileService.WriteToMemoryStream(polarData).ToArray();
            //if (model.SendToStrava)
            //{
            //    using (var fs = File.OpenWrite(filSti))
            //    {
            //        fs.Write(memStreamArray, 0, memStreamArray.Length);
            //    }
            //    tcxFilstier.Add(filSti);
            //}
        }

        private byte[] MapXmlFile(PolarFile xmlFile, UploadViewModel model, UserInfo userInfo)
        {
            var trainingCenter = new TrainingCenterDatabase_t();
            var polarExercise = _blobStorageHelper.ReadXmlDocument(xmlFile.Reference);
            if (polarExercise != null && polarExercise.calendaritems != null)
            {
                foreach (calendaritem calendaritem in polarExercise.calendaritems.Items)
                {
                    var offsetInMinutes = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                    var polarDateTime = calendaritem.time.ToPolarDateTime();
                    var startTime = polarDateTime.HasValue ? polarDateTime.Value.AddMinutes(offsetInMinutes) : DateTime.Now;
                    trainingCenter.Author = new Application_t {Name = "PolarConverter.com"};
                    var activity = new Activity_t();
                    activity.Sport = SetSport(xmlFile.Sport);
                    activity.Id = startTime;
                    activity.Notes = model.Notes;

                    var type = calendaritem.GetType();
                    switch (type.FullName)
                    {
                        case "exercisedata":
                            {
                                var data = calendaritem as exercisedata;
                                if (data.result.laps != null)
                                {
                                    activity.Lap = CollectLapsData(data.result.laps, startTime);
                                }
                                if (data.result.samples != null)
                                {
                                    activity.Lap[0].Track = CollectSampleData(data.result.samples);
                                }

                                if (xmlFile.GpxFile != null)
                                {
                                    var gpxfil = xmlFile.GpxFile;
                                    var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                                    var gpxData = _gpxService.ReadGpxFile(gpxfil.Reference, timeKorreksjon);
                                }

                                trainingCenter.Activities = new ActivityList_t { Activity = new[]{ activity }};

                                
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
                    //var res = calendaritem as result;
                    //var startTime =
                    //    System.Convert.ToDateTime(exercise.time);
                    //var offsetInMinutes = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                    //polarData.StartTime = startTime.AddMinutes(offsetInMinutes);
                    //var avgCadence = exercise.("/speed/cadence");
                    //polarData.AvgCadence = avgCadence != null
                    //    ? System.Convert.ToDouble(avgCadence.InnerText)
                    //    : 0d;

                    //var result = exercise.SelectSingleNode("result");
                    //polarData.RecordingRate =
                    //    System.Convert.ToInt32(result.SelectSingleNode("recording-rate").InnerText);
                    //var exerciseDuration = result.SelectSingleNode("duration");
                    //if (exerciseDuration != null)
                    //{
                    //    var durationString = exerciseDuration.InnerText;
                    //    polarData.LapTimes.Add(new TimeSpan(System.Convert.ToInt32(durationString.Substring(0, 2)), System.Convert.ToInt32(durationString.Substring(3, 2)), System.Convert.ToInt32(durationString.Substring(6, 2))));
                    //}
                    //var samples = result.SelectNodes("/samples/sample");
                    //if (samples != null)
                    //{
                    //    foreach (XmlNode sample in samples)
                    //    {
                    //        var type = sample.SelectSingleNode("type").InnerText;
                    //        switch (type)
                    //        {
                    //            case "HEARTRATE":
                    //                {
                    //                    var heartRates = sample.SelectSingleNode("values").InnerText;
                    //                    var heartRateArray = heartRates.Split(new[] { "," },
                    //                        StringSplitOptions.RemoveEmptyEntries);
                    //                    polarData.HeartRate = ConvertToIntArray(heartRateArray);
                    //                    break;
                    //                }
                    //            case "SPEED":
                    //                {
                    //                    var speeds = sample.SelectSingleNode("values").InnerText;
                    //                    var speedArray = speeds.Split(new[] { "," },
                    //                        StringSplitOptions.RemoveEmptyEntries);
                    //                    polarData.Speed = ConvertToDoubleArray(speedArray);
                    //                    break;
                    //                }
                    //            case "ALTITUDE":
                    //                {
                    //                    var altitudes = sample.SelectSingleNode("values").InnerText;
                    //                    var altitudeArray = altitudes.Split(new[] { "," },
                    //                        StringSplitOptions.RemoveEmptyEntries);
                    //                    polarData.Altitude = ConvertToDoubleArray(altitudeArray);
                    //                    break;
                    //                }
                    //        }
                    //    }
                    //}
                    //var lapHolder = result.SelectSingleNode("laps");
                    //if (lapHolder != null)
                    //{
                    //    var laps = lapHolder.SelectNodes("lap");
                    //    double avgAltitude = 0d;
                    //    double avgPower = 0d;
                    //    var numberOfLaps = 0;
                    //    foreach (XmlNode lap in laps)
                    //    {
                    //        var altitude = lap.SelectSingleNode("altitude");
                    //        avgAltitude += altitude != null
                    //            ? System.Convert.ToDouble(altitude.InnerText)
                    //            : 0;
                    //        var power = lap.SelectSingleNode("power");
                    //        avgPower += power != null ? System.Convert.ToDouble(power.InnerText) : 0;
                    //        var duration = lap.SelectSingleNode("duration");
                    //        if (duration != null)
                    //        {
                    //            var lapDurationString = duration.InnerText;
                    //            polarData.LapTimes.Add(new TimeSpan(System.Convert.ToInt32(lapDurationString.Substring(0, 2)), System.Convert.ToInt32(lapDurationString.Substring(3, 2)), System.Convert.ToInt32(lapDurationString.Substring(6, 2))));
                    //        }
                    //        numberOfLaps++;
                    //    }
                    //    if (avgAltitude != 0)
                    //        polarData.AvgAltitude = avgAltitude / numberOfLaps;
                    //    if (avgPower != 0)
                    //        polarData.AvgPower = avgPower / numberOfLaps;

                    //}

                    //if (xmlFile.GpxFile != null)
                    //{
                    //    var gpxfil = xmlFile.GpxFile;
                    //    var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                    //    polarData.GpxDataString = _gpxService.ReadGpxFile(gpxfil.Reference, timeKorreksjon);
                    //}
                    //return _fileService.WriteToMemoryStream(polarData).ToArray();

                }
            }


            //    foreach (var exercise in exercises.Where(ex => ex.Contains("<result>")))
            //    {
            //        var polarData = new PolarData
            //        {
            //            UserInfo = model.UserInfo,
            //            HarCadence = exercise.Contains("<cadence>"),
            //            HarAltitude = exercise.Contains("<altitude>"),
            //            HarSpeed = exercise.Contains("<speed>"),
            //            HarPower = exercise.Contains("<power>"),
            //            XmlTekst = exercise,
            //            RundeTider = KonverteringsHelper.VaskXmlTider(exercise)
            //        };


            //        if (model.GpxFiles.ContainsKey(xmlFil.Key))
            //        {
            //            var gpxfil = model.GpxFiles[xmlFil.Key];
            //            var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneCorrection);
            //            polarData.GpxDataString = KonverteringsHelper.VaskGpxString(gpxfil, timeKorreksjon);
            //            //SlettFil(gpxfil.Filnavn);
            //        }

            //        polarData.VaskXmlHrData(exercise);
            //        polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);
            //        if (polarData.Runder != null)
            //        {
            //            var filSti = StringHelper.Filnavnfikser(xmlFil.Key, string.Format("({0})", i), FilTyper.Tcx);
            //            var memStreamArray = SkrivTilFil(polarData, filSti).ToArray();
            //            if (model.SendToStrava)
            //            {
            //                using (var fs = File.OpenWrite(filSti))
            //                {
            //                    fs.Write(memStreamArray, 0, memStreamArray.Length);
            //                }
            //                tcxFilstier.Add(filSti);
            //            }
            //            if (!zip.ContainsEntry(filSti.Substring(filSti.LastIndexOf('\\'))))
            //                zip.AddEntry(filSti.Substring(filSti.LastIndexOf('\\')), memStreamArray);
            //        }
            //        i++;
            //    }
            //}
            return null;
        }

        private ActivityLap_t[] CollectLapsData(lap[] laps, DateTime startTime)
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

                // TODO: Calculate calories
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

        private Trackpoint_t[] CollectSampleData(IEnumerable<sample> samples)
        {
            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "."};
            var sampleDic = samples.ToDictionary(sample => sample.type, sample => Array.ConvertAll(sample.values.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries), s => float.Parse(s, numberFormatInfo)));

            var maximumDataLength = FindMaximumLength(sampleDic);
            var trackPoints = new Trackpoint_t[maximumDataLength];
            for (int i = 0; i < maximumDataLength; i++)
            {
                trackPoints[i] = new Trackpoint_t();            
            }
            foreach (var sampleData in sampleDic)
            {                
                switch (sampleData.Key)
                {
                    case sampleType.HEARTRATE:
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            trackPoints[i].HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = System.Convert.ToByte(sampleData.Value[i])};
                        }
                        break;
                    case sampleType.SPEED:
                        for (int i = 0; i < sampleData.Value.Length; i++)
                        {
                            // TODO: Calculate distance
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
                            trackPoints[i].Extensions = new Extensions_t {Any = new[] {tpxElement}};
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
