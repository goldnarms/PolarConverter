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
    }
}
