using System.Collections.Generic;
using System.IO;
using System.Xml;
using PolarConverter.BLL.Entiteter;
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

        public gpx ReadGpxFile(string fileReference, int timeOffset)
        {
            var xml = _storageHelper.ReadXmlDocument(fileReference, typeof(gpx)) as gpx;
            return xml;
        }

        public gpx MapGpxFile(GpxFile gpxFile, UploadViewModel model)
        {
            var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
            return ReadGpxFile(gpxFile.Reference, timeKorreksjon);
        }
    }
}
