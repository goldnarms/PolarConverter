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
            foreach (var hrmFile in model.PolarFiles.Where(pf => pf.FileType == "hrm"))
            {
                var hrmFileData = _dataMapper.MapData(hrmFile, model);
            }

            foreach (var xmlFile in model.PolarFiles.Where(pf => pf.FileType == "xml"))
            {
                var fileName = StringHelper.Filnavnfikser(xmlFile.Name, FilTyper.Tcx);
                var stream = _xmlMapper.MapData(xmlFile, model);
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
