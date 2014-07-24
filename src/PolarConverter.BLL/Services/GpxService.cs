using System;
using System.Collections.Generic;
using System.Linq;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Entiteter.gpxver11;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class GpxService
    {
        private readonly IStorageHelper _storageHelper;

        public GpxService(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
        }

        public IGpx ReadGpxFile(string fileReference, string version, int timeOffset)
        {
            IGpx xml;
            switch (version)
            {
                case "1.0":
                    {
                        xml = _storageHelper.ReadXmlDocument(fileReference, typeof(gpx)) as gpx;
                        break;
                    }
                case "1.1":
                    {
                        xml = _storageHelper.ReadXmlDocument(fileReference, typeof(gpxType)) as gpxType;
                        break;
                    }
                default:
                    {
                        xml = _storageHelper.ReadXmlDocument(fileReference, typeof(gpx)) as gpx;
                        break;
                    }
            }
            if (xml != null)
            {
                xml.Version = version;
            }
            return xml;
        }

        public IGpx MapGpxFile(GpxFile gpxFile, double invertedOffset)
        {
            var timeKorreksjon = IntHelper.HentTidsKorreksjon(invertedOffset);
            return ReadGpxFile(gpxFile.Reference, gpxFile.Version, timeKorreksjon);
        }


        public PositionData[] CollectGpxData(PolarData polarData, DateTime startTime, int startRange, int endRange)
        {
            var startIndex = 0;
            var offsetInHours = 0;
            var positionData = new PositionData[endRange - startRange];
            switch (polarData.GpxData.Version)
            {
                case "1.0":
                    {
                        var gpx = (gpx)polarData.GpxData;
                        if (IsGpxTimeSpecified(gpx))
                        {
                            var negateOffset = polarData.InvertedOffset * -1;
                            offsetInHours = FindHourDifference(gpx.trk[0].trkseg[0].time, polarData.StartTime.AddHours(negateOffset));
                            startTime = startTime.AddHours(offsetInHours + negateOffset);
                            startIndex = FindStartIndexForGpx(gpx.trk[0], startTime, polarData.RecordingRate, startRange);
                        }
                        if (gpx.trk != null && gpx.trk.Length > 0 && endRange > 0 && endRange > startRange)
                        {
                            SetPositionDataFromGpx(gpx.trk[0].trkseg, startIndex, endRange - startRange, ref positionData, polarData.InvertedOffset, offsetInHours);
                        }
                        break;
                    }
                case "1.1":
                    {
                        var gpx = (gpxType)polarData.GpxData;
                        var combineSegments = new trksegType[gpx.trk.Sum(t => t.trkseg.Length)];
                        int destinationIndex = 0;
                        foreach (trkType t in gpx.trk)
                        {
                            var arrayLength = t.trkseg.Length;
                            Array.Copy(t.trkseg, 0, combineSegments, destinationIndex, arrayLength);
                            destinationIndex += arrayLength;
                        }
                        if (IsGpxTimeSpecified(gpx))
                        {
                            //Negate the timezoneoffset
                            var negateOffset = polarData.InvertedOffset * -1;
                            offsetInHours = FindHourDifference(gpx.trk[0].trkseg[0].trkpt[0].time, polarData.StartTime.AddHours(negateOffset));
                            startTime = startTime.AddHours(offsetInHours + negateOffset);
                            startIndex = FindStartIndexForGpx(combineSegments, startTime, polarData.RecordingRate, startRange);
                        }

                        var combinedPoints = new wptType[combineSegments.Sum(t => t.trkpt.Length)];
                        int destinationPointIndex = 0;
                        foreach (var seg in combineSegments)
                        {
                            var arrayLength = seg.trkpt.Length;
                            Array.Copy(seg.trkpt, 0, combinedPoints, destinationPointIndex, arrayLength);
                            destinationPointIndex += arrayLength;
                        }
                        if (endRange > 0 && endRange > startRange)
                        {
                            SetPositionDataFromGpx(combinedPoints, startIndex, endRange - startRange, ref positionData,
                                polarData.InvertedOffset, offsetInHours);
                        }
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }
            return positionData;
        }

        private static bool IsGpxTimeSpecified(gpxType gpx)
        {
            return gpx.trk != null && gpx.trk.Length > 0 && gpx.trk[0].trkseg != null &&
                   gpx.trk[0].trkseg.Length > 0 && gpx.trk[0].trkseg[0].trkpt != null && gpx.trk[0].trkseg[0].trkpt.Length > 0 && gpx.trk[0].trkseg[0].trkpt[0].timeSpecified;
        }

        private static bool IsGpxTimeSpecified(gpx gpx)
        {
            return gpx.trk != null && gpx.trk.Length > 0 && gpx.trk[0].trkseg != null &&
                   gpx.trk[0].trkseg.Length > 0 && gpx.trk[0].trkseg[0].timeSpecified;
        }

        private int FindHourDifference(DateTime date1, DateTime date2)
        {
            var difference = date1 - date2;
            if (difference.Minutes > 50)
            {
                if (difference.Minutes < 60)
                {
                    return Convert.ToInt32(Math.Floor(difference.TotalHours) + 1);
                }
            }
            else if (difference.Minutes < -50)
            {
                if (difference.Minutes > -60)
                {
                    return Convert.ToInt32(Math.Ceiling(difference.TotalHours) - 1);
                }
            }
            return difference.Minutes > 0 ?
                Convert.ToInt32(Math.Floor(difference.TotalHours)) :
                Convert.ToInt32(Math.Ceiling(difference.TotalHours));
        }

        private int FindStartIndexForGpx(gpxTrk gpxTrk, DateTime startTime, int recordingRate, int startIndex)
        {
            var firstGpxEntry = gpxTrk.trkseg.Skip(startIndex).FirstOrDefault(seg => seg.timeSpecified && seg.time >= startTime);
            if (firstGpxEntry != null)
            {
                // If index greater than 0, we need to ignore som gpxdata, if not, find negative index
                var index = gpxTrk.trkseg.ToList().IndexOf(firstGpxEntry);
                return index > 0 ? index : Convert.ToInt32(Math.Floor((startTime - firstGpxEntry.time).TotalSeconds / recordingRate));
            }
            return 0;
        }

        private int FindStartIndexForGpx(IEnumerable<trksegType> wptType, DateTime startTime, int recordingRate, int startIndex)
        {
            // Find the first type where time is greater than starttime
            var firstGpxEntry = wptType.Skip(startIndex).FirstOrDefault(seg => seg.trkpt.Any(t => t.timeSpecified && t.time >= startTime));
            if (firstGpxEntry != null)
            {
                // If index greater than 0, we need to ignore som gpxdata, if not, find negative index
                var index = firstGpxEntry.trkpt.ToList().FindIndex(seg => seg.timeSpecified && seg.time >= startTime);
                return index > 0 ? index : Convert.ToInt32(Math.Floor((startTime - firstGpxEntry.trkpt.First().time).TotalSeconds / recordingRate));
            }
            return 0;
        }

        private void SetPositionDataFromGpx<T>(T[] pointData, int index, int length, ref PositionData[] positionData,
            double timezoneOffset, int timeDifference) where T : ITrackPoint
        {
            //Note: ta inn index og length istede for start, end
            var gpsData = RangeHelper.GetRange(pointData, index < 0 ? 0 : index, length);
            if (gpsData == null)
            {
                return;
            }
            for (int i = 0; i < length; i++)
            {
                //var gpxIndex = i + index;
                if (i < 0)
                {
                    // Fill in firstposition
                    positionData[i] = MapPositionData(gpsData.First(), timezoneOffset, timeDifference);
                }
                else if (i < gpsData.Length)
                {
                    positionData[i] = MapPositionData(gpsData[i], timezoneOffset, timeDifference);
                }
                else
                {
                    positionData[i] = MapPositionData(gpsData.Last(), timezoneOffset, timeDifference);
                }
            }
        }

        private PositionData MapPositionData<T>(T trackPoint, double timezoneOffset, int difference) where T : ITrackPoint
        {
            var positionData = new PositionData { Lat = trackPoint.lat, Lon = trackPoint.lon };
            if (trackPoint.eleSpecified)
            {
                positionData.Altitude = trackPoint.ele;
            }
            else
            {
                positionData.Altitude = null;
            }
            if (trackPoint.timeSpecified)
            {
                positionData.Time = trackPoint.time.AddHours(difference).AddMinutes(IntHelper.HentTidsKorreksjon(timezoneOffset));
            }
            else
            {
                positionData.Time = null;
            }
            return positionData;
        }
    }
}