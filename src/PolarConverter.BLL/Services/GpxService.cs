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

        public gpx ReadGpxFile(string fileReference, int timeOffset)
        {
            var xml = _blobStorageHelper.ReadXmlDocument(fileReference, typeof(gpx)) as gpx;
            return xml;
        }
    }
}
