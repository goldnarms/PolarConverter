using System;
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

        public GpxService(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
        }

        public gpx ReadGpxFile(string fileReference, int timeOffset)
        {
            try
            {
                var xml = _storageHelper.ReadXmlDocument(fileReference, typeof(gpx)) as gpx;
                return xml;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public gpx MapGpxFile(GpxFile gpxFile, UploadViewModel model)
        {
            try
            {
                var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                return ReadGpxFile(gpxFile.Reference, timeKorreksjon);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
