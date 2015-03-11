using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Ionic.Zip;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Interfaces;
using System.Text.RegularExpressions;

namespace PolarConverter.BLL.Services
{
    public class LocalStorageHelper : IStorageHelper
    {
        private readonly string _basePath;
        private GpxReader _gpxReader;

        public LocalStorageHelper()
        {
            _basePath = AppDomain.CurrentDomain.BaseDirectory + "\\ConvertedFiles\\";
            _gpxReader = new GpxReader();
        }

        //public LocalStorageHelper(string basePath)
        //{
        //    _basePath = basePath;
        //    _gpxReader = new GpxReader();
        //}

        public string UploadFile(HttpPostedFile fileData)
        {
            return SaveStream(fileData.InputStream, fileData.FileName, fileData.ContentType, fileData.FileName.Substring(fileData.FileName.Length - 3));
        }

        public string SaveStream(Stream stream, string fileName, string contentType, string extension)
        {
            var fileReference = String.Format("{0}{1}.{2}", _basePath, Guid.NewGuid(), extension);
            //var fileReference = String.Format("{0}.{1}", Guid.NewGuid(), extension);
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
            var xmlNamespace = "";
            var xmlnamespaceRegex = new Regex("xmlns=\"([\\w:/.]*)\"");

            using (var reader = new StreamReader(fileReference))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (xmlnamespaceRegex.IsMatch(line))
                    {
                        xmlNamespace = xmlnamespaceRegex.Match(line).Groups[1].Value;
                        break;
                    }
                }
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                return _gpxReader.DeserializeFile(reader.BaseStream, xmlType, xmlNamespace);
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

        public IEnumerable<PolarFile> GetFilesForUser(int id)
        {
            var files = Directory.GetFiles(_basePath, "*.zip");
            return files.Select(f => new PolarFile
            {
                FileType = "zip",
                Name = f,
                Reference = string.Format("{0}", f)
            });
        }

        public string DownloadFile(string fileRef, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
