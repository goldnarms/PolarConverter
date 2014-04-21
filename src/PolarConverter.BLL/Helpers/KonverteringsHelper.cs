using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Services;

namespace PolarConverter.BLL.Helpers
{
    public static class KonverteringsHelper
    {
        private const double Imperial = 0.621371192237d;
        private const double ForbrenningsFaktor = 4.4;

        public static byte BeregnHjerteFrekvense(int intervall, string verdi)
        {
            if (intervall == 238)
            {
                var rr = 60000 / Convert.ToDecimal(verdi);
                rr = rr > 255 ? 255 : rr;
                return Convert.ToByte(Math.Floor(rr));
            }

            return Convert.ToByte(verdi);
        }

        public static List<string> VaskIntTimes(string data)
        {
            int antallTabs;
            var tmp = StringHelper.LesLinjer(data, "[IntTimes]", out antallTabs, true);
            if (tmp.Count == 0)
            {
                tmp = new List<string> { StringHelper.HentVerdi("Length=", 10, data) };
            }

            return tmp;
        }

        public static DateTime HentStartDato(PolarData polarData)
        {
            return StringHelper.HentVerdi("Date=", 8, polarData.HrmData).KonverterTilDato();
        }

        private static int BeregnKalorier(Runde runde)
        {
            var pumpPerSlag = runde.VO2MaxAbsolutt > 0 && runde.MaxHr > 0 ? runde.VO2MaxAbsolutt / runde.MaxHr : 0;
            var mliterOksygenPerMinutt = runde.SnittHjerteFrekvens * pumpPerSlag;
            var literOksygenPerMinutt = mliterOksygenPerMinutt / 1000;
            var antallKalorierPerMin = literOksygenPerMinutt * ForbrenningsFaktor;
            return Convert.ToInt32(Math.Floor(antallKalorierPerMin * runde.AntallSekunder / 60));
        }

        public static ActivityLap_t[] CalculateIntTimes(PolarData polarData, DateTime startTime, DateTime startDate)
        {
            var gpxService = new GpxService();
            var laps = new List<ActivityLap_t>();
            var intervalsPerLap = new List<double>();
            var lastDistance = 0d;
            DateTime previouseLapEndtime = startTime.Date;
            var increment = polarData.Versjon == "102" || polarData.Versjon == "105" ? 16 : 28;
            for (var i = 0; i < polarData.RundeTider.Count; i = i + increment)
            {
                var lap = new ActivityLap_t();
                startTime = new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                     startTime.Hour, startTime.Minute,
                                     startTime.Second, startTime.Millisecond);

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
                    PositionData[] positionData = null;
                    if (polarData.GpxData != null)
                    {
                        positionData = gpxService.CollectGpxData(polarData.GpxData, polarData.GpxData.Version, range.Item1, range.Item2, polarData.StartTime, polarData.Intervall);
                        range = new Tuple<int, int>(range.Item1, positionData.Length);
                    }
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
                    if(cadenceData != null)
                        lengths.Add(cadenceData.Length);
                    var maximumLength = lengths.Count > 0 ? lengths.Max() : 0;
                    lap.Track = new Trackpoint_t[maximumLength];
                    for (int j = 0; j < maximumLength; j++)
                    {
                        var trackData = new Trackpoint_t();
                        if (heartRateData != null && j < heartRateData.Length)
                        {
                            trackData.HeartRateBpm = new HeartRateInBeatsPerMinute_t { Value = heartRateData[j].HjerteFrekvens };
                        }
                        byte cadenceValue;
                        if (cadenceData != null && j < cadenceData.Length &&
                            byte.TryParse(cadenceData[j], out cadenceValue))
                        {
                            trackData.Cadence = cadenceValue;
                            trackData.CadenceSpecified = true;                            
                        }
                        double altitudeValue;
                        if (altitudeData != null && j < altitudeData.Length && double.TryParse(altitudeData[j], out altitudeValue))
                        {
                            trackData.AltitudeMetersSpecified = true;
                            trackData.AltitudeMeters = altitudeValue;
                        }
                        double speedValue;
                        if (speedData != null && j < speedData.Length && double.TryParse(speedData[j], out speedValue))
                        {
                            // Calculate distanse
                        }
                        if (antallMeterData != null && j < antallMeterData.Length)
                        {
                            trackData.DistanceMetersSpecified = true;
                            trackData.DistanceMeters = antallMeterData[j];
                        }
                        if (positionData != null && j < positionData.Length)
                        {
                            trackData.Position = new Position_t
                            {
                                LatitudeDegrees = Convert.ToDouble(positionData[j].Lat),
                                LongitudeDegrees = Convert.ToDouble(positionData[j].Lon)
                            };                            
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
    }
}
