using System;
using System.IO;

namespace PolarConverter.BLL.Hjelpeklasser
{
    public static class ByteExtension
    {
        public static bool SkrivByteArrayTilFil(this byte[] bytearray, string fileName)
        {
            try
            {
                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(bytearray, 0, bytearray.Length);
                }

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}", _Exception);
            }

            return false;
        }

    }
}
