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
using System.Globalization;
using PolarConverter.DAL.Models;

namespace PolarConverter.BLL.Services
{
    public class DataMapper : IFileMapper
    {
        private readonly IStorageHelper _storageHelper;
        private readonly GpxService _gpxService;
        private readonly DropboxService _dropboxService;
        private readonly byte _zero = 0;

        public DataMapper()
        {
            _storageHelper = new BlobStorageHelper("polarfiles");
            _gpxService = new GpxService(_storageHelper);
            _dropboxService = new DropboxService();
        }

        public DataMapper(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _gpxService = new GpxService(storageHelper);
            _dropboxService = new DropboxService();
        }

        public byte[] MapData(PolarFile hrmFile, UploadViewModel model)
        {
            var polarData = InitalizePolarData(hrmFile, model);
            var activity = ActivityFactory.CreateActivity(hrmFile.Sport, string.IsNullOrEmpty(model.Notes) ? polarData.Note : model.Notes, polarData.StartTime);
            VaskHrData(ref polarData);
            CollectHrmData(ref activity, polarData);
            var trainingCenter = TrainingCenterFactory.CreateTrainingCenterDatabase(new[] { activity });
            var serializer = new XmlSerializer(typeof(TrainingCenterDatabase_t));

            using (var memStream = new MemoryStream())
            {
                serializer.Serialize(memStream, trainingCenter);
                return memStream.ToArray();
            }
        }

        public PolarData InitalizePolarData(PolarFile file, UploadViewModel model)
        {
            var polardata = new PolarData();
            string hrmData = "";
            if (file.FromDropbox && !string.IsNullOrEmpty(model.Uid))
            {
                using (var db = new DAL.Context())
                {
                    var dropboxToken = db.OauthTokens.FirstOrDefault(oa => oa.UserId == model.Uid && oa.ProviderType == (int)ProviderType.Dropbox);
                    if (dropboxToken != null)
                    {
                        var userLogin = new DropNet.Models.UserLogin();
                        userLogin.Token = dropboxToken.Token;
                        userLogin.Secret = dropboxToken.Secret;
                        _dropboxService.Init(userLogin);
                        hrmData = _dropboxService.ReadFile(file.Reference);
                    }
                }
            }
            else
            {
                hrmData = _storageHelper.ReadFile(file.Reference);
            }

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
            polardata.InvertedOffset = model.TimeZoneOffset * -1;
            polardata.UploadViewModel = model;
            polardata.V02max = v02Max;
            polardata.HrmData = hrmData;
            polardata.Sport = file.Sport;
            polardata.Note = noteText.ToString();
            var startTime = GetTime(hrmData);
            polardata.OriginalDate = GetDate(hrmData);
            polardata.StartDate = CalculateStartDate(polardata.OriginalDate, startTime, polardata.InvertedOffset);
            polardata.StartTime = CalculateTimeForLap(polardata.OriginalDate, startTime, polardata.InvertedOffset);
            polardata.Device = Convert.ToInt32(StringHelper.HentVerdi("Monitor=", 2, hrmData).Trim());
            polardata.RecordingRate = interval;
            polardata.HrData = new List<HRData>();
            polardata.AltitudeData = new List<string>();
            polardata.PowerData = new List<string>();
            polardata.CadenseData = new List<string>();
            polardata.SpeedData = new List<string>();
            polardata.AntallMeter = new List<double>();
            polardata.GpxData = file.GpxFile != null ? _gpxService.MapGpxFile(file.GpxFile, model.Uid) : null;
            polardata.RundeTider = KonverteringsHelper.VaskIntTimes(hrmData);
            return polardata;
        }

        private static DateTime GetTime(string hrmData)
        {
            return ConvertTimeToDate(StringHelper.HentVerdi("StartTime=", 10, hrmData));
        }

        private static DateTime GetDate(string hrmData)
        {
            return StringHelper.HentVerdi("Date=", 8, hrmData).KonverterTilDato();
        }


