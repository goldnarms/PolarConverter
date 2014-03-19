using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PolarConverter.BLL.Hjelpeklasser
{
    public static class StringHelper
    {
        public static bool ErTomEllerNull(this string tekst) { return String.IsNullOrEmpty(tekst); }
        public static DateTime? ToPolarDateTime(this string dato)
        {
            if (dato.Length > 18)
            {
                return new DateTime(
                Convert.ToInt32(dato.Substring(0, 4)), //år
                Convert.ToInt32(dato.Substring(5, 2)), //måned
                Convert.ToInt32(dato.Substring(8, 2)), //dag
                Convert.ToInt32(dato.Substring(11, 2)), //time
                Convert.ToInt32(dato.Substring(14, 2)), //minutt
                Convert.ToInt32(dato.Substring(17, 2)));
            } 
            
            return null;
        }

        public static TimeSpan ToTimeSpan(this string date)
        {
            if (date.Length >= 11)
            {
                return new TimeSpan(
                Convert.ToInt32(date.Substring(0, 2)), //hour
                Convert.ToInt32(date.Substring(3, 2)), //minutes
                Convert.ToInt32(date.Substring(6, 2)), //seconds
                Convert.ToInt32(date.Substring(9, 3)) //mm
                );
            } 
            throw new InvalidDataException("Invalid duration");            
        }

        public static DateTime? ToPolarTid(this string dato)
        {
            if (dato.Length > 9)
            {
                var tmp = dato.Replace("\r", "");
                if (tmp.IndexOf(':') == 1)
                    tmp = tmp.Insert(0, "0");
                return new DateTime(2012,1,1,
                Convert.ToInt32(tmp.Substring(0, 2)), //time
                Convert.ToInt32(tmp.Substring(3, 2)), //minutt
                Convert.ToInt32(tmp.Substring(6, 2))); //sekund
            }

            return null;
        }
        public static double ToPolarDouble(this string text)
        {
            return Convert.ToDouble(text.Replace('.', ','));
        }

        public static string Filnavnfikser(string filnavn, string brukerGuid)
        {
            return String.Format("{0}{1}.{2}", filnavn.Substring(0, filnavn.Length - 4),
                    brukerGuid,
                    filnavn.Substring(filnavn.Length - 3));
        }

        public static string Filnavnfikser(string filnavn, string brukerGuid, FilTyper filtype)
        {
            return String.Format("{0}{1}.{2}", filnavn.Substring(0, filnavn.Length - 4),
                    brukerGuid,
                    Enum.GetName(typeof(FilTyper), filtype).ToLower());
        }

        public static string Filnavnfikser(string filnavn, FilTyper filtype)
        {
            return String.Format("{0}.{1}", filnavn.Substring(0, filnavn.Length - 4),
                    Enum.GetName(typeof(FilTyper), filtype).ToLower());
        }

        public static IEnumerable<string> LesLinjer(string input)
        {
            using (var reader = new StringReader(input))
            {
                string line;
                var resultat = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Contains("\t") ? line.Substring(0, line.IndexOf('\t')) : line;
                    resultat.Add(data);
                }

                return resultat;
            }
        }

        public static List<string> LesLinjer(string input, string nokkel, out int antallTabs, bool medTabs = false)
        {
            antallTabs = 0;
            using (var reader = new StringReader(input))
            {
                string line;
                var dataFunnet = false;
                var returData = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    if (dataFunnet)
                    {
                        if (line.ErTomEllerNull())
                        {
                            break;
                        }
                        if (medTabs)
                        {
                            var data = line.Split('\t');
                            antallTabs = data.Count();
                            returData.AddRange(data);
                        }
                        else
                        {
                            var data = line.Contains("\t") ? line.Substring(0, line.IndexOf('\t')) : line;
                            returData.Add(data);
                        }
                    }

                    if (line.Contains(nokkel))
                    {
                        dataFunnet = true;
                    }
                }

                return returData;
            }
        }

        public static string HentVerdi(string key, int antallTegn, string data, int startIndex = 0)
        {
            var keyIndex = data.IndexOf(key, StringComparison.Ordinal) + startIndex;
            var totalLength = keyIndex + key.Length + antallTegn;
            return data.Length >= totalLength ? data.Substring(keyIndex + key.Length, antallTegn).Replace("\t", "") : String.Empty;
        }

        public static List<string> HentValues(string inndata, string dataType)
        {
            var startIndex = inndata.IndexOf(dataType, StringComparison.Ordinal);
            var valueIndex = startIndex + inndata.Substring(startIndex).IndexOf("<values>", StringComparison.Ordinal);
            return inndata.Substring(valueIndex + 8, inndata.Substring(valueIndex).IndexOf("</values>", StringComparison.Ordinal) - 8).Split(',').ToList();
        }

    }
}
