using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;

namespace PolarConverter.BLL.Services
{
    public class GpxReader
    {
        public object DeserializeFile(Stream stream, Type xmlType, string xmlNamespace = "http://www.topografix.com/GPX/1/0")
        {
            XmlSerializer ser = new XmlSerializer(xmlType, xmlNamespace);
            try
            {
                return ser.Deserialize(stream);
            }
            catch (InvalidOperationException exception)
            {
				throw new Exception("There was an error converting your .gpx file. You can check and edit your .gpx file in Notepad. Check if <time>x</time> is in the format yyyy-MM-ddTHH:mm:ssZ. E.g. 2015-03-22T21:12:55Z");
					
            }

                //if (retry)
                //{
                //    // Might be because of invalid datetime, 60 minutes instead of 00, reformat and try again
                //    // Should match: 2014-06-15T11:60:03Z
                //    var sixtyMinutes = new Regex("[0-9]^4-[0-9]^2-[0-9]^2+T+[0-9]^2+/:[60]/:[0-9]^2+Z");
                //    using (var reader = new StreamReader(stream))
                //    {
                //        while (!reader.EndOfStream)
                //        {
                //            var line = reader.ReadLine();
                //            if (sixtyMinutes.IsMatch(line))
                //            {
                //                var validText = "";
                //                var firstIndexOfSixty = line.IndexOf("60");
                //                // remove time tags
                //                var tempTime = line.Replace("<time>", "").Replace("</time>", "");
                //                var validDate = string.Format("{0}{1}{2}", line.Substring(0, firstIndexOfSixty),
                //                    line.Substring(firstIndexOfSixty, 2).Replace("60", "00"),
                //                    line.Substring(firstIndexOfSixty + 2));
                //                var dateValue = validDate.ToPolarDateTime();
                //                if (dateValue.HasValue)
                //                {
                //                    validText = string.Format("<time>{0}</time>", dateValue.Value.AddHours(1));
                //                }
                //                // Update file with new values
                //            }
                //        }
                //    }
                //    // Make sure stream is updated with new values
                //    DeserializeFile(stream, xmlType, false);
                //}
                // Retry didn't work, throw exception 
        }
    }
}