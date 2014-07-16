using System;
using System.Collections.Generic;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Helpers
{
    public static class RangeHelper
    {

        public static List<GPSData> HentGpsRange(List<GPSData> data, int startIndex, int length)
        {
            return data.Count >= startIndex ? (data.Count > startIndex + length ? data.GetRange(startIndex, length) : data.GetRange(startIndex, data.Count - startIndex)) : null;
        }

        public static List<T> HentRange<T>(List<T> data, int startIndex, int length)
        {
            return data.Count > startIndex ? (data.Count > startIndex + length ? data.GetRange(startIndex, length) : data.GetRange(startIndex, data.Count - startIndex)) : null;
        }

        public static T[] GetRange<T>(List<T> data, int startIndex, int length)
        {
            return data.Count > startIndex ? (data.Count > startIndex + length ? data.GetRange(startIndex, length) : data.GetRange(startIndex, data.Count - startIndex)).ToArray() : null;
        }


        // Thanks to http://stackoverflow.com/questions/943635/c-sharp-arrays-getting-a-sub-array-from-an-existing-array
        public static T[] GetRange<T>(T[] data, int startIndex, int length)
        {
            if (length > data.Length - startIndex)
                length = data.Length - startIndex;
            if (length < 1)
            {
                return null;
            }

            var result = new T[length];
            Array.Copy(data, startIndex, result, 0, length);
            return result;
        }
    }
}
