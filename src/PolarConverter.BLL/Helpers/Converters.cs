using Spring.Context.Support;

namespace PolarConverter.BLL.Helpers
{
    public static class Converters
    {
        public static double HmhToKmhMultiplicationFactor = 0.1;
        public static double MphToKmhMultiplicationFactor = 0.160934;
        public static double HmhToMs = 100 / 60 / 60;
        public static double MphToMs = 160.934 / 60 / 60;
        public static double MphToKmh = 1.60934;

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
