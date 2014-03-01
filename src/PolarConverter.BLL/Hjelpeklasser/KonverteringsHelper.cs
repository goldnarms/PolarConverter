using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Services;

namespace PolarConverter.BLL.Hjelpeklasser
{
    public static class KonverteringsHelper
    {
        private const double _imperial = 0.621371192237d;
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

        public static List<GPSData> VaskGpxString(string gpxFileContent, int minuttjustering)
        {
            var liste = new List<GPSData>();
            var gpsdata = new GPSData();
            var gpsDataListe = StringHelper.LesLinjer(gpxFileContent);
            if (gpsDataListe != null && gpsDataListe.Count() == 1)
            {
                gpsDataListe = gpsDataListe.First().Split('/').ToList();
            }

            foreach (var gpsData in gpsDataListe)
            {
                if (gpsData.Contains("<trkpt"))
                {
                    gpsdata.Koordinater = VaksGpsKoordinater(gpsData);
                }
                else if (gpsData.Contains("<time>"))
                {
                    if (gpsdata.Koordinater != null)
                    {
                        var tid = StringHelper.HentVerdi("<time>", 20, gpsData).ToPolarDateTime();
                        if (tid.HasValue)
                        {
                            gpsdata.Tid = new Tid(tid.Value.AddMinutes(minuttjustering));
                            liste.Add(gpsdata);
                        }
                        gpsdata = new GPSData();
                    }
                }
            }
            return liste;
        }

        private static bool ErGpsKoordinaterEnLinje(string gpsData)
        {
            if (gpsData.Contains("<trkpt"))
                return gpsData.Substring(gpsData.IndexOf("<trkpt", StringComparison.Ordinal) + 6).Contains("<trkpt");
            return false;
        }