        private static DateTime CalculateStartDate(DateTime date, DateTime time, double timeOffsetInHours)
        {
            var timeWithOffset = (time.Hour * 60) + time.Minute + (timeOffsetInHours * 60);
            if (timeWithOffset < 0)
            {
                // Need to substract a day
                date = date.AddDays(-1);
            }
            else if (timeWithOffset >= 1440)
            {
                // Need to add a day
                date = date.AddDays(1);
            }
            return date;
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
                        data.SpeedData.Add(hrmVerdier[i]);
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
            activity.Lap = CalculateIntTimes(polarData);
        }

        public ActivityLap_t[] CalculateIntTimes(PolarData polarData)
        {
            var laps = new List<ActivityLap_t>();
            var intervalsPerLap = new List<double>();
            var lastDistance = 0d;
            var startTime = polarData.StartTime;
            var increment = polarData.Versjon == "102" || polarData.Versjon == "105" ? 16 : 28;
            var previousDuration = new TimeSpan(0, 0, 0, 0);
            int endRange = 0;
            for (var i = 0; i < polarData.RundeTider.Count; i = i + increment)
            {
                var lapDurationInMs = GetMsForDateTime(ConvertTimeToDate(polarData.RundeTider[i])) - previousDuration.TotalMilliseconds;
                laps.Add(CreateLap(polarData, lapDurationInMs, out endRange, ref previousDuration, ref startTime, ref lastDistance));
                intervalsPerLap.Add(endRange);
            }
            if (polarData.HrData.Count - endRange > 10)
            {
                // Add extra lap
                double durationInMs = (polarData.HrData.Count - endRange) * polarData.RecordingRate * 1000;
                laps.Add(CreateLap(polarData, durationInMs, out endRange, ref previousDuration, ref startTime, ref lastDistance));
            }
            return laps.ToArray();
        }

        private ActivityLap_t CreateLap(PolarData polarData, double durationInMs, out int endRange, ref TimeSpan previousDuration, ref DateTime startTime, ref double lastDistance)
        {
            PositionData previousPosition = null;
            var gpsDistance = 0d;
            var lap = new ActivityLap_t();
            byte cadenceRecordings = 0;
            var distanceLogged = 0d;
            lap.StartTime = startTime.ToUniversalTimeZone();


            var lapEndTime = startTime.AddMilliseconds(durationInMs);
            var durationTimeSpan = GetDuration(startTime, lapEndTime);
            startTime = lapEndTime;
            lap.TotalTimeSeconds = durationTimeSpan.TotalSeconds;

            var range = new Tuple<int, int>(
                GetFrequencyForDate(previousDuration, polarData.RecordingRate),
                GetFrequencyForDate(previousDuration + durationTimeSpan, polarData.RecordingRate)
            );
            previousDuration = previousDuration + durationTimeSpan;
            var positionData = CollectPositionData(polarData, lap.StartTime, range);
            var heartRateData = RangeHelper.GetRange(polarData.HrData, range.Item1, range.Item2 - range.Item1);
            var altitudeData = RangeHelper.GetRange(polarData.AltitudeData, range.Item1, range.Item2 - range.Item1);
            var antallMeterData = RangeHelper.GetRange(polarData.AntallMeter, range.Item1, range.Item2 - range.Item1);
            var speedData = RangeHelper.GetRange(polarData.SpeedData, range.Item1, range.Item2 - range.Item1);
            var cadenceData = RangeHelper.GetRange(polarData.CadenseData, range.Item1, range.Item2 - range.Item1);
            var powerData = RangeHelper.GetRange(polarData.PowerData, range.Item1, range.Item2 - range.Item1);
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
                    if (speedData == null)
                    {
                        trackData.DistanceMetersSpecified = true;
                        if (previousPosition != null)
                        {
                            gpsDistance = gpsDistance + GeoCalculator.Distance(Convert.ToDouble(positionData[j].Lat),
                                Convert.ToDouble(positionData[j].Lon), Convert.ToDouble(previousPosition.Lat),
                                Convert.ToDouble(previousPosition.Lon), GeoCalculator.MeasureUnits.Kilometers);
                        }
                        previousPosition = positionData[j];
                        trackData.DistanceMeters = gpsDistance;
                    }
                }
                if (powerData != null && powerData.Length > j)
                {
                    trackData.Extensions = DataHelper.WritePowerData(trackData.Extensions, powerData[j]);
                }
                trackData.Time = lap.StartTime.AddSeconds(polarData.RecordingRate * j).ToUniversalTimeZone();
                lap.Track[j] = trackData;
            }
            //runde.PowerData = HentRange(polarData.PowerData, range.Item1, range.Item2);
            endRange = range.Item2;
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


