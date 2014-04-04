using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Factories;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class DataMapper : IFileMapper
    {
        private IStorageHelper _storageHelper;
        private GpxService _gpxService;

        public DataMapper()
        {
            _storageHelper = new LocalStorageHelper();
            _gpxService = new GpxService();
        }

        public DataMapper(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
        }

        public byte[] MapData(PolarFile hrmFile, UploadViewModel model)
        {
            var hrmData = _storageHelper.ReadFile(hrmFile.Reference);
            var startTime = Convert.ToDateTime(StringHelper.HentVerdi("StartTime=", 10, hrmData));
            startTime = startTime.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneOffset));
            var polarData = InitalizePolarData(hrmFile, model, hrmData, startTime);
            var activity = ActivityFactory.CreateActivity(hrmFile.Sport, string.IsNullOrEmpty(model.Notes) ? polarData.Note : model.Notes, startTime);

            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(hrmData);
            VaskHrData(ref polarData);
            CollectHrmData(ref activity, polarData);

            //polarData.Runder = KonverteringsHelper.GenererRunder(polarData);
            //activity.Lap = CollectLapsData(polarData.Runder, startTime, v02max, polarData.Intervall);
            var trainingCenter = TrainingCenterFactory.CreateTrainingCenterDatabase(activity);
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

        public PolarData InitalizePolarData(PolarFile file, UploadViewModel model, string hrmData, DateTime starTime)
        {
            var v02Max = Calculators.CalculateVo2Max(hrmData, model.Weight);
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
                UploadViewModel = model,
                V02max = v02Max,
                HrmData = hrmData,
                Sport = file.Sport,
                Note = noteText.ToString(),
                StartTime = starTime,
                StartDate = StringHelper.HentVerdi("Date=", 8, hrmData).KonverterTilDato(),
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
                GpxData = file.GpxFile != null ? _gpxService.MapGpxFile(file.GpxFile, model) : null
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

        public ActivityLap_t CollectLapForHrmData(PolarData polarData, List<string> hrmVerdier, int antallTabs)
        {
            var lap = new ActivityLap_t();
            var maximumDataLength = hrmVerdier.Count / antallTabs;
            lap.Track = new Trackpoint_t[maximumDataLength];
            var meters = 0d;
            var lapIndex = 0;
            var heartRates = 0d;
            var maxHr = 0d;
            var maxSpeed = 0d;
            var cadenceData = 0;
            var duration = 0;
            var startTime = new DateTime(polarData.StartDate.Year, polarData.StartDate.Month, polarData.StartDate.Day, polarData.StartTime.Hour, polarData.StartTime.Minute, polarData.StartTime.Second);
            for (var i = 0; i < hrmVerdier.Count; i = i + antallTabs)
            {
                var lapTrackPoint = new Trackpoint_t();
                lapTrackPoint.Time = startTime.AddSeconds(lapIndex * polarData.Intervall);
                var hr = AddHeartRateData(ref lapTrackPoint, hrmVerdier[i], polarData.Intervall);
                heartRates += hr;
                if (hr > maxHr)
                    maxHr = hr;
                if (antallTabs > 4)
                {
                    if (polarData.HarSpeed && polarData.HarCadence && polarData.HarAltitude && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 4]);
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 3]);
                        cadenceData += AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        var speed = hrmVerdier[i + 1].PolarConvertToDouble(); ;
                        meters += AddDistanceData(ref lapTrackPoint, speed, polarData.Intervall, meters);
                        if (speed > maxSpeed)
                            maxSpeed = speed;
                    }
                }
                else if (antallTabs > 3)
                {
                    if (polarData.HarSpeed && polarData.HarCadence && polarData.HarAltitude)
                    {
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 3]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1].ToPolarDouble(), polarData.Intervall, meters);
                    }
                    else if (polarData.HarSpeed && polarData.HarCadence && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 3]);
                        cadenceData += AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1].ToPolarDouble(), polarData.Intervall, meters);
                    }
                }
                else if (antallTabs > 2)
                {
                    if (polarData.HarSpeed && polarData.HarCadence)
                    {
                        cadenceData += AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1].ToPolarDouble(), polarData.Intervall, meters);
                    }
                    else if (polarData.HarSpeed && polarData.HarAltitude)
                    {
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1].ToPolarDouble(), polarData.Intervall, meters);
                    }
                    else if (polarData.HarSpeed && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 2]);
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1].ToPolarDouble(), polarData.Intervall, meters);
                    }
                    else if (polarData.HarCadence && polarData.HarAltitude)
                    {
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 2]);
                        cadenceData += AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                    }
                    else if (polarData.HarCadence && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 2]);
                        cadenceData += AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 2]);
                    }
                    else if (polarData.HarAltitude && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 2]);
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 1]);
                    }
                }
                else if (antallTabs > 1)
                {
                    if (polarData.HarSpeed)
                    {
                        meters += AddDistanceData(ref lapTrackPoint, hrmVerdier[i + 1].ToPolarDouble(), polarData.Intervall, meters);
                    }
                    else if (polarData.HarCadence)
                    {
                        cadenceData += AddCadenceData(ref lapTrackPoint, hrmVerdier[i + 1]);
                    }
                    else if (polarData.HarAltitude)
                    {
                        AddAltitudeData(ref lapTrackPoint, hrmVerdier[i + 1]);
                    }
                    else if (polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[lapIndex]);
                    }
                }
                lap.Track[lapIndex] = lapTrackPoint;
                duration += polarData.Intervall;
                lapIndex++;
            }
            lap.DistanceMeters = meters;
            lap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = System.Convert.ToByte(heartRates / maximumDataLength) };
            lap.CadenceSpecified = polarData.HarCadence;
            if (lap.CadenceSpecified)
            {
                var avgCadence = cadenceData / maximumDataLength;
                lap.Cadence = System.Convert.ToByte(avgCadence);
            }
            if (polarData.V02max > 0)
            {
                lap.Calories = Calculators.CalulateCalories(polarData.V02max, maxHr, lap.AverageHeartRateBpm.Value,
                    duration);
            }
            else
            {
                lap.Calories = Calculators.CalulateCalories(polarData.UploadViewModel.Age, polarData.UploadViewModel.Weight, lap.AverageHeartRateBpm.Value, duration, polarData.UploadViewModel.Gender == "m");
            }
            lap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = System.Convert.ToByte(maxHr) };
            lap.StartTime = startTime;
            if (polarData.HarSpeed)
            {
                lap.MaximumSpeedSpecified = true;
                lap.MaximumSpeed = maxSpeed;
            }
            lap.TotalTimeSeconds = duration;
            lap.TriggerMethod = TriggerMethod_t.Manual;
            return lap;
        }

        public void AddAltitudeData(ref Trackpoint_t trackpoint, string value)
        {
            trackpoint.AltitudeMetersSpecified = true;
            trackpoint.AltitudeMeters = System.Convert.ToDouble(value);
        }

        public byte AddCadenceData(ref Trackpoint_t trackpoint, string value)
        {
            var cadence = System.Convert.ToByte(value);
            trackpoint.CadenceSpecified = true;
            trackpoint.Cadence = cadence;
            return cadence;
        }

        public double AddDistanceData(ref Trackpoint_t trackpoint, double speed, int interval, double meters)
        {
            if (speed > 1400)
                speed = 200;
            var distance = (speed / 0.6 / 60 * interval);
            trackpoint.DistanceMetersSpecified = true;
            trackpoint.DistanceMeters = meters + distance;
            return distance;
        }

        public double AddHeartRateData(ref Trackpoint_t trackpoint, string value, int interval)
        {
            var hr = KonverteringsHelper.BeregnHjerteFrekvense(interval, value);
            trackpoint.HeartRateBpm = new HeartRateInBeatsPerMinute_t
            {
                Value = hr
            };
            return hr;
        }
    }
}