        private static Koordinater VaksGpsKoordinater(string gpsData)
        {
            var latIndex = gpsData.IndexOf("lat=", StringComparison.Ordinal) + 5;
            var lonIndex = gpsData.IndexOf("lon=", StringComparison.Ordinal) + 5;
            var latIndexT = gpsData.Substring(latIndex).IndexOf("\" ", StringComparison.Ordinal);
            var lonIndexT = gpsData.Substring(lonIndex).IndexOf("\">", StringComparison.Ordinal);
            return new Koordinater(gpsData.Substring(latIndex, latIndexT), gpsData.Substring(lonIndex, lonIndexT));
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

        public static List<Runde> GenererRunder(XmlPolarData polarData)
        {
            var runder = new List<Runde>();
            var runde = new Runde();
            var antallIntervalPrRunde = new List<double>();
            var antallSekunderPrRunde = new List<double>();
            var forrigeRundetidISekunder = 0;
            double forrigeDistanser = 0;
            var startDate = polarData.StartTime;
            if (polarData.LapTimes.Count == 1)
            {
                var varighet = polarData.LapTimes[0];
                runde.AntallSekunder = varighet.TotalSeconds;
                if (polarData.GpxDataString != null)
                {
                    runde.GpsData = polarData.GpxDataString;
                }

                if (polarData.HeartRate != null)
                {
                    BeregnXmlHrData(polarData, runde);
                }
                //runde.StartTime = OppdaterStartTime(startDate, startDate, tid);
                //runde.Vekt = BeregnVekt(polarData);
                //var hrmData = polarData.HrmData;
                //runde.HrmData = hrmData;
                //runde.VO2MaxAbsolutt = BeregnVo2MaxAbsolutt(hrmData, runde);
                //runde.MaxHr = BeregneMaxHr(hrmData);
                //runde.Kalorier = BeregnKalorier(runde);
                //runde.AltitudeData = polarData.AltitudeData;
                //BeregnHastighet(polarData, runde);
                //runde.AntallMeterData = polarData.AntallMeter;
                //runde.Distanse = BeregnDistanse(polarData);
                //runde.CadenseData = polarData.CadenseData;
                //runde.PowerData = polarData.PowerData;
                runder.Add(runde);
            }
            else
            {
                //if (polarData.Versjon == "102")
                //    runder.AddRange(CalculateOldIntTimes(runde, polarData, startTime, forrigeRundetidISekunder, antallIntervalPrRunde, antallSekunderPrRunde, forrigeDistanser, startDate));
                //else
                //{
                //    runder.AddRange(CalculateIntTimes(runde, polarData, startTime, forrigeRundetidISekunder, antallIntervalPrRunde, antallSekunderPrRunde, forrigeDistanser, startDate));
                //}
            }
            return runder;
        }

        public static List<Runde> GenererRunder(PolarData polarData)
        {
            var runder = new List<Runde>();
            var runde = new Runde();
            var antallIntervalPrRunde = new List<double>();
            var antallSekunderPrRunde = new List<double>();
            var forrigeRundetidISekunder = 0;
            double forrigeDistanser = 0;
            var startDate = HentStartDato(polarData);
            var startTime = HentStartTid(polarData);
            if (polarData.RundeTider.Count == 1)
            {
                DateTime tid;
                var rundeTid = polarData.RundeTider[0];
                DateTime.TryParse(rundeTid, out tid);
                var varighet = BeregnVarighet(tid, antallSekunderPrRunde);
                runde.AntallSekunder = BeregnAntallSekunder(varighet);
                if (polarData.GpxDataString != null)
                {
                    runde.GpsData = polarData.GpxDataString;
                }

                if (polarData.HrData != null)
                {
                    BeregnHrData(polarData, runde);
                }
                runde.StartTime = OppdaterStartTime(startTime, startDate, tid);
                runde.Vekt = BeregnVekt(polarData);
                var hrmData = polarData.HrmData;
                runde.HrmData = hrmData;
                runde.VO2MaxAbsolutt = BeregnVo2MaxAbsolutt(hrmData, runde);
                runde.MaxHr = BeregneMaxHr(hrmData);
                runde.Kalorier = BeregnKalorier(runde);
                runde.AltitudeData = polarData.AltitudeData;
                BeregnHastighet(polarData, runde);
                runde.AntallMeterData = polarData.AntallMeter;
                runde.Distanse = BeregnDistanse(polarData);
                runde.CadenseData = polarData.CadenseData;
                runde.PowerData = polarData.PowerData;
                runder.Add(runde);
            }
            else
            {
                if(polarData.Versjon == "102")
                    runder.AddRange(CalculateOldIntTimes(runde, polarData, startTime, forrigeRundetidISekunder, antallIntervalPrRunde, antallSekunderPrRunde, forrigeDistanser, startDate));
                else
                {
                    runder.AddRange(CalculateIntTimes(runde, polarData, startTime, forrigeRundetidISekunder, antallIntervalPrRunde, antallSekunderPrRunde, forrigeDistanser, startDate));
                }
            }
            return runder;
        }

        private static double BeregneMaxHr(string hrmData)
        {
            return StringHelper.HentVerdi("MaxHR=", 3, hrmData).PolarConvertToDouble();
        }

        private static double BeregnVo2MaxAbsolutt(string hrmData, Runde runde)
        {
            return StringHelper.HentVerdi("VO2max=", 2, hrmData).PolarConvertToDouble() * runde.Vekt;
        }

        private static double BeregnDistanse(PolarData polarData)
        {
            return polarData.AntallMeter != null && polarData.AntallMeter.Count > 0 ? polarData.AntallMeter.Last() : 0;
        }

        private static void BeregnHastighet(PolarData polarData, Runde runde)
        {
            if (polarData.SpeedData != null && polarData.SpeedData.Count > 0)
            {
                runde.SpeedData = polarData.SpeedData;
                runde.MaksHastighet = runde.SpeedData.Max(speed => speed.PolarConvertToDouble()) / 36;
            }
        }

        private static double BeregnVekt(PolarData polarData)
        {
            return polarData.UserInfo.Weight;
        }

        private static DateTime OppdaterStartTime(DateTime? startTime, DateTime startDate, DateTime tid)
        {
            return startTime.HasValue
                       ? new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                      startTime.Value.Hour, startTime.Value.Minute,
                                      startTime.Value.Second)
                       : new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                      tid.Hour, tid.Minute,
                                      tid.Second);
        }

        private static void BeregnHrData(PolarData polarData, Runde runde)
        {
            runde.HrData = polarData.HrData;
            runde.MinHjertefrekvens = runde.HrData.Min(hr => hr.HjerteFrekvens);
            runde.SnittHjerteFrekvens = Math.Floor(runde.HrData.Average(hr => hr.HjerteFrekvens));
            runde.MaksHjertefrekvens = runde.HrData.Max(hr => hr.HjerteFrekvens);
        }

