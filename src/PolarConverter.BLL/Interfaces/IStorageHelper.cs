using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Interfaces
{
    public interface IStorageHelper
    {
        string UploadFile(HttpPostedFile fileData);
        string SaveStream(Stream stream, string fileName, string contentType, string extension);
        string ReadFile(string fileReference);
        object ReadXmlDocument(string fileReference, Type xmlType);
        IEnumerable<string> Unzip(string fileReference);
        IEnumerable<PolarFile> GetFilesForUser(int id);
    }
}
