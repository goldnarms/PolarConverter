using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
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
                            Weight = model.WeightMode == "kg" ? model.Weight : model.Weight * Config.ConfigVariables.Lbsfactor,
                            TimeZoneOffset = model.TimeZoneOffset,
                            ForceGarmin = model.ForceGarmin
                        };
                        foreach (var hrmFile in model.PolarFiles.Where(pf => pf.FileType == "hrm"))
                        {
                            var hrmFileData = MapHrmData(hrmFile, model, userInfo);
                            zip.AddEntry(StringHelper.Filnavnfikser(hrmFile.Name, FilTyper.Tcx), hrmFileData);
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
            var polarData = InitalizePolarData(hrmFile, model, userInfo, hrmData);
            var activity = CreateActivity(hrmFile.Sport, model.Notes != "" ? model.Notes : polarData.Note, startTime);

            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(hrmData);
            VaskHrData(ref polarData);
            CollectHrmData(ref activity, polarData);

            //polarData.Runder = KonverteringsHelper.GenererRunder(polarData);
            //activity.Lap = CollectLapsData(polarData.Runder, startTime, v02max, polarData.Intervall);
            trainingCenter.Activities = new ActivityList_t { Activity = new[] { activity } };
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

        private PolarData InitalizePolarData(PolarFile file, UploadViewModel model, UserInfo userInfo, string hrmData)
        {
            var v02max = 0d;
            double.TryParse(StringHelper.HentVerdi("VO2max=", 3, hrmData).Trim(), out v02max);
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusValue = StringHelper.HentVerdi("Mode=", 9, hrmData);
            //var trackTimes = KonverteringsHelper.VaskIntTimes(hrmData);
            var interval = System.Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim());
            var tabs = 0;
            var noteData = StringHelper.LesLinjer(hrmData, "[Note]", out tabs);
            var noteText = new StringBuilder();
            foreach (var notes in noteData)
            {
                noteText.AppendLine(notes);
            }
            return new PolarData
            {
                HrmData = hrmData,
                UserInfo = userInfo,
                Sport = file.Sport,
                Note = noteText.ToString(),
                Modus = modus,
                ModusVerdi = modusValue,
                HarCadence = modus == "SMode" ? (modusValue.Substring(1, 1) == "1") : modusValue.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusValue.Substring(2, 1) == "1") : modusValue.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusValue.Substring(7, 1) == "1") : modusValue.Substring(2, 1) == "1",
                HarSpeed = (modus == "SMode" && modusValue.Substring(0, 1) == "1") || (modus == "Mode" && modusValue.Substring(1, 1) == "1"),
                HarPower = modus == "SMode" && modusValue.Substring(3, 1) == "1",
                Device = System.Convert.ToInt32(StringHelper.HentVerdi("Monitor=", 2, hrmData).Trim()),
                Intervall = interval,
                HrData = new List<HRData>(),
                AltitudeData = new List<string>(),
                PowerData = new List<string>(),
                CadenseData = new List<string>(),
                SpeedData = new List<string>(),
                AntallMeter = new List<double>(),
                GpxData = file.GpxFile != null ? MapGpxFile(file.GpxFile, model) : null
            };
        }

        public void VaskHrData(ref PolarData data)
        {
            int antallTabs;
            var hrmVerdier = StringHelper.LesLinjer(data.HrmData, "[HRData]", out antallTabs, true);
            for (var i = 0; i < hrmVerdier.Count; i++)
            {
                if (i % antallTabs == 0)
                {
                    data.HrData.Add(new HRData { HjerteFrekvens = KonverteringsHelper.BeregnHjerteFrekvense(data.Intervall, hrmVerdier[i]) });
                }
                else if (i % antallTabs == 1)
                {
                    if (data.HarSpeed)
                    {
                        var speed = hrmVerdier[i].PolarConvertToDouble();
                        if (speed > 1400)
                            speed = i > antallTabs ? hrmVerdier[i - antallTabs].PolarConvertToDouble() : 200;
                        data.AntallMeter.Add(data.AntallMeter.Count > 0 ? data.AntallMeter.Last() + (speed / 0.6 / 60 * data.Intervall) : (speed / 0.6 / 60 * data.Intervall));
                    }
                    else if (data.HarCadence)
                        data.CadenseData.Add(hrmVerdier[i]);
                    else if (data.HarAltitude)
                        data.AltitudeData.Add(hrmVerdier[i]);
                    else if (data.HarPower)
                        data.PowerData.Add(hrmVerdier[i]);
                }
                else if (i % antallTabs == 2)
                {
                    if (data.HarSpeed && data.HarCadence)
                        data.CadenseData.Add(hrmVerdier[i]);
                    else if (data.HarSpeed && data.HarAltitude)
                        data.AltitudeData.Add(hrmVerdier[i]);
                    else if (data.HarSpeed && data.HarPower)
                        data.PowerData.Add(hrmVerdier[i]);
                    else if (data.HarCadence && data.HarAltitude)
                        data.AltitudeData.Add(hrmVerdier[i]);
                    else if (data.HarCadence && data.HarPower)
                        data.PowerData.Add(hrmVerdier[i]);
                    else if (data.HarAltitude && data.HarPower)
                        data.PowerData.Add(hrmVerdier[i]);
                }
                else if (i % antallTabs == 3)
                {
                    if (data.HarSpeed && data.HarCadence && data.HarAltitude)
                        data.AltitudeData.Add(hrmVerdier[i]);
                    else if (data.HarSpeed && data.HarCadence && data.HarPower)
                        data.PowerData.Add(hrmVerdier[i]);
                }
                else if (i % antallTabs == 4)
                {
                    if (data.HarSpeed && data.HarCadence && data.HarAltitude && data.HarPower)
                        data.PowerData.Add(hrmVerdier[i]);
                }
            }
        }

        private void CollectHrmData(ref Activity_t activity, PolarData polarData)
        {
            int antallTabs;
            var hrmVerdier = StringHelper.LesLinjer(polarData.HrmData, "[HRData]", out antallTabs, true);

            if (polarData.RundeTider.Count == 1)
            {
                var lap = CollectLapForHrmData(polarData, hrmVerdier, antallTabs);
                activity.Lap = new[] { lap };
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
        }

        private ActivityLap_t CollectLapForHrmData(PolarData polarData, List<string> hrmVerdier, int antallTabs)
        {
            var lap = new ActivityLap_t();
            var maximumDataLength = hrmVerdier.Count;
            lap.Track = new Trackpoint_t[maximumDataLength];
            var meters = 0d;
            var lapIndex = 0;
            for (var i = 0; i < hrmVerdier.Count; i = i + antallTabs)
            {
                var lapTrackPoint = new Trackpoint_t();
                lapTrackPoint.Time = polarData.StartTime.AddSeconds(lapIndex*polarData.Intervall);
                lapTrackPoint.HeartRateBpm = new HeartRateInBeatsPerMinute_t
                {
                    Value = KonverteringsHelper.BeregnHjerteFrekvense(polarData.Intervall, hrmVerdier[i])
                };
                if (antallTabs > 4)
                {
                    if (polarData.HarSpeed && polarData.HarCadence && polarData.HarAltitude && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = WritePowerData(hrmVerdier[i + 4]);
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 3]);
                        AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1], polarData.Intervall, meters);
                    }
                }
                else if (antallTabs > 3)
                {
                    if (polarData.HarSpeed && polarData.HarCadence && polarData.HarAltitude)
                    {
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 3]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1], polarData.Intervall, meters);
                    }
                    else if (polarData.HarSpeed && polarData.HarCadence && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = WritePowerData(hrmVerdier[i + 3]);
                        AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1], polarData.Intervall, meters);
                    }
                }
                else if (antallTabs > 2)
                {
                    if (polarData.HarSpeed && polarData.HarCadence)
                    {
                        AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1], polarData.Intervall, meters);
                    }
                    else if (polarData.HarSpeed && polarData.HarAltitude)
                    {
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1], polarData.Intervall, meters);
                    }
                    else if (polarData.HarSpeed && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = WritePowerData(hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1], polarData.Intervall, meters);
                    }
                    else if (polarData.HarCadence && polarData.HarAltitude)
                    {
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                    }
                    else if (polarData.HarCadence && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = WritePowerData(hrmVerdier[i + 2]);
                        AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                    }
                    else if (polarData.HarAltitude && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = WritePowerData(hrmVerdier[i + 2]);
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 1]);
                    }
                }
                else if (antallTabs > 1)
                {
                    if (polarData.HarSpeed)
                    {
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1], polarData.Intervall, meters);
                    }
                    else if (polarData.HarCadence)
                    {
                        AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 1]);
                    }
                    else if (polarData.HarAltitude)
                    {
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 1]);
                    }
                    else if (polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = WritePowerData(hrmVerdier[lapIndex]);
                    }
                }
                lap.Track[lapIndex] = lapTrackPoint;
                lapIndex++;
            }
            return lap;
        }

        private void AddAltitudeData(ref Trackpoint_t trackpoint, string value)
        {
            trackpoint.AltitudeMetersSpecified = true;
            trackpoint.AltitudeMeters = System.Convert.ToDouble(value);   
        }

        private void AddCadenceData(ref Trackpoint_t trackpoint, string value)
        {
            trackpoint.CadenceSpecified = true;
            trackpoint.Cadence = System.Convert.ToByte(value);
        }

        private double AddDistanceData(ref Trackpoint_t trackpoint, string value, int interval, double meters)
        {
            var speed = value.PolarConvertToDouble();
            if (speed > 1400)
                speed = 200;
            var distance = (speed / 0.6 / 60 * interval);
            trackpoint.DistanceMetersSpecified = true;
            trackpoint.DistanceMeters = meters + distance;
            return distance;
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
            wattElement.InnerText = powerValue;
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
                                    var gpsData = MapGpxFile(xmlFile.GpxFile, model);
                                    // Add gpsData til lap.track...
                                    //lap.Track[j].Position = new Position_t
                                    //{
                                    //    LatitudeDegrees = Convert.ToDouble(gpsData[j].trkseg[i].lat),
                                    //    LongitudeDegrees = Convert.ToDouble(gpsData[j].trkseg[i].lon)
                                    //};                            

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

        private gpx MapGpxFile(GpxFile gpxFile, UploadViewModel model)
        {
            var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
            return _gpxService.ReadGpxFile(gpxFile.Reference, timeKorreksjon);
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
