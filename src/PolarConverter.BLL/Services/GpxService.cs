using System;
using System.Linq;
using System.Net.Http.Headers;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Entiteter.gpxver11;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class GpxService
    {
        private IStorageHelper _storageHelper;

        public GpxService()
        {
            //_storageHelper = new BlobStorageHelper("polarfiles");'
            _storageHelper = new LocalStorageHelper();
        }

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

        public IGpx MapGpxFile(GpxFile gpxFile, UploadViewModel model)
        {
            var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
            return ReadGpxFile(gpxFile.Reference, gpxFile.Version, timeKorreksjon);
        }


        public PositionData[] CollectGpxData(PolarData polarData, int startRange, int endRange)
        {
            switch (polarData.GpxData.Version)
            {
                case "1.0":
                    {
                        var arrayOffset = 0;
                        var gpx = (gpx)polarData.GpxData;
                        var positionData = new PositionData[endRange - startRange];
                        if (gpx.trk != null && gpx.trk.Length > 0 && gpx.trk[0].trkseg != null &&
                            gpx.trk[0].trkseg.Length > 0 && gpx.trk[0].trkseg[0].timeSpecified)
                        {
                            var firstPosition = MapPositionData(gpx.trk[0].trkseg[0], polarData.UploadViewModel.TimeZoneOffset);
                            if (firstPosition.Time.HasValue)
                            {
                                var offset = CalculateOffset(polarData.StartTime, firstPosition.Time.Value, polarData.RecordingRate);
                                arrayOffset = AdjustForOffset(firstPosition, offset, startRange, endRange, ref positionData);
                            }
                        }
                        if (gpx.trk != null && gpx.trk.Length > 0 && endRange > 0 && endRange > startRange)
                        {
                            SetPositionDataFromGpx(gpx.trk[0].trkseg, startRange, endRange, arrayOffset, ref positionData, polarData.UploadViewModel.TimeZoneOffset);
                        }
                        return positionData;
                    }
                case "1.1":
                    {
                        var arrayOffset = 0;
                        var offset = 0;
                        var gpx = (gpxType)polarData.GpxData;
                        var combineSegments = new trksegType[gpx.trk.Sum(t => t.trkseg.Length)];
                        var positionData = new PositionData[endRange - startRange];
                        if (gpx.trk != null && gpx.trk.Length > 0 && gpx.trk[0].trkseg != null &&
    gpx.trk[0].trkseg.Length > 0 && gpx.trk[0].trkseg[0].trkpt != null && gpx.trk[0].trkseg[0].trkpt.Length > 0 && gpx.trk[0].trkseg[0].trkpt[0].timeSpecified)
                        {
                            var firstPosition = MapPositionData(gpx.trk[0].trkseg[0].trkpt[0], polarData.UploadViewModel.TimeZoneOffset);
                            if (firstPosition.Time.HasValue)
                            {
                                offset = CalculateOffset(polarData.StartTime, firstPosition.Time.Value.AddMinutes(IntHelper.HentTidsKorreksjon(polarData.UploadViewModel.TimeZoneOffset)), polarData.RecordingRate);
                                arrayOffset = AdjustForOffset(firstPosition, offset, startRange, endRange, ref positionData);
                            }
                        }
                        int destinationIndex = 0;
                        foreach (trkType t in gpx.trk)
                        {
                            var arrayLength = t.trkseg.Length;
                            Array.Copy(t.trkseg, 0, combineSegments, destinationIndex, arrayLength);
                            destinationIndex += arrayLength;
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
                            SetPositionDataFromGpx(combinedPoints, startRange, endRange, arrayOffset, ref positionData,
                                polarData.UploadViewModel.TimeZoneOffset);
                        }
                        return positionData;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        private int AdjustForOffset(PositionData firstPosition, int offset, int startRange, int endRange, ref PositionData[] positionData)
        {
            int arrayOffset = 0;
            // if gpxtime is started later, fill inn missing gps data with data from firstposition
            if (offset > 0)
            {
                arrayOffset = offset;
            }
            // gpxtime is startet earlier, ignore irrelevant gpsdata
            else if (offset < 0)
            {
                if (startRange < offset)
                {
                    for (int i = startRange; i < offset && i < positionData.Length; i++)
                    {
                        positionData[i] = firstPosition;
                    }
                }
            }
            return arrayOffset;
        }

        private void SetPositionDataFromGpx(gpxTrkTrksegTrkpt[] pointData, int start, int end, int offset, ref PositionData[] positionData, double timezoneOffset)
        {
            var gpsData = RangeHelper.GetRange(pointData, start, end);

            for (int i = 0; i < end - start; i++)
            {
                if (i + offset >= gpsData.Length)
                {
                    positionData[i + offset] = MapPositionData(gpsData.Last(), timezoneOffset);
                }
                else
                {
                    positionData[i + offset] = MapPositionData(gpsData[i], timezoneOffset);
                }
            }
        }

        private void SetPositionDataFromGpx(wptType[] pointData, int start, int end, int offset, ref PositionData[] positionData, double timezoneOffset)
        {
            var gpsData = RangeHelper.GetRange(pointData, start, end);
            for (int i = 0; i < end - start; i++)
            {
                if ((i + offset) < gpsData.Length)
                {
                    positionData[i] = MapPositionData(gpsData[i + offset], timezoneOffset);
                }
                else
                {
                    positionData[i] = MapPositionData(gpsData.Last(), timezoneOffset);
                }
            }
        }

        private int CalculateOffset(DateTime startTime, DateTime gpsTime, int interval)
        {
            var offsetSpan = startTime- gpsTime;
            var offset = (offsetSpan.TotalSeconds - offsetSpan.TotalSeconds % interval);
            offset = offset % 3600; // 
            if (offset > 2000)
                offset = offset - 3600;
            else if (offset < -2000)
                offset = offset + 3600;
            // if gpxtime is started later, fill inn missing gps data with data from firstposition
            return Convert.ToInt32(offset / interval);
        }

        private PositionData MapPositionData(gpxTrkTrksegTrkpt trackPoint, double timezoneOffset)
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
                positionData.Time = trackPoint.time.AddMinutes(IntHelper.HentTidsKorreksjon(timezoneOffset));
            }
            else
            {
                positionData.Time = null;
            }
            return positionData;
        }

        private PositionData MapPositionData(wptType trackPoint, double timezoneOffset)
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
                positionData.Time = trackPoint.time.AddMinutes(IntHelper.HentTidsKorreksjon(timezoneOffset));
            }
            else
            {
                positionData.Time = null;
            }
            return positionData;
        }
    }
}