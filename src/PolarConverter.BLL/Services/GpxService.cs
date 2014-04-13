using System;
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
            try
            {
                IGpx xml;
                switch (version)
                {
                    case "1.0":
                    {
                        xml = _storageHelper.ReadXmlDocument(fileReference, typeof (gpx)) as gpx;
                        break;
                    }
                    case "1.1":
                    {
                        xml = _storageHelper.ReadXmlDocument(fileReference, typeof (gpxType)) as gpxType;
                        break;
                    }
                    default:
                    {
                        xml = _storageHelper.ReadXmlDocument(fileReference, typeof (gpx)) as gpx;
                        break;
                    }
                }
                if (xml != null)
                {
                    xml.Version = version;
                }
                return xml;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public IGpx MapGpxFile(GpxFile gpxFile, UploadViewModel model)
        {
            try
            {
                var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                return ReadGpxFile(gpxFile.Reference, gpxFile.Version, timeKorreksjon);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
