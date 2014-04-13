using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class LocalConversionService: IConversion
    {
        private LocalStorageHelper _storageHelper;
        private DataMapper _dataMapper;
        private XmlMapper _xmlMapper;

        public LocalConversionService()
        {
            _storageHelper = new LocalStorageHelper();
            _dataMapper = new DataMapper(_storageHelper);
            _xmlMapper = new XmlMapper(_storageHelper);

        }
        public ConversionResult Convert(UploadViewModel model)
        {
            var errorMessages = new List<string>();
            foreach (var hrmFile in model.PolarFiles.Where(pf => pf.FileType == "hrm"))
            {
                try
                {
                    var hrmFileData = _dataMapper.MapData(hrmFile, model);
                }
                catch (Exception ex)
                {
                    errorMessages.Add(ex.Message);
                }
            }

            foreach (var xmlFile in model.PolarFiles.Where(pf => pf.FileType == "xml"))
            {
                try
                {
                    var fileName = StringHelper.Filnavnfikser(xmlFile.Name, FilTyper.Tcx);
                    var stream = _xmlMapper.MapData(xmlFile, model);
                }
                catch (Exception ex)
                {
                    errorMessages.Add(ex.Message);
                }
            }
            return new ConversionResult
            {
                ErrorMessages = new List<string>(),
                FileName = "TcxFiles.zip",
                Reference = ""
            };
        }
    }
}
