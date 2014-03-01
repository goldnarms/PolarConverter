using System.Collections.Generic;
using System.IO;
using System.Xml;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.BLL.Services
{
    public class GpxService
    {
        private BlobStorageHelper _blobStorageHelper;

        public GpxService()
        {
            _blobStorageHelper = new BlobStorageHelper("polarfiles");
        }

        public List<GPSData> ReadGpxFile(string fileReference, int timeOffset)
        {
            var gpsData = new List<GPSData>();
            var memoryStream = _blobStorageHelper.ReadXmlDocument(fileReference);
                        var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
            memoryStream.Seek(0, SeekOrigin.Begin);
            var xml = new XmlDocument();
            xml.Load(memoryStream);
            var gpx = xml.SelectSingleNode("gpx");
            var time = gpx.SelectSingleNode("time");
            var trkseg = gpx.SelectSingleNode("trk/trkseg");
            var trkpts = trkseg.SelectNodes("trkpt");
            foreach (XmlNode trkpt in trkpts)
            {
                var gpsTime = trkpt.SelectSingleNode("time").InnerText.ToPolarDateTime();

                gpsData.Add(new GPSData { Koordinater = new Koordinater(trkpt.Attributes.GetNamedItem("lat").Value, trkpt.Attributes.GetNamedItem("lon").Value), Tid = gpsTime.HasValue ? new Tid(gpsTime.Value.AddSeconds(timeOffset)) : null });
            }
            return gpsData;
        }
    }
}