            var v02Max = Calculators.CalculateVo2Max(polarData.HrmData, polarData.UploadViewModel.Weight);
            lap.Calories = Calculators.CalulateCalories(v02Max,
                StringHelper.HentVerdi("MaxHR=", 3, polarData.HrmData).PolarConvertToDouble(),
                lap.AverageHeartRateBpm.Value, lap.TotalTimeSeconds);
            if (antallMeterData != null && antallMeterData.Length > 0)
            {
                var lastMeter = antallMeterData.Last();
                lap.DistanceMeters = lastMeter - lastDistance;
                lastDistance = lastMeter;
            }
            else
            {
                lap.DistanceMeters = gpsDistance;
            }
            return lap;
        }

        private int GetMsForDateTime(DateTime lapTime)
        {
            return GetMsForSeconds(GetSecondsForMinutes(GetMinutesForHours(lapTime.Hour) + lapTime.Minute) + lapTime.Second) + lapTime.Millisecond;
        }

        private int GetMsForSeconds(int seconds)
        {
            return seconds * 1000;
        }

        private int GetSecondsForMinutes(int minutes)
        {
            return minutes * 60;
        }

        private int GetMinutesForHours(int hour)
        {
            return hour * 60;
        }

        private static DateTime ConvertTimeToDate(string lapTime)
        {
            int hourLength = lapTime[1] == ':' ? 1 : 2;
            DateTime today = DateTime.Today.Date;
            return new DateTime(
                today.Year,
                today.Month,
                today.Day,
                Convert.ToInt32(lapTime.Substring(0, hourLength)),
                Convert.ToInt32(lapTime.Substring(hourLength + 1, 2)),
                Convert.ToInt32(lapTime.Substring(hourLength + 4, 2)),
                lapTime.Length > 8 ? Convert.ToInt32(lapTime.Substring(hourLength + 7, 1)) * 100 : 0
            );
        }

        private static DateTime CalculateTimeForLap(DateTime exerciseDate, DateTime lapTime, double offsetInHours)
        {
            // Check for h:MM:ss format
            var lapDateTime = new DateTime(
                exerciseDate.Year,
                exerciseDate.Month,
                exerciseDate.Day,
                lapTime.Hour,
                lapTime.Minute,
                lapTime.Second,
                lapTime.Millisecond
            );
            return lapDateTime.AddHours(offsetInHours);
        }

        private static TimeSpan GetDuration(DateTime startTime, DateTime endTime)
        {
            return endTime - startTime;
        }

        private static int GetFrequencyForDate(TimeSpan duration, int recordingRate)
        {
            return recordingRate > 0 ? Convert.ToInt32(Math.Ceiling(duration.TotalSeconds / (recordingRate == 238 ? 5 : recordingRate))) : 0;
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
                    maxSpeed = maxSpeed * 0.1;
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

        private PositionData[] CollectPositionData(PolarData polarData, DateTime startTime, Tuple<int, int> range)
        {
            if (polarData.GpxData != null)
            {
                var positionData = _gpxService.CollectGpxData(polarData, startTime, range.Item1, range.Item2);
                return positionData;
            }
            return null;
        }
    }
}