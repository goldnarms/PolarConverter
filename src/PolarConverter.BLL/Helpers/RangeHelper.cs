using System;
using System.Collections.Generic;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Helpers
{
    public static class RangeHelper
    {

        public static List<GPSData> HentGpsRange(List<GPSData> data, int range1, int range2)
        {
            return data.Count >= range1 ? (data.Count > range1 + range2 ? data.GetRange(range1, range2) : data.GetRange(range1, data.Count - range1)) : null;
        }

        public static List<T> HentRange<T>(List<T> data, int range1, int range2)
        {
            return data.Count > range1 ? (data.Count > range1 + range2 ? data.GetRange(range1, range2) : data.GetRange(range1, data.Count - range1)) : null;
        }

        public static T[] GetRange<T>(List<T> data, int range1, int range2)
        {
            return data.Count > range1 ? (data.Count > range1 + range2 ? data.GetRange(range1, range2) : data.GetRange(range1, data.Count - range1)).ToArray() : null;
        }


        // Thanks to http://stackoverflow.com/questions/943635/c-sharp-arrays-getting-a-sub-array-from-an-existing-array
        public static T[] GetRange<T>(T[] data, int range1, int range2)
        {
            var length = range2 - range1;
            if (length > data.Length - range1)
                length = data.Length - range1;
            if (length < 1)
            {
                return null;
            }

            var result = new T[length];
            Array.Copy(data, range1, result, 0, length);
            return result;
        }
    }
}
