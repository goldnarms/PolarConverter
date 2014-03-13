using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarConverter.BLL.Hjelpeklasser
{
    public static class Converters
    {
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
