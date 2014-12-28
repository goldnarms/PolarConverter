using PolarConverter.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace PolarConverter.BLL.Helpers
{
    public static class FileHelper
    {
        public static void CheckForData(Stream stream, string extension, out string sport, out double v02Max, out double weight,
     out string gpxVersion)
        {
            sport = "Other";
            v02Max = 0;
            weight = 0;
            gpxVersion = "";
            if (extension == "xml")
            {
                ReadXmlFile(stream, out sport, out v02Max, out weight);
            }
            else if (extension == "hrm")
            {
                ReadHrmFile(stream, out sport, out v02Max, out weight);
            }
            else if (extension == "gpx")
            {
                ReadGpxFile(stream, out gpxVersion);
            }
        }

        public static void ReadXmlFile(Stream stream, out string sport, out double v02Max, out double weight)
        {
            sport = "Other";
            v02Max = 0;
            weight = 0;

            var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
            stream.Seek(0, SeekOrigin.Begin);
            using (var xmlReader = XmlReader.Create(stream, settings))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "type")
                    {
                        switch (xmlReader.ReadInnerXml().Trim())
                        {
                            case "CYCLING":
                                sport = "Biking";
                                break;
                            case "RUNNING":
                                sport = "Running";
                                break;
                            default:
                                sport = "Other";
                                break;
                        }
                    }
                    else if (xmlReader.Name == "vo2max")
                    {
                        v02Max = xmlReader.ReadInnerXml().Trim().ToPolarDouble();
                    }
                    else if (xmlReader.Name == "weight")
                    {
                        weight = xmlReader.ReadInnerXml().Trim().ToPolarDouble();
                    }
                    else if (xmlReader.Name == "samples")
                    {
                        break;
                    }
                }
            }
        }

        public static void ReadGpxFile(Stream stream, out string gpxVersion)
        {
            gpxVersion = "";
            stream.Seek(0, SeekOrigin.Begin);
            using (var textReader = new StreamReader(stream))
            {
                var gpxNodeHit = false;
                while (!textReader.EndOfStream)
                {
                    var line = textReader.ReadLine();
                    if (line != null)
                    {
                        if (line.Contains("gpx") && line.Contains("version="))
                        {
                            gpxVersion = ReadGpxVersion(line);
                            break;
                        }
                        if (line.Contains("gpx"))
                        {
                            gpxNodeHit = true;
                        }
                        // Can read version after xml
                        else if (gpxNodeHit && line.Contains("version="))
                        {
                            gpxVersion = ReadGpxVersion(line);
                        }
                    }
                }
            }
        }

        public static void ReadHrmFile(Stream stream, out string sport, out double v02Max, out double weight)
        {
            sport = "Other";
            v02Max = 0;
            weight = 0;

            stream.Seek(0, SeekOrigin.Begin);
            using (var textReader = new StreamReader(stream))
            {
                while (!textReader.EndOfStream)
                {
                    var line = textReader.ReadLine();
                    if (line != null)
                    {
                        if (line.Contains("VO2max"))
                        {
                            var v02result = StringHelper.HentVerdi("VO2max=", 3, line).Trim();
                            if (string.IsNullOrEmpty(v02result))
                            {
                                v02result = StringHelper.HentVerdi("VO2max=", 2, line).Trim();
                                if (string.IsNullOrEmpty(v02result))
                                {
                                    v02result = StringHelper.HentVerdi("VO2max=", 1, line).Trim();
                                }
                            }
                            if (!string.IsNullOrEmpty(v02result))
                            {
                                v02Max = v02result.ToPolarDouble();
                            }
                        }
                        if (line.Contains("Weight"))
                        {
                            var weightResult = StringHelper.HentVerdi("Weight=", 3, line).Trim();
                            if (string.IsNullOrEmpty(weightResult))
                            {
                                weightResult = StringHelper.HentVerdi("Weight=", 2, line).Trim();
                            }
                            if (!string.IsNullOrEmpty(weightResult))
                            {
                                weight = weightResult.ToPolarDouble();
                            }
                        }
                        if (line.Contains("[Trip]"))
                        {
                            sport = "Biking";
                            break;
                        }
                        // Got to far, abort
                        if (line.Contains("[HRData]"))
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static string ReadGpxVersion(string versionString)
        {
            return StringHelper.HentVerdi("version=", 5, versionString)
                .Replace("\\", "")
                .Replace("\"", "")
                .Trim();
        }

        private static int GetFileExtension(string filenName)
        {
            switch (filenName.Substring(filenName.Length - 3, 3).ToLower())
            {
                case "xml":
                    return 1;
                case "gpx":
                    return 2;
                case "hrm":
                    return 3;
                default:
                    return 0;
            }
        }
    }
}