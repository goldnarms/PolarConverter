using System;
using PolarConverter.BLL.Helpers;

namespace PolarConverter.BLL.Services
{
    public static class Calculators
    {
        public const double BurnrateFactor = 4.4;
        public const double AgeFactorMale = 0.2017;
        public const double AgeFactorFemale = 0.074;
        public const double WeightFactorMale = 0.1992097;
        public const double WeightFactorFemale = 0.126567385;
        public const double HeartrateFactorMale = 0.6309;
        public const double HeartrateFactorFemale = 0.4472;
        public const double SubtractFactorMale = 55.0969;
        public const double SubtractFactorFemale = 20.4022;
        public const double TimeFactor = 4.184;

        public static ushort CalulateCalories(double v02Max, double maxHr, double avgHr, double seconds)
        {
            var bpm = v02Max > 0 && maxHr > 0 ? v02Max / maxHr : 0;
            var mliterOksygenPerMinutt = avgHr * bpm;
            var literOksygenPerMinutt = mliterOksygenPerMinutt / 1000;
            var antallKalorierPerMin = literOksygenPerMinutt * BurnrateFactor;
            return Convert.ToUInt16(Math.Floor(antallKalorierPerMin * seconds / 60));
        }

        // http://fitnowtraining.com/2012/01/formula-for-calories-burned/
        public static ushort CalulateCalories(int age, double weight, double avgHr, double seconds, bool isMale)
        {
            if (isMale)
            {
                var maleResult = ((age*AgeFactorMale) + (weight*WeightFactorMale) + (HeartrateFactorMale*avgHr) -
                              (SubtractFactorMale))*seconds/TimeFactor;
                return Convert.ToUInt16(maleResult);
            }
            var femaleResult = ((age * AgeFactorFemale) + (weight * WeightFactorFemale) + (HeartrateFactorFemale * avgHr) -
                          (SubtractFactorFemale)) * seconds / TimeFactor;
            return Convert.ToUInt16(femaleResult);
        }

        public static double CalculateVo2Max(string hrmData, double weight)
        {
            return StringHelper.HentVerdi("VO2max=", 2, hrmData).PolarConvertToDouble() * weight;
        }
    }
}
