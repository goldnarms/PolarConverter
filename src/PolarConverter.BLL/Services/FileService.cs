using System.IO;
using PolarConverter.BLL.Entiteter;

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
