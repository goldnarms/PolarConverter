using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.BLL.Services
{
    public class FileService
    {
        private TcxService _tcxService;

        public FileService()
        {
            _tcxService = new TcxService();
        }

        public MemoryStream WriteToMemoryStream(PolarData data)
        {
            using (var memStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memStream))
                {
                    var dataSomSkalSkrives = _tcxService.DataSomSkalSkrives(data);
                    streamWriter.Write(dataSomSkalSkrives);
                    return memStream;
                }
            }
        }

        public MemoryStream WriteToMemoryStream(XmlPolarData data)
        {
            using (var memStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memStream))
                {
                    var dataSomSkalSkrives = _tcxService.DataSomSkalSkrives(data);
                    streamWriter.Write(dataSomSkalSkrives);
                    return memStream;
                }
            }
        }
    }
}
