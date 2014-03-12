using System;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.BLL.Services
{
    public static class Calculators
    {
        public const double BURNRATEFACTOR = 4.4;

        public static ushort CalulateCalories(double v02Max, double maxHr, double avgHr, double seconds)
        {
            var bpm = v02Max > 0 && maxHr > 0 ? v02Max / maxHr : 0;
            var mliterOksygenPerMinutt = avgHr * bpm;
            var literOksygenPerMinutt = mliterOksygenPerMinutt / 1000;
            var antallKalorierPerMin = literOksygenPerMinutt * BURNRATEFACTOR;
            return Convert.ToUInt16(Math.Floor(antallKalorierPerMin * seconds / 60));
        }

        public static double CalculateVo2Max(string hrmData, double weight)
        {
            return StringHelper.HentVerdi("VO2max=", 2, hrmData).PolarConvertToDouble() * weight;
        }
    }
}