        private static void BeregnXmlHrData(XmlPolarData polarData, Runde runde)
        {
            runde.HrData = polarData.HeartRate.Select(hr => new HRData { HjerteFrekvens = (byte)hr}).ToList();

            runde.MinHjertefrekvens = (byte)polarData.HeartRate.Min();
            runde.SnittHjerteFrekvens = Math.Floor(polarData.HeartRate.Average());
            runde.MaksHjertefrekvens = polarData.HeartRate.Max();
        }

        private static double BeregnAntallSekunder(DateTime varighet)
        {
            var antallSekunder =
                Convert.ToDouble(String.Format("{0}{1}{2}", varighet.Hour * 3600 + varighet.Minute * 60 + varighet.Second, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator,
                                               varighet.Millisecond));

            if (antallSekunder > 50000)
                antallSekunder = antallSekunder / 1000;
            return antallSekunder;
        }

        private static DateTime BeregnVarighet(DateTime tid, IEnumerable<double> antallSekunderPrRunde)
        {
            return tid.AddSeconds(antallSekunderPrRunde.Sum() * (-1));
        }

        private static DateTime? HentStartTid(PolarData polarData)
        {
            var startTime = StringHelper.HentVerdi("StartTime=", 10, polarData.HrmData).ToPolarTid();
            if (startTime != null)
                startTime = startTime.Value.AddMinutes(IntHelper.HentTidsKorreksjon(polarData.UserInfo.TimeZoneOffset));
            return startTime;
        }

        private static DateTime HentStartDato(PolarData polarData)
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

        public static List<Runde> GenererXmlRunder(PolarData polarData)
        {
            var startDate = StringHelper.HentVerdi("<time>", 10, polarData.XmlTekst).KonverterTilDato();
            var startTime = StringHelper.HentVerdi("<time>", 10, polarData.XmlTekst, 11).ToPolarTid();
            if (startTime != null)
                startTime = startTime.Value.AddMinutes(IntHelper.HentTidsKorreksjon(polarData.UserInfo.TimeZoneOffset));
            var runder = new List<Runde>();
            var runde = new Runde();
            var antallIntervalPrRunde = new List<double>();
            var antallSekunderPrRunde = new List<double>();
            var forrigeRundetidISekunder = 0;
            for (var i = 0; i < polarData.RundeTider.Count; i++)
            {
                DateTime tid;
                var rundeTid = polarData.RundeTider[i];
                DateTime.TryParse(rundeTid, out tid);
                if (startTime.HasValue)
                    startTime = startTime.Value.AddSeconds(forrigeRundetidISekunder);
                var range = polarData.Intervall > 0
                                ? new Tuple<int, int>(
                                      Convert.ToInt32(Math.Ceiling(antallIntervalPrRunde.Sum())),
                                      Convert.ToInt32(
                                              Math.Ceiling((tid.AntallSekunder() /
                                                        (polarData.Intervall == 238 ? 5 : polarData.Intervall)))))
                                : new Tuple<int, int>(0, 0);
                    runde.AntallSekunder = BeregnAntallSekunder(tid);
                //if (runde.AntallSekunder > 50000)
                //    runde.AntallSekunder = runde.AntallSekunder / 1000;

                if (polarData.GpxDataString != null)
                {
                    runde.GpsData = polarData.GpxDataString;
                }

                if (polarData.HrData != null && polarData.HrData.Count > 0)
                {
                    runde.HrData = HentRange(polarData.HrData, range.Item1, range.Item2);
                    if (runde.HrData.Count > 0)
                    {
                        runde.MinHjertefrekvens = runde.HrData.Min(hr => hr.HjerteFrekvens);
                        runde.SnittHjerteFrekvens = runde.HrData.Average(hr => hr.HjerteFrekvens);
                        runde.MaksHjertefrekvens = runde.HrData.Max(hr => hr.HjerteFrekvens);
                    }
                }
                else
                {
                    var tmpHeartXml = polarData.XmlTekst.Contains("</user-settings>") ? polarData.XmlTekst.Substring(polarData.XmlTekst.IndexOf("</user-settings>", StringComparison.Ordinal)) : polarData.XmlTekst;
                    runde.MaksHjertefrekvens = StringHelper.HentVerdi("<maximum>", 3, tmpHeartXml).PolarConvertToDouble();
                    runde.SnittHjerteFrekvens = StringHelper.HentVerdi("<average>", 3, tmpHeartXml).PolarConvertToDouble();
                }

                if (polarData.AltitudeData != null && polarData.AltitudeData.Count > 0) runde.AltitudeData = HentRange(polarData.AltitudeData, range.Item1, range.Item2);
                if (polarData.SpeedData != null && polarData.SpeedData.Count > 0)
                {
                    runde.SpeedData = HentRange(polarData.SpeedData, range.Item1, range.Item2);
                    runde.MaksHastighet = runde.SpeedData.Max(speed => speed.PolarConvertToDouble());
                }
                if (polarData.AntallMeter != null && polarData.AntallMeter.Count > 0) runde.AntallMeterData = HentRange(polarData.AntallMeter, range.Item1, range.Item2);
                if (polarData.CadenseData != null && polarData.CadenseData.Count > 0) runde.CadenseData = HentRange(polarData.CadenseData, range.Item1, range.Item2);
                if (polarData.PowerData != null && polarData.PowerData.Count > 0) runde.PowerData = HentRange(polarData.PowerData, range.Item1, range.Item2);

                antallIntervalPrRunde.Add(range.Item2);
                antallSekunderPrRunde.Add(tid.AntallSekunder() - antallSekunderPrRunde.Sum());
                forrigeRundetidISekunder = Convert.ToInt32(Math.Ceiling(antallSekunderPrRunde.Sum()));
                runde.StartTime = startTime.HasValue
                                      ? new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                                     startTime.Value.Hour, startTime.Value.Minute,
                                                     startTime.Value.Second)
                                      : new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                                     tid.Hour, tid.Minute,
                                                     tid.Second);
                if (polarData.GpxDataString != null)
                {
                    runde.GpsData = HentGpsRange(polarData.GpxDataString, range.Item1, range.Item2);
                    range = new Tuple<int, int>(range.Item1, runde.GpsData.Count);
                }

