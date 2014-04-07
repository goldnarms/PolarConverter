using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.Test
{

    public static class TestHelper
    {
        private static readonly string FileRoot = ConfigurationManager.AppSettings["rootPath"];
        public static PolarFile GeneratePolarFile(string fileReference, string name, string gpxFileReference = "", string note = "test note", string sport = "biking", string fileType = "hrm")
        {
            return new PolarFile
            {
                FileType = fileType,
                Name = name,
                Note = note,
                Reference = string.Format(FileRoot + "{0}", @"EmptyFiles\11101501.hrm"),
                Sport = sport,
                GpxFile = gpxFileReference == string.Empty ? null : new GpxFile
                {
                    Name = gpxFileReference.Substring(gpxFileReference.LastIndexOf("\\", gpxFileReference.Length - 4, StringComparison.Ordinal)),
                    Reference = gpxFileReference

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
            return lap.CadenceSpecified == hasCadence && lap.Track[0].CadenceSpecified == hasCadence &&
                   lap.Track[0].AltitudeMetersSpecified == hasAltitude;
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
