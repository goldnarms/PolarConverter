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
        private readonly byte _zero = 0;

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
            var initialStartDate = startTime;
            startTime = startTime.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneOffset));
            startTime = new DateTime(initialStartDate.Year, initialStartDate.Month, initialStartDate.Day, startTime.Hour, startTime.Minute, startTime.Second, startTime.Millisecond);
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
                polardata.HarSpeed = modusValue.Substring(1, 1) == "1";
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
            polardata.RecordingRate = interval;
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
            var hrmVerdier = StringHelper.LesLinjer(data.HrmData, "[HRData]", out antallTabs, true, true);
            if (hrmVerdier.Count == 0)
            {
                throw new Exception("Heart rate data is empty, please check HRM file.");
            }
            for (var i = 0; i < hrmVerdier.Count; i++)
            {
                if (i % antallTabs == 0)
                {
                    data.HrData.Add(new HRData { HjerteFrekvens = KonverteringsHelper.BeregnHjerteFrekvense(data.RecordingRate, hrmVerdier[i]) });
                }
                else if (i % antallTabs == 1)
                {
                    if (data.HarSpeed)
                    {
                        if (data.AntallMeter.Count > 0)
                        {
                            data.AntallMeter.Add(data.AntallMeter.Last() +
                                                 GetDistanceForSpeed(hrmVerdier, i, data.RecordingRate,
                                                     data.ImperiskeEnheter));
                        }
                        else
                        {
                            data.AntallMeter.Add(GetDistanceForSpeed(hrmVerdier, i, data.RecordingRate,
                                data.ImperiskeEnheter));
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

        private double GetDistanceForSpeed(List<string> values, int index, int interval, bool isImperial)
        {
            var speed = values[index].PolarConvertToDouble();
            if (speed > 1400)
            {
                return index + 1 < values.Count ? GetDistanceForSpeed(values, index + 1, interval, isImperial) : 200;
            }
            return speed * (isImperial ? Converters.MphToMs : Converters.HmhToMs) * interval;
        }

        private void CollectHrmData(ref Activity_t activity, PolarData polarData)
        {
            activity.Lap = CalculateIntTimes(polarData, activity.Id, KonverteringsHelper.HentStartDato(polarData));
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
                    lap.StartTime = startTime.ToUniversalTime();
                    var lapDuration = lapEndTime - previouseLapEndtime;
                    startTime = startTime.AddMilliseconds(lapDuration.TotalMilliseconds);
                    lap.TotalTimeSeconds = lapDuration.TotalSeconds;

                    var range = new Tuple<int, int>(
                        GetFrequencyForDate(previouseLapEndtime, polarData.RecordingRate),
                        GetFrequencyForDate(lapEndTime, polarData.RecordingRate)
                    );
                    previouseLapEndtime = lapEndTime;
                    var positionData = CollectPositionData(polarData, ref range);
                    var heartRateData = RangeHelper.GetRange(polarData.HrData, range.Item1, range.Item2);
                    var altitudeData = RangeHelper.GetRange(polarData.AltitudeData, range.Item1, range.Item2);
                    var antallMeterData = RangeHelper.GetRange(polarData.AntallMeter, range.Item1, range.Item2);
                    var lastMeter = antallMeterData != null && antallMeterData.Length > 0 ? antallMeterData.Last() : 0;
                    lap.DistanceMeters = lastMeter - lastDistance;
                    lastDistance = lastMeter;
                    var speedData = RangeHelper.GetRange(polarData.SpeedData, range.Item1, range.Item2);
                    var cadenceData = RangeHelper.GetRange(polarData.CadenseData, range.Item1, range.Item2);
                    var powerData = RangeHelper.GetRange(polarData.PowerData, range.Item1, range.Item2);
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
                            GetSpeed(speedData[j], polarData.RecordingRate, polarData.ImperiskeEnheter, ref distanceLogged, ref trackData, ref maxSpeed);
                        }
                        if (positionData != null && positionData.Length > j)
                        {
                            GetPosition(positionData[j], ref trackData);
                        }
                        if (powerData != null && powerData.Length > j)
                        {
                            trackData.Extensions = DataHelper.WritePowerData(powerData[j]);
                        }
                        trackData.Time = lap.StartTime.AddSeconds(polarData.RecordingRate * j).ToUniversalTime();
                        lap.Track[j] = trackData;
                    }
                    //runde.PowerData = HentRange(polarData.PowerData, range.Item1, range.Item2);
                    intervalsPerLap.Add(range.Item2);
                    if (cadenceData != null && cadenceData.Length > 0)
                    {
                        lap.CadenceSpecified = true;
                        var avgCadence = cadenceData.Average(cd => Convert.ToDouble(cd));
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
                    if (heartRateData != null && heartRateData.Count() > 0)
                    {
                        lap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t
                        {
                            Value = Convert.ToByte(heartRateData.Average(hr => hr.HjerteFrekvens))
                        };
                        lap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t
                        {
                            Value = Convert.ToByte(heartRateData.Max(hr => hr.HjerteFrekvens))
                        };
                    }
                    else
                    {
                        lap.AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = _zero };
                        lap.MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = _zero };
                    }
                }

                var v02Max = Calculators.CalculateVo2Max(polarData.HrmData, polarData.UploadViewModel.Weight);
                lap.Calories = Calculators.CalulateCalories(v02Max,
                    StringHelper.HentVerdi("MaxHR=", 3, polarData.HrmData).PolarConvertToDouble(),
                    lap.AverageHeartRateBpm.Value, lap.TotalTimeSeconds);
                laps.Add(lap);
            }
            return laps.ToArray();
        }

        private int GetFrequencyForDate(DateTime date, int recordingRate)
        {
            return Convert.ToInt32(Math.Ceiling(date.AntallSekunder() / (recordingRate == 238 ? 5 : recordingRate)));
        }

        private static void GetPosition(PositionData positionData, ref Trackpoint_t trackData)
        {
            if (positionData != null)
            {
                trackData.Position = new Position_t
                {
                    LatitudeDegrees = Convert.ToDouble(positionData.Lat),
                    LongitudeDegrees = Convert.ToDouble(positionData.Lon)
                };
            }
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
                var positionData = _gpxService.CollectGpxData(polarData, range.Item1, range.Item2);
                range = new Tuple<int, int>(range.Item1, positionData.Length);
                return positionData;
            }
            return null;
        }
    }
}