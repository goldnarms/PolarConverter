using System;
using System.Globalization;

namespace PolarConverter.BLL.Helpers
{
    public static class DoubleExtensions
    {
        public static string ToPolarDouble(this double number)
        {
            return Math.Round(number, 1).ToString(CultureInfo.InvariantCulture).Replace(',', '.');
        }

        public static double PolarConvertToDouble(this string verdi)
        {
            double resultat;
            if (!double.TryParse(verdi, out resultat))
            {
                double.TryParse(verdi.Replace('.', ','), out resultat);
            }

            return resultat;
        }

        public static string ToPolarGraderDouble(this double grader)
        {
            var tekst = grader.ToString();
            if (grader > 370)
            {
                return string.Format("{0}.{1}", tekst.Substring(0, tekst.Length - 9), tekst.Substring(tekst.Length - 9, tekst.Length));
            }
            return tekst.Replace(',', '.');
        }
    }
}
