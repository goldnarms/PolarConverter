using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml.Serialization;
using Ionic.Zip;
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

        public LocalStorageHelper(string basePath)
        {
            _basePath = basePath;
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
                stream.CopyTo(fs);
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
            try
            {
                using (var reader = new StreamReader(fileReference))
                {
                    return ser.Deserialize(reader.BaseStream);
                }
            }
            catch (InvalidOperationException exception)
            {
                throw;
            }

        }

        public IEnumerable<string> Unzip(string fileReference)
        {
            var fileReferences = new List<string>();
            using (var zipFile = ZipFile.Read(fileReference))
            {
                foreach (ZipEntry e in zipFile)
                {
                    fileReferences.Add(e.FileName);
                    e.Extract(ExtractExistingFileAction.OverwriteSilently);
                }
            }
            return fileReferences;
        }
    }
}
