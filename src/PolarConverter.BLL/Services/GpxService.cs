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


        public PositionData[] CollectGpxData(IGpx data, string version, int startRange, int endRange, DateTime startTime, int interval)
        {
            switch (version)
            {
                case "1.0":
                    {
                        var arrayOffset = 0;
                        var gpx = (gpx)data;
                        var positionData = new PositionData[endRange - startRange];
                        if (gpx.trk != null && gpx.trk.Length > 0 && gpx.trk[0].trkseg != null &&
                            gpx.trk[0].trkseg.Length > 0 && gpx.trk[0].trkseg[0].timeSpecified)
                        {
                            var firstPosition = MapPositionData(gpx.trk[0].trkseg[0]);
                            if (firstPosition.Time.HasValue)
                            {
                                var offset = CalculateOffset(startTime, firstPosition.Time.Value, interval);
                                if (offset > 0)
                                {
                                    if (startRange < offset)
                                    {
                                        for (int i = startRange; i < offset; i++)
                                        {
                                            positionData[i] = firstPosition;
                                            arrayOffset++;
                                        }
                                    }
                                    else
                                    {
                                        startRange = startRange - offset;
                                    }
                                    endRange = endRange - offset;
                                }
                                // gpxtime is startet earlier, ignore irrelevant gpsdata
                                else if (offset < 0)
                                {
                                    startRange = startRange + offset;
                                    endRange = endRange + offset;
                                }
                            }
                        }
                        if (gpx.trk != null && gpx.trk.Length > 0)
                        {
                            SetPositionDataFromGpx(gpx.trk[0].trkseg, startRange, endRange, arrayOffset, ref positionData);
                        }
                        return positionData;
                    }
                case "1.1":
                    {
                        var arrayOffset = 0;
                        var offset = 0;
                        var gpx = (gpxType)data;
                        var combineSegments = new trksegType[gpx.trk.Sum(t => t.trkseg.Length)];
                        var positionData = new PositionData[endRange - startRange];
                        if (gpx.trk != null && gpx.trk.Length > 0 && gpx.trk[0].trkseg != null &&
    gpx.trk[0].trkseg.Length > 0 && gpx.trk[0].trkseg[0].trkpt != null && gpx.trk[0].trkseg[0].trkpt.Length > 0 && gpx.trk[0].trkseg[0].trkpt[0].timeSpecified)
                        {
                            var firstPosition = MapPositionData(gpx.trk[0].trkseg[0].trkpt[0]);
                            if (firstPosition.Time.HasValue)
                            {
                                offset = CalculateOffset(startTime, firstPosition.Time.Value, interval);
                                // if gpxtime is started later, fill inn missing gps data with data from firstposition
                                if (offset > 0)
                                {
                                    if (startRange < offset)
                                    {
                                        for (int i = startRange; i < offset; i++)
                                        {
                                            positionData[i] = firstPosition;
                                            arrayOffset++;
                                        }
                                    }
                                    else
                                    {
                                        startRange = startRange - offset;
                                    }
                                    endRange = endRange - offset;
                                }
                                // gpxtime is startet earlier, ignore irrelevant gpsdata
                                else if (offset < 0)
                                {
                                    startRange = startRange + offset;
                                    endRange = endRange + offset;
                                }
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
                        SetPositionDataFromGpx(combinedPoints, startRange, endRange, arrayOffset, ref positionData);
                        return positionData;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        private void SetPositionDataFromGpx(gpxTrkTrksegTrkpt[] pointData, int start, int end, int offset, ref PositionData[] positionData)
        {
            var gpsData = RangeHelper.GetRange(pointData, start, end);

            for (int i = 0; i < end - start; i++)
            {
                if (i >= gpsData.Length)
                {
                    positionData[i + offset] = MapPositionData(gpsData.Last());
                }
                else
                {
                    positionData[i + offset] = MapPositionData(gpsData[i]);
                }
            }
        }

        private void SetPositionDataFromGpx(wptType[] pointData, int start, int end, int offset, ref PositionData[] positionData)
        {
            var gpsData = RangeHelper.GetRange(pointData, start, end);
            for (int i = 0; i < end - start; i++)
            {
                if (i - start > gpsData.Length)
                {
                    positionData[i + offset] = MapPositionData(gpsData.Last());
                }
                else
                {
                    positionData[i + offset] = MapPositionData(gpsData[i]);
                }
            }
        }

        private int CalculateOffset(DateTime startTime, DateTime gpsTime, int interval)
        {
            var offsetSpan = gpsTime - startTime;
            var offset = (offsetSpan.TotalSeconds - offsetSpan.TotalSeconds % interval);
            offset = offset % 3600; // 
            if (offset > 2000)
                offset = offset - 3600;
            else if (offset < -2000)
                offset = offset + 3600;
            // if gpxtime is started later, fill inn missing gps data with data from firstposition
            return Convert.ToInt32(offset / interval);
        }

        private PositionData MapPositionData(gpxTrkTrksegTrkpt trackPoint)
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
                positionData.Time = trackPoint.time;
            }
            else
            {
                positionData.Time = null;
            }
            return positionData;
        }

        private PositionData MapPositionData(wptType trackPoint)
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
                positionData.Time = trackPoint.time;
            }
            else
            {
                positionData.Time = null;
            }
            return positionData;
        }
    }
}