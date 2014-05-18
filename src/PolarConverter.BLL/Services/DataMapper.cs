using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Factories;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class DataMapper : IFileMapper
    {
        private readonly IStorageHelper _storageHelper;
        private readonly GpxService _gpxService;

        public DataMapper()
        {
            _storageHelper = new BlobStorageHelper("polarfiles");
            _gpxService = new GpxService(_storageHelper);
        }

        public DataMapper(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _gpxService = new GpxService(storageHelper);
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
            var trainingCenter = TrainingCenterFactory.CreateTrainingCenterDatabase(new[] { activity });
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
            var polardata = new PolarData();
            polardata.Versjon = StringHelper.HentVerdi("Version=", 3, hrmData);
            var v02Max = Calculators.CalculateVo2Max(hrmData, model.Weight);
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusValue = "";
            if (polardata.Versjon == "102" || polardata.Versjon == "105")
            {
                modusValue = StringHelper.HentVerdi("Mode=", 3, hrmData);
                polardata.Modus = modus;
                polardata.ModusVerdi = modusValue;
                polardata.HarCadence = modusValue.Substring(0, 1) == "0";
                polardata.HarAltitude = modusValue.Substring(0, 1) == "1";
                polardata.ImperiskeEnheter = modusValue.Substring(2, 1) == "1";
                polardata.HarSpeed = false;
                polardata.HarPower = false;
            }
            else
            {
                modusValue = StringHelper.HentVerdi("Mode=", 9, hrmData);
                polardata.Modus = modus;
                polardata.ModusVerdi = modusValue;
                polardata.HarCadence = modus == "SMode"
                    ? (modusValue.Substring(1, 1) == "1")
                    : modusValue.Substring(0, 1) == "0";
                polardata.HarAltitude = modus == "SMode"
                    ? (modusValue.Substring(2, 1) == "1")
                    : modusValue.Substring(0, 1) == "1";
                polardata.ImperiskeEnheter = modus == "SMode"
                    ? (modusValue.Substring(7, 1) == "1")
                    : modusValue.Substring(2, 1) == "1";
                polardata.HarSpeed = (modus == "SMode" && modusValue.Substring(0, 1) == "1") ||
                                     (modus == "Mode" && modusValue.Substring(1, 1) == "1");
                polardata.HarPower = modus == "SMode" && modusValue.Substring(3, 1) == "1";
            }
            var interval = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim());
            var tabs = 0;
            var noteData = StringHelper.LesLinjer(hrmData, "[Note]", out tabs);
            var noteText = new StringBuilder();
            foreach (var notes in noteData)
            {
                noteText.AppendLine(notes);
            }

            polardata.UploadViewModel = model;
            polardata.V02max = v02Max;
            polardata.HrmData = hrmData;
            polardata.Sport = file.Sport;
            polardata.Note = noteText.ToString();
            polardata.StartDate = StringHelper.HentVerdi("Date=", 8, hrmData).KonverterTilDato();
            polardata.StartTime = starTime;
            polardata.Device = Convert.ToInt32(StringHelper.HentVerdi("Monitor=", 2, hrmData).Trim());
            polardata.Intervall = interval;
            polardata.HrData = new List<HRData>();
            polardata.AltitudeData = new List<string>();
            polardata.PowerData = new List<string>();
            polardata.CadenseData = new List<string>();
            polardata.SpeedData = new List<string>();
            polardata.AntallMeter = new List<double>();
            polardata.GpxData = file.GpxFile != null ? _gpxService.MapGpxFile(file.GpxFile, model) : null;
            return polardata;
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
                        {
                            speed = i > antallTabs ? hrmVerdier[i - antallTabs].PolarConvertToDouble() : 200;
                        }
                        if (!data.ImperiskeEnheter)
                        {
                            data.AntallMeter.Add(data.AntallMeter.Count > 0
                                ? data.AntallMeter.Last() + (speed * Converters.HmhToKmhMultiplicationFactor * data.Intervall)
                                : (speed * Converters.HmhToKmhMultiplicationFactor * data.Intervall)
                            );
                        }
                        else
                        {
                            data.AntallMeter.Add(data.AntallMeter.Count > 0
                                ? data.AntallMeter.Last() + (speed * Converters.MphToKmhMultiplicationFactor * data.Intervall)
                                : (speed * Converters.MphToKmhMultiplicationFactor * data.Intervall)
                            );
                        }
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
            else
            {
                activity.Lap = CalculateIntTimes(polarData, activity.Id, KonverteringsHelper.HentStartDato(polarData));
            }
        }

        public ActivityLap_t[] CalculateIntTimes(PolarData polarData, DateTime startTime, DateTime startDate)
        {
            var laps = new List<ActivityLap_t>();
            var intervalsPerLap = new List<double>();
            var lastDistance = 0d;
            DateTime previouseLapEndtime = startTime.Date;
            var increment = polarData.Versjon == "102" || polarData.Versjon == "105" ? 16 : 28;
            startTime = new DateTime(startDate.Year, startDate.Month, startDate.Day,
                     startTime.Hour, startTime.Minute,
                     startTime.Second, startTime.Millisecond);
            for (var i = 0; i < polarData.RundeTider.Count; i = i + increment)
            {
                var lap = new ActivityLap_t();
                byte cadenceRecordings = 0;
                var distanceLogged = 0d;
                var rundeTid = polarData.RundeTider[i];
                DateTime lapEndTime;
                if (DateTime.TryParse(rundeTid, out lapEndTime))
                {
                    lap.StartTime = startTime;
                    var lapDuration = lapEndTime - previouseLapEndtime;
                    startTime = startTime.AddMilliseconds(lapDuration.TotalMilliseconds);
                    previouseLapEndtime = lapEndTime;
                    lap.TotalTimeSeconds = lapDuration.TotalSeconds;
                    var lastLapIntervals = Convert.ToInt32(Math.Ceiling(intervalsPerLap.Sum()));
                    var lengthOfLap = Convert.ToInt32(Math.Ceiling(lapEndTime.AntallSekunder() / (polarData.Intervall == 238 ? 5 : polarData.Intervall)));

                    var range = new Tuple<int, int>(
                        lastLapIntervals,
                        lengthOfLap
                    );
                    var positionData = CollectPositionData(polarData, ref range);
                    var heartRateData = RangeHelper.GetRange(polarData.HrData, range.Item1, range.Item2);
                    var altitudeData = RangeHelper.GetRange(polarData.AltitudeData, range.Item1, range.Item2);
                    var antallMeterData = RangeHelper.GetRange(polarData.AntallMeter, range.Item1, range.Item2);
                    var distanceData = antallMeterData != null && antallMeterData.Length > 0 ? antallMeterData.Last() - lastDistance : 0;
                    var speedData = RangeHelper.GetRange(polarData.SpeedData, range.Item1, range.Item2);
                    var cadenceData = RangeHelper.GetRange(polarData.CadenseData, range.Item1, range.Item2);
                    var lengths = new List<int>();
                    if (heartRateData != null)
                        lengths.Add(heartRateData.Length);
                    if (altitudeData != null)
                        lengths.Add(altitudeData.Length);
                    if (speedData != null)
                        lengths.Add(speedData.Length);
                    if (antallMeterData != null)
                        lengths.Add(antallMeterData.Length);
                    if (cadenceData != null)
                        lengths.Add(cadenceData.Length);
                    var maximumLength = lengths.Count > 0 ? lengths.Max() : 0;
                    lap.Track = new Trackpoint_t[maximumLength];
                    var maxSpeed = 0d;
                    for (int j = 0; j < maximumLength; j++)
                    {
                        var trackData = new Trackpoint_t();

                        if (heartRateData != null && heartRateData.Length > j)
                        {
                            GetHeartrate(heartRateData[j], ref trackData);
                        }
                        if (cadenceData != null && cadenceData.Length > j)
                        {
                            cadenceRecordings += GetCadence(cadenceData[j], ref trackData);
                        }
                        if (altitudeData != null && altitudeData.Length > j)
                        {
                            GetAltitude(altitudeData[j], ref trackData);
                        }
                        if (antallMeterData != null && j < antallMeterData.Length)
                        {
                            GetDistance(antallMeterData[j], ref trackData);
                        }
                        if (speedData != null && speedData.Length > j)
                        {
                            GetSpeed(speedData[j], polarData.Intervall, polarData.ImperiskeEnheter, ref distanceLogged, ref trackData, ref maxSpeed);
                        }
                        if (positionData != null && positionData.Length > j)
                        {
                            GetPosition(positionData[j], ref trackData);
                        }
                        trackData.Time = lap.StartTime.AddSeconds(polarData.Intervall * j);
                        lap.Track[j] = trackData;
                    }
                    lastDistance += antallMeterData != null && antallMeterData.Length > 0 ? antallMeterData.Last() : 0;
                    //runde.PowerData = HentRange(polarData.PowerData, range.Item1, range.Item2);
                    intervalsPerLap.Add(range.Item2);
                    //secondsInLap.Add(lapEndTime.AntallSekunder() - secondsInLap.Sum());
                    //lastLapInSeconds = Convert.ToInt32(Math.Ceiling(secondsInLap.Last()));
                    if (cadenceData != null)
                    {
                        lap.CadenceSpecified = true;
                        var avgCadence = cadenceRecordings / cadenceData.Length;
                        lap.Cadence = Convert.ToByte(avgCadence);
                    }
                    else
                    {
                        lap.CadenceSpecified = false;
                    }

                    if (speedData != null)
                    {
                        lap.MaximumSpeedSpecified = true;
                        lap.MaximumSpeed = maxSpeed;
                    }
                }
                lap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(polarData.RundeTider[i + 3]) };
                lap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(polarData.RundeTider[i + 4]) };
                lap.DistanceMeters = lastDistance;
                //runde.Distanse = polarData.ImperiskeEnheter ? Convert.ToDouble(rundeTid) / _imperial : Convert.ToDouble(rundeTid);

                var v02Max = Calculators.CalculateVo2Max(polarData.HrmData, polarData.UploadViewModel.Weight);
                lap.Calories = Calculators.CalulateCalories(v02Max,
                    StringHelper.HentVerdi("MaxHR=", 3, polarData.HrmData).PolarConvertToDouble(),
                    lap.AverageHeartRateBpm.Value, lap.TotalTimeSeconds);
                laps.Add(lap);
                lastDistance = 0;
            }
            return laps.ToArray();
        }

        public ActivityLap_t CollectLapForHrmData(PolarData polarData, List<string> hrmVerdier, int antallTabs)
        {
            var lap = new ActivityLap_t();
            var maximumDataLength = hrmVerdier.Count / antallTabs;
            var range = new Tuple<int, int>(0, maximumDataLength);
            var positionData = CollectPositionData(polarData, ref range);
            var heartRateData = RangeHelper.GetRange(polarData.HrData, range.Item1, range.Item2);
            lap.Track = new Trackpoint_t[maximumDataLength];
            var meters = 0d;
            var lapIndex = 0;
            var maxSpeed = 0d;
            byte cadenceData = 0;
            var duration = 0;
            var startTime = new DateTime(polarData.StartDate.Year, polarData.StartDate.Month, polarData.StartDate.Day, polarData.StartTime.Hour, polarData.StartTime.Minute, polarData.StartTime.Second);
            for (var i = 0; i < hrmVerdier.Count; i = i + antallTabs)
            {
                var lapTrackPoint = new Trackpoint_t
                {
                    Time = startTime.AddSeconds(lapIndex * polarData.Intervall)
                };
                if (positionData != null && i < positionData.Count())
                {
                    GetPosition(positionData[i], ref lapTrackPoint);
                }
                GetHeartrate(heartRateData[i], ref lapTrackPoint);
                if (antallTabs > 4)
                {
                    if (polarData.HarSpeed && polarData.HarCadence && polarData.HarAltitude && polarData.HarPower)
                    {
                        GetSpeed(hrmVerdier[i + 1], polarData.Intervall, polarData.ImperiskeEnheter, ref meters, ref lapTrackPoint, ref maxSpeed);
                        cadenceData += GetCadence(hrmVerdier[i + 2], ref lapTrackPoint);
                        GetAltitude(hrmVerdier[i + 3], ref lapTrackPoint);
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 4]);
                    }
                }
                else if (antallTabs > 3)
                {
                    if (polarData.HarSpeed)
                    {
                        if (polarData.HarCadence && polarData.HarAltitude)
                        {
                            GetAltitude(hrmVerdier[i + 3], ref lapTrackPoint);
                            GetSpeed(hrmVerdier[i + 1], polarData.Intervall, polarData.ImperiskeEnheter, ref meters, ref lapTrackPoint, ref maxSpeed);
                        }
                        else if (polarData.HarCadence && polarData.HarPower)
                        {
                            cadenceData += GetCadence(hrmVerdier[i + 2], ref lapTrackPoint);
                            lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 3]);
                            GetSpeed(hrmVerdier[i + 1], polarData.Intervall, polarData.ImperiskeEnheter, ref meters, ref lapTrackPoint, ref maxSpeed);
                        }
                    }
                    else
                    {
                        cadenceData += GetCadence(hrmVerdier[i + 1], ref lapTrackPoint);
                        GetAltitude(hrmVerdier[i + 2], ref lapTrackPoint);
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 3]);
                    }
                }
                else if (antallTabs > 2)
                {
                    if (polarData.HarSpeed)
                    {
                        if (polarData.HarCadence)
                        {
                            cadenceData += GetCadence(hrmVerdier[i + 2], ref lapTrackPoint);
                            GetSpeed(hrmVerdier[i + 1], polarData.Intervall, polarData.ImperiskeEnheter, ref meters, ref lapTrackPoint, ref maxSpeed);
                        }
                        else if (polarData.HarAltitude)
                        {
                            GetAltitude(hrmVerdier[i + 2], ref lapTrackPoint);
                            GetSpeed(hrmVerdier[i + 1], polarData.Intervall, polarData.ImperiskeEnheter, ref meters, ref lapTrackPoint, ref maxSpeed);
                        }
                        else if (polarData.HarPower)
                        {
                            lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 2]);
                            GetSpeed(hrmVerdier[i + 1], polarData.Intervall, polarData.ImperiskeEnheter, ref meters, ref lapTrackPoint, ref maxSpeed);
                        }
                    }
                    else if (polarData.HarCadence && polarData.HarAltitude)
                    {
                        GetAltitude(hrmVerdier[i + 2], ref lapTrackPoint);
                        cadenceData += GetCadence(hrmVerdier[i + 2], ref lapTrackPoint);
                    }
                    else if (polarData.HarCadence && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 2]);
                        cadenceData += GetCadence(hrmVerdier[i + 2], ref lapTrackPoint);
                    }
                    else if (polarData.HarAltitude && polarData.HarPower)
                    {
                        lapTrackPoint.Extensions = DataHelper.WritePowerData(hrmVerdier[i + 2]);
                        GetAltitude(hrmVerdier[i + 1], ref lapTrackPoint);
                    }
                }
                else if (antallTabs > 1)
                {
                    if (polarData.HarSpeed)
                    {
                        GetSpeed(hrmVerdier[i + 1], polarData.Intervall, polarData.ImperiskeEnheter, ref meters, ref lapTrackPoint, ref maxSpeed);
                    }
                    else if (polarData.HarCadence)
                    {
                        cadenceData += GetCadence(hrmVerdier[i + 1], ref lapTrackPoint);
                    }
                    else if (polarData.HarAltitude)
                    {
                        GetAltitude(hrmVerdier[i + 1], ref lapTrackPoint);
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
            lap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(heartRateData.Average(hr => hr.HjerteFrekvens)) };
            lap.CadenceSpecified = polarData.HarCadence;
            if (lap.CadenceSpecified)
            {
                var avgCadence = cadenceData / polarData.CadenseData.Count;
                lap.Cadence = Convert.ToByte(avgCadence);
            }
            if (polarData.V02max > 0)
            {
                lap.Calories = Calculators.CalulateCalories(polarData.V02max, heartRateData.Max(hr => hr.HjerteFrekvens), lap.AverageHeartRateBpm.Value,
                    duration);
            }
            else
            {
                lap.Calories = Calculators.CalulateCalories(polarData.UploadViewModel.Age, polarData.UploadViewModel.Weight, lap.AverageHeartRateBpm.Value, duration, isMale: polarData.UploadViewModel.Gender == "m");
            }
            lap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = heartRateData.Max(hr => hr.HjerteFrekvens) };
            lap.StartTime = startTime;
            if (polarData.HarSpeed)
            {
                lap.MaximumSpeedSpecified = true;
                lap.MaximumSpeed = maxSpeed * Converters.HmhToKmhMultiplicationFactor;
            }
            lap.TotalTimeSeconds = duration;
            lap.TriggerMethod = TriggerMethod_t.Manual;
            return lap;
        }

        private void CollectDataForLap()
        {
            
        }

        private static void GetPosition(PositionData positionData, ref Trackpoint_t trackData)
        {
            trackData.Position = new Position_t
            {
                LatitudeDegrees = Convert.ToDouble(positionData.Lat),
                LongitudeDegrees = Convert.ToDouble(positionData.Lon)
            };
        }

        private static void GetDistance(double antallMeterData, ref Trackpoint_t trackData)
        {
            trackData.DistanceMetersSpecified = true;
            trackData.DistanceMeters = antallMeterData;
        }

        private static void GetSpeed(string speedData, int interval, bool imperial, ref double distanceLogged, ref Trackpoint_t trackData, ref double maxSpeed)
        {
            double speedValue;
            if (double.TryParse(speedData, out speedValue))
            {
                if (speedValue > 1400)
                {
                    speedValue = 200;
                }
                if (imperial && speedValue * Converters.MphToKmh > maxSpeed || speedValue > maxSpeed)
                {
                    maxSpeed = imperial ? speedValue * Converters.MphToKmh : speedValue;
                }
                // Calculate distanse
                if (!trackData.DistanceMetersSpecified)
                {
                    var distance = speedValue * (imperial ? Converters.MphToMs : Converters.HmhToMs) * interval;
                    distanceLogged += distance;
                    trackData.DistanceMetersSpecified = true;
                    trackData.DistanceMeters = distanceLogged;
                }
            }
        }

        private static void GetAltitude(string altitudeData, ref Trackpoint_t trackData)
        {
            double altitudeValue;
            if (double.TryParse(altitudeData, out altitudeValue))
            {
                trackData.AltitudeMetersSpecified = true;
                trackData.AltitudeMeters = altitudeValue;
            }
        }

        private static byte GetCadence(string cadenceData, ref Trackpoint_t trackData)
        {
            byte cadenceValue;
            if (byte.TryParse(cadenceData, out cadenceValue))
            {
                trackData.Cadence = cadenceValue;
                trackData.CadenceSpecified = true;
            }
            return cadenceValue;
        }

        private static void GetHeartrate(HRData heartRateData, ref Trackpoint_t trackData)
        {
            trackData.HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = heartRateData.HjerteFrekvens };
        }

        private PositionData[] CollectPositionData(PolarData polarData, ref Tuple<int, int> range)
        {
            if (polarData.GpxData != null)
            {
                var positionData = _gpxService.CollectGpxData(polarData.GpxData, polarData.GpxData.Version, range.Item1, range.Item2,
                    polarData.StartTime, polarData.Intervall);
                range = new Tuple<int, int>(range.Item1, positionData.Length);
                return positionData;
            }
            return null;
        }
    }
}