                var tmpResultXml = polarData.XmlTekst.Contains("</target>") ? polarData.XmlTekst.Substring(polarData.XmlTekst.IndexOf("</target>", StringComparison.Ordinal)) : polarData.XmlTekst;
                var soketekst = string.Format("<lap index=\"{0}\">", i);
                if (polarData.XmlTekst.Contains(soketekst))
                {
                    var tmpXml = polarData.XmlTekst.Substring(polarData.XmlTekst.IndexOf(soketekst, StringComparison.Ordinal));
                    runde.Distanse = StringHelper.HentVerdi("<distance>", 6, tmpXml).PolarConvertToDouble();
                }
                else
                {
                    runde.Distanse = StringHelper.HentVerdi("<distance>", 6, tmpResultXml).PolarConvertToDouble();
                }
                runde.Vekt = polarData.UserInfo.Weight;
                runde.Kalorier = tmpResultXml.Contains("<calories>")
                                     ? Convert.ToInt32(Math.Floor(Convert.ToDouble(
                                         StringHelper.HentVerdi("<calories>", 5, tmpResultXml).Replace('<', ' ').Replace
                                             ('/', ' ').Replace('c', ' ').Replace('a', ' ').Trim())))
                                     : 0;
                runde.HrmData = polarData.HrmData;
                runder.Add(runde);
                runde = new Runde();
            }
            return runder;
        }

        private static List<GPSData> HentGpsRange(List<GPSData> data, int range1, int range2)
        {
            return data.Count >= range1 ? (data.Count > range1 + range2 ? data.GetRange(range1, range2) : data.GetRange(range1, data.Count - range1)) : null;
        }

        private static List<T> HentRange<T>(List<T> data, int range1, int range2)
        {
            return data.Count > range1 ? (data.Count > range1 + range2 ? data.GetRange(range1, range2) : data.GetRange(range1, data.Count - range1)) : null;
        }

        public static List<string> VaskXmlTider(string innlestData)
        {
            var rundeTider = new List<string>();
            if (innlestData.Contains("<laps>"))
                return GetXmlLaps(innlestData, "laps");
            if (innlestData.Contains("<autolaps>"))
                return GetXmlLaps(innlestData, "autolaps");
            if (innlestData.Contains("<result>"))
                return GetXmlLap(innlestData);
            return null;
        }

        private static List<string> GetXmlLap(string innlestData)
        {
            var rundeTider = new List<string>();
            var startIndex = innlestData.IndexOf(string.Format("<{0}>", "result"), StringComparison.Ordinal);

            if (startIndex > 0)
            {
                while (
                    innlestData.Substring(startIndex, innlestData.IndexOf(string.Format("</{0}>", "result"), StringComparison.Ordinal) - startIndex).
                        Contains("<duration>"))
                {
                    var index = innlestData.Substring(startIndex).IndexOf("<duration>", StringComparison.Ordinal) +
                                startIndex + 10;
                    rundeTider.Add(
                        innlestData.Substring(index, 11).Replace('<', ' ').Replace('/', ' ').Replace('d', ' ').TrimEnd(' '));
                    startIndex = index;
                }
            }
            else
            {
                rundeTider.Add(
                    innlestData.Substring(innlestData.IndexOf("<duration>", StringComparison.Ordinal) + 10, 11).Replace('<', ' ')
                        .Replace('/', ' ').Replace('d', ' ').TrimEnd(' '));
            }

            return rundeTider;
        }

        private static List<string> GetXmlLaps(string innlestData, string lapFilter)
        {
            var rundeTider = new List<string>();
            var startIndex = innlestData.IndexOf(string.Format("<{0}>", lapFilter), StringComparison.Ordinal);

            if (startIndex > 0)
            {
                while (
                    innlestData.Substring(startIndex, innlestData.IndexOf(string.Format("</{0}>", lapFilter), StringComparison.Ordinal) - startIndex).
                        Contains("<duration>"))
                {
                    var index = innlestData.Substring(startIndex).IndexOf("<duration>", StringComparison.Ordinal) +
                                startIndex + 10;
                    rundeTider.Add(ReadDuration(innlestData, index));
                    startIndex = index;
                }
            }
            else
            {
                rundeTider.Add(
                    innlestData.Substring(innlestData.IndexOf("<duration>", StringComparison.Ordinal) + 10, 11).Replace('<', ' ')
                        .Replace('/', ' ').Replace('d', ' ').TrimEnd(' '));
            }

            return rundeTider;
        }

        private static string ReadDuration(string innlestData, int index)
        {
            var stop = innlestData.IndexOf("</dur", index, StringComparison.Ordinal);
            var result = innlestData.Substring(index, stop - index).Replace('<', ' ').Replace('/', ' ').Replace('d', ' ').TrimEnd(' ');
            if(result.Length == 5)
                return string.Format("00:{0}", result);
            return result;
        }

        private static List<Runde> CalculateIntTimes(Runde runde, PolarData polarData, DateTime? startTime, 
            int forrigeRundetidISekunder, List<double> antallIntervalPrRunde, List<double> antallSekunderPrRunde,
            double forrigeDistanser, DateTime startDate)
        {
            var runder = new List<Runde>();
            for (var i = 0; i < polarData.RundeTider.Count; i++)
            {
                if (i%28 == 0)
                {
                    var rundeTid = polarData.RundeTider[i];
                    DateTime tid;
                    if (DateTime.TryParse(rundeTid, out tid))
                    {
                        if (startTime.HasValue)
                            startTime = startTime.Value.AddSeconds(forrigeRundetidISekunder);
                        var range = new Tuple<int, int>(
                            Convert.ToInt32(Math.Ceiling(antallIntervalPrRunde.Sum())),
                            Convert.ToInt32(
                                Math.Ceiling((tid.AntallSekunder()/
                                              (polarData.Intervall == 238 ? 5 : polarData.Intervall) -
                                              antallIntervalPrRunde.Sum()))));
                        var varighet = tid.AddSeconds(antallSekunderPrRunde.Sum()*(-1));
                        runde.AntallSekunder = BeregnAntallSekunder(varighet);
                        //if (runde.AntallSekunder > 50000)
                        //    runde.AntallSekunder = runde.AntallSekunder/1000;
                        if (polarData.GpxDataString != null)
                        {
                            runde.GpsData = HentGpsRange(polarData.GpxDataString, range.Item1, range.Item2);
                            range = new Tuple<int, int>(range.Item1, runde.GpsData.Count);
                        }
                        runde.HrData = HentRange(polarData.HrData, range.Item1, range.Item2);
                        runde.AltitudeData = HentRange(polarData.AltitudeData, range.Item1, range.Item2);
                        runde.SpeedData = HentRange(polarData.SpeedData, range.Item1, range.Item2);
                        runde.AntallMeterData = HentRange(polarData.AntallMeter, range.Item1, range.Item2);
                        runde.Distanse = HentRange(polarData.AntallMeter, range.Item1, range.Item2) != null &&
                                         HentRange(polarData.AntallMeter, range.Item1, range.Item2).Count > 0
                                             ? HentRange(polarData.AntallMeter, range.Item1, range.Item2).Last() -
                                               forrigeDistanser
                                             : 0;
                        forrigeDistanser += runde.Distanse;
                        runde.CadenseData = HentRange(polarData.CadenseData, range.Item1, range.Item2);
                        runde.PowerData = HentRange(polarData.PowerData, range.Item1, range.Item2);
                        antallIntervalPrRunde.Add(range.Item2);
                        antallSekunderPrRunde.Add(tid.AntallSekunder() - antallSekunderPrRunde.Sum());
                        forrigeRundetidISekunder = Convert.ToInt32(Math.Ceiling(antallSekunderPrRunde.Last()));
                        runde.StartTime = startTime.HasValue
                                              ? new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                                             startTime.Value.Hour, startTime.Value.Minute,
                                                             startTime.Value.Second)
                                              : new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                                             tid.Hour, tid.Minute,
                                                             tid.Second);
                    }
                }
                else if (i%28 == 2)
                {
                    runde.MinHjertefrekvens = Convert.ToByte(polarData.RundeTider[i]);
                }
                else if (i%28 == 3)
                {
                    runde.SnittHjerteFrekvens = Convert.ToByte(polarData.RundeTider[i]);
                }
                else if (i%28 == 4)
                {
                    runde.MaksHjertefrekvens = Convert.ToByte(polarData.RundeTider[i]);
                }
                else if (i%28 == 17)
                {
                    //runde.Distanse = polarData.ImperiskeEnheter ? Convert.ToDouble(rundeTid) / _imperial : Convert.ToDouble(rundeTid);
                }
                else if (i%28 == 27)
                {
                    runde.Vekt = polarData.UserInfo.Weight;
                    var hrmData = polarData.HrmData;
                    runde.HrmData = hrmData;
                    int antallTabs;
                    var tripInfo = StringHelper.LesLinjer(hrmData, "[Trip]", out antallTabs);
                    if (tripInfo.Count > 0)
                        runde.MaksHastighet = Convert.ToDouble(tripInfo[6])/36;
                    runde.VO2MaxAbsolutt = StringHelper.HentVerdi("VO2max=", 2, hrmData).PolarConvertToDouble()*
                                           runde.Vekt;
                    runde.MaxHr = StringHelper.HentVerdi("MaxHR=", 3, hrmData).PolarConvertToDouble();
                    runde.HrmData = hrmData;
                    runde.VO2MaxAbsolutt = BeregnVo2MaxAbsolutt(hrmData, runde);
                    runde.MaxHr = BeregneMaxHr(hrmData);
                    runde.Kalorier = BeregnKalorier(runde);
                    runder.Add(runde);
                    runde = new Runde();
                }
            }
            return runder;
        }

        private static List<Runde> CalculateOldIntTimes(Runde runde, PolarData polarData, DateTime? startTime,
            int forrigeRundetidISekunder, List<double> antallIntervalPrRunde, List<double> antallSekunderPrRunde,
            double forrigeDistanser, DateTime startDate)
        {
            var runder = new List<Runde>();
            for (var i = 0; i < polarData.RundeTider.Count; i++)
            {
                if (i % 16 == 0)
                {
                    var rundeTid = polarData.RundeTider[i];
                    DateTime tid;
                    if (DateTime.TryParse(rundeTid, out tid))
                    {
                        if (startTime.HasValue)
                            startTime = startTime.Value.AddSeconds(forrigeRundetidISekunder);
                        var range = new Tuple<int, int>(
                            Convert.ToInt32(Math.Ceiling(antallIntervalPrRunde.Sum())),
                            Convert.ToInt32(
                                Math.Ceiling((tid.AntallSekunder() /
                                              (polarData.Intervall == 238 ? 5 : polarData.Intervall) -
                                              antallIntervalPrRunde.Sum()))));
                        var varighet = tid.AddSeconds(antallSekunderPrRunde.Sum() * (-1));
                        runde.AntallSekunder = BeregnAntallSekunder(varighet);
                        //if (runde.AntallSekunder > 50000)
                        //    runde.AntallSekunder = runde.AntallSekunder/1000;
                        if (polarData.GpxDataString != null)
                        {
                            runde.GpsData = HentGpsRange(polarData.GpxDataString, range.Item1, range.Item2);
                            range = new Tuple<int, int>(range.Item1, runde.GpsData.Count);
                        }
                        runde.HrData = HentRange(polarData.HrData, range.Item1, range.Item2);
                        runde.AltitudeData = HentRange(polarData.AltitudeData, range.Item1, range.Item2);
                        runde.SpeedData = HentRange(polarData.SpeedData, range.Item1, range.Item2);
                        runde.AntallMeterData = HentRange(polarData.AntallMeter, range.Item1, range.Item2);
                        runde.Distanse = HentRange(polarData.AntallMeter, range.Item1, range.Item2) != null &&
                                         HentRange(polarData.AntallMeter, range.Item1, range.Item2).Count > 0
                                             ? HentRange(polarData.AntallMeter, range.Item1, range.Item2).Last() -
                                               forrigeDistanser
                                             : 0;
                        forrigeDistanser += runde.Distanse;
                        runde.CadenseData = HentRange(polarData.CadenseData, range.Item1, range.Item2);
                        runde.PowerData = HentRange(polarData.PowerData, range.Item1, range.Item2);
                        antallIntervalPrRunde.Add(range.Item2);
                        antallSekunderPrRunde.Add(tid.AntallSekunder() - antallSekunderPrRunde.Sum());
                        forrigeRundetidISekunder = Convert.ToInt32(Math.Ceiling(antallSekunderPrRunde.Last()));
                        runde.StartTime = startTime.HasValue
                                              ? new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                                             startTime.Value.Hour, startTime.Value.Minute,
                                                             startTime.Value.Second)
                                              : new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                                             tid.Hour, tid.Minute,
                                                             tid.Second);
                    }
                }
                else if (i % 16 == 2)
                {
                    runde.MinHjertefrekvens = Convert.ToByte(polarData.RundeTider[i]);
                }
                else if (i % 16 == 3)
                {
                    runde.SnittHjerteFrekvens = Convert.ToByte(polarData.RundeTider[i]);
                }
                else if (i % 16 == 4)
                {
                    runde.MaksHjertefrekvens = Convert.ToByte(polarData.RundeTider[i]);
                }
                else if (i % 16 == 15)
                {
                    runde.Vekt = polarData.UserInfo.Weight;
                    var hrmData = polarData.HrmData;
                    runde.HrmData = hrmData;
                    int antallTabs;
                    var tripInfo = StringHelper.LesLinjer(hrmData, "[Trip]", out antallTabs);
                    if (tripInfo.Count > 0)
                        runde.MaksHastighet = Convert.ToDouble(tripInfo[6]) / 36;
                    runde.VO2MaxAbsolutt = StringHelper.HentVerdi("VO2max=", 2, hrmData).PolarConvertToDouble() *
                                           runde.Vekt;
                    runde.MaxHr = StringHelper.HentVerdi("MaxHR=", 3, hrmData).PolarConvertToDouble();
                    runde.HrmData = hrmData;
                    runde.VO2MaxAbsolutt = BeregnVo2MaxAbsolutt(hrmData, runde);
                    runde.MaxHr = BeregneMaxHr(hrmData);
                    runde.Kalorier = BeregnKalorier(runde);
                    runder.Add(runde);
                    runde = new Runde();
                }
            }
            return runder;
        }
    }
}
