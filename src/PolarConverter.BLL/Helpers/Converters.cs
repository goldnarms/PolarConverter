using Spring.Context.Support;

namespace PolarConverter.BLL.Helpers
{
    public static class Converters
    {
        public const double HmhToKmhMultiplicationFactor = 0.1;
        public const double MphToKmhMultiplicationFactor = 0.160934;
        public const double HmhToMs = 0.0277777777777778;
        public const double MphToMs = 0.0447038888888889;
        public const double MphToKmh = 1.60934;

        private static double[] ConvertToDoubleArray(string[] array)
        {
            var tmpArray = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                tmpArray[i] =
                    System.Convert.ToDouble(array[i]);
            }
            return tmpArray;
        }

        private static int[] ConvertToIntArray(string[] array)
        {
            var tmpArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                tmpArray[i] =
                    System.Convert.ToInt32(array[i]);
            }
            return tmpArray;
        }


    }
}
