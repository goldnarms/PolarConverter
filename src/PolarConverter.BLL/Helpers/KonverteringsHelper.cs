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

        
    }
}
