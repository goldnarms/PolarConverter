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
                    var speedData = RangeHelper.GetRange(polarData.SpeedData, range.Item1, range.Item2);
                    var antallMeterData = RangeHelper.GetRange(polarData.AntallMeter, range.Item1, range.Item2);
                    var cadenceData = RangeHelper.GetRange(polarData.CadenseData, range.Item1, range.Item2);
                    var distanceData = RangeHelper.HentRange(polarData.AntallMeter, range.Item1, range.Item2) != null &&
                                     RangeHelper.HentRange(polarData.AntallMeter, range.Item1, range.Item2).Count > 0
                                         ? RangeHelper.HentRange(polarData.AntallMeter, range.Item1, range.Item2).Last() -
                                           lastDistance
                                         : 0;
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
                    for (int j = 0; j < maximumLength; j++)
                    {
                        var trackData = new Trackpoint_t();
                        GetHeartrate(heartRateData, j, ref trackData);
                        GetCadence(cadenceData, j, ref trackData);
                        GetAltitude(altitudeData, j, ref trackData);
                        GetSpeed(speedData, j);
                        GetDistance(antallMeterData, j, ref trackData);
                        GetPosition(positionData, j, ref trackData);
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
                        var convertedCadence = new List<double>();
                        foreach (var s in cadenceData)
                        {
                            double val;
                            if (double.TryParse(s, out val))
                            {
                                convertedCadence.Add(val);
                            }
                        }
                        byte zero = 0;
                        lap.Cadence = convertedCadence.Count > 0 ? Convert.ToByte(convertedCadence.Average()) : zero;
                    }
                    else
                    {
                        lap.CadenceSpecified = false;
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

        private static void GetPosition(PositionData[] positionData, int j, ref Trackpoint_t trackData)
        {
            if (positionData != null && j < positionData.Length)
            {
                trackData.Position = new Position_t
                {
                    LatitudeDegrees = Convert.ToDouble(positionData[j].Lat),
                    LongitudeDegrees = Convert.ToDouble(positionData[j].Lon)
                };
            }
        }

        private static void GetDistance(double[] antallMeterData, int j, ref Trackpoint_t trackData)
        {
            if (antallMeterData != null && j < antallMeterData.Length)
            {
                trackData.DistanceMetersSpecified = true;
                trackData.DistanceMeters = antallMeterData[j];
            }
        }

        private static void GetSpeed(string[] speedData, int j)
        {
            double speedValue;
            if (speedData != null && j < speedData.Length && double.TryParse(speedData[j], out speedValue))
            {
                // Calculate distanse
            }
        }

        private static void GetAltitude(string[] altitudeData, int j, ref Trackpoint_t trackData)
        {
            double altitudeValue;
            if (altitudeData != null && j < altitudeData.Length && double.TryParse(altitudeData[j], out altitudeValue))
            {
                trackData.AltitudeMetersSpecified = true;
                trackData.AltitudeMeters = altitudeValue;
            }
        }

        private static void GetCadence(string[] cadenceData, int j, ref Trackpoint_t trackData)
        {
            byte cadenceValue;
            if (cadenceData != null && j < cadenceData.Length &&
                byte.TryParse(cadenceData[j], out cadenceValue))
            {
                trackData.Cadence = cadenceValue;
                trackData.CadenceSpecified = true;
            }
        }

        private static void GetHeartrate(HRData[] heartRateData, int j, ref Trackpoint_t trackData)
        {
            if (heartRateData != null && j < heartRateData.Length)
            {
                trackData.HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = heartRateData[j].HjerteFrekvens };
            }
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

        public ActivityLap_t CollectLapForHrmData(PolarData polarData, List<string> hrmVerdier, int antallTabs)
        {
            var lap = new ActivityLap_t();
            var maximumDataLength = hrmVerdier.Count / antallTabs;
            var range = new Tuple<int, int>(0, maximumDataLength);
            var positionData = CollectPositionData(polarData, ref range);
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
                var lapTrackPoint = new Trackpoint_t
                {
                    Time = startTime.AddSeconds(lapIndex*polarData.Intervall)
                };
                if (positionData != null && i < positionData.Count())
                {
                    lapTrackPoint.Position = new Position_t { LatitudeDegrees = Convert.ToDouble(positionData[i].Lat), LongitudeDegrees = Convert.ToDouble(positionData[i].Lon) };
                }
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
            lap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(heartRates / maximumDataLength) };
            lap.CadenceSpecified = polarData.HarCadence;
            if (lap.CadenceSpecified)
            {
                var avgCadence = cadenceData / maximumDataLength;
                lap.Cadence = Convert.ToByte(avgCadence);
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
            lap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = Convert.ToByte(maxHr) };
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
            trackpoint.AltitudeMeters = Convert.ToDouble(value);
        }

        public byte AddCadenceData(ref Trackpoint_t trackpoint, string value)
        {
            var cadence = Convert.ToByte(value);
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