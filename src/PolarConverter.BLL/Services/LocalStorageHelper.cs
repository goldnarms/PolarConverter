using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class LocalStorageHelper: IStorageHelper
    {
        private string _basePath;

        public LocalStorageHelper()
        {
            _basePath = AppDomain.CurrentDomain.BaseDirectory + "ConvertedFiles\\";
        }
        public string UploadFile(HttpPostedFile fileData)
        {
            return SaveStream(fileData.InputStream, fileData.FileName, fileData.ContentType, fileData.FileName.Substring(fileData.FileName.Length - 3));
        }

        public string SaveStream(Stream stream, string fileName, string contentType, string extension)
        {
            var fileReference = String.Format("{0}{1}.{2}", _basePath, Guid.NewGuid(), extension);
            //stream.Seek(0, SeekOrigin.Begin);
            using (var fs = new FileStream(fileReference, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                fs.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
            return fileReference;

        }

        public string ReadFile(string fileReference)
        {
            using (var reader = new StreamReader(fileReference))
            {
                return reader.ReadToEnd();
            }
        }

        public object ReadXmlDocument(string fileReference, Type xmlType)
        {
            var ser = new XmlSerializer(xmlType);

            using (var reader = new StreamReader(fileReference))
            {
                return ser.Deserialize(reader.BaseStream);
            }
        }
    }
}
