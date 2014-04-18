using System;
using System.Configuration;
using PolarConverter.BLL.Entiteter;
using Should;

namespace PolarConverter.Test
{

    public static class TestHelper
    {
        private static readonly string FileRoot = ConfigurationManager.AppSettings["rootPath"];
        public static PolarFile GeneratePolarFile(string fileReference, string name, string gpxFileReference = "", string gpxVersion = "1.1", string note = "test note", string sport = "biking", string fileType = "hrm")
        {
            return new PolarFile
            {
                FileType = fileType,
                Name = name,
                Note = note,
                Sport = sport,
                Reference = string.Format(FileRoot + "{0}", fileReference),
                GpxFile = gpxFileReference == string.Empty ? null : new GpxFile
                {
                    //Name = string.Format(FileRoot + "{0}", gpxFileReference.Substring(gpxFileReference.LastIndexOf("\\", gpxFileReference.Length - 4, StringComparison.Ordinal))),
                    Name = gpxFileReference,
                    Reference = string.Format(FileRoot + "{0}", gpxFileReference),
                    Version = gpxVersion
                }
            };
        
}

        public static bool AssertCadAltAvgMaxStarttime(ActivityLap_t lap, byte avg, byte max, DateTime startTime,
            bool hasCadence = false, bool hasAltitude = false)
        {
            return AssertStartTimeAvgMax(lap, avg, max, startTime) &&
                   AssertCadenceAltitude(lap, hasCadence, hasAltitude);
        }

        public static bool AssertCadenceAltitude(ActivityLap_t lap, bool hasCadence = false, bool hasAltitude = false)
        {
            return lap.CadenceSpecified == hasCadence && lap.Track == null || (lap.Track != null && lap.Track.Length == 0) || (lap.Track.Length > 0 && lap.Track[0].CadenceSpecified == hasCadence &&
                   lap.Track[0].AltitudeMetersSpecified == hasAltitude);
        }

        public static bool AssertStartTimeAvgMax(ActivityLap_t lap, byte avg, byte max, DateTime startTime)
        {
            return AssertAvgAndMax(lap, avg, max) && AssertStartTime(lap, startTime);
        }
        
        public static bool AssertAvgAndMax(ActivityLap_t lap, byte avg, byte max)
        {
            return lap.AverageHeartRateBpm.Value == avg && AssertMaxHr(lap, max);
        }

        public static bool AssertMaxHr(ActivityLap_t lap, byte max)
        {
            return lap.MaximumHeartRateBpm.Value == max;
        }

        public static bool AssertStartTime(ActivityLap_t lap, DateTime startTime)
        {
            return lap.StartTime == startTime;
        }
    }
}
