using DropNet;
using PolarConverter.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using DropNet.Models;

namespace PolarConverter.BLL.Services
{
    public class DropboxService
    {
        private DropNetClient _client;
        private GpxReader _gpxReader;

        public DropboxService()
        {
            _client = new DropNetClient(ConfigurationManager.AppSettings["Dropbox_Key"], ConfigurationManager.AppSettings["Dropbox_Secret"]);
            _client.UseSandbox = true;
            _gpxReader = new GpxReader();
        }

        public void Init(UserLogin userLogin)
        {
            _client.GetToken();
            _client.UserLogin = userLogin;
        }

        public UserLogin GetToken()
        {
            return _client.GetToken();
        }

        public string GetAuthorizeUrl()
        {
            return _client.BuildAuthorizeUrl(ConfigurationManager.AppSettings["Dropbox_Callback"]);
        }

        public IEnumerable<DropboxResult> GetFilesForUser()
        {
            var baseMeta = _client.GetMetaData();
            if (!baseMeta.Contents.Any(md => md.Is_Dir && md.Name == "Upload"))
            {
                _client.CreateFolder("Upload");
            }

            if (!baseMeta.Contents.Any(md => md.Is_Dir && md.Name == "Converted"))
            {
                _client.CreateFolder("Converted");
            }
            var allowedExtensions = new List<string> { ".hrm", ".xml", ".gpx" };

            var contents = _client.GetMetaData("/Upload").Contents;

            var result = new List<DropboxResult>();
            foreach (var file in contents.Where(md => !md.Is_Dir && !md.Is_Deleted && allowedExtensions.Contains(md.Extension.ToLower())))
            {
                var sport = "";
                var v02Max = 0d;
                var weight = 0d;
                var gpxVersion = "";
                var showExtraVariables = false;
                using (MemoryStream ms = new MemoryStream(_client.GetFile(file.Path)))
                {
                    FileHelper.CheckForData(ms, file.Extension.Replace(".", ""), out sport, out v02Max, out weight, out gpxVersion);
                }
                if (v02Max < 1)
                {
                    showExtraVariables = true;
                }
                result.Add(new DropboxResult
                {
                    Name = file.Name.Substring(0, file.Name.Length - 4),
                    Reference = file.Path,
                    FileType = file.Extension.Replace(".", "").ToLower(),
                    Sport = sport,
                    ShowExtraVariables = showExtraVariables,
                    Weight = weight,
                    GpxVersion = gpxVersion
                });
            }
            return result;
        }

        public void VerifyToken(UserLogin userLogin)
        {
            _client.UserLogin = userLogin;
        }
        public UserLogin GetUserToken(UserLogin userLogin)
        {
            _client.UserLogin = userLogin;
            return _client.GetAccessToken();
        }

        public string ReadFile(string fileReference)
        {
            using (var memoryStream = new MemoryStream(_client.GetFile(fileReference)))
            {
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public object ReadXmlDocument(string fileReference, Type xmlType)
        {
            using (var memoryStream = new MemoryStream(_client.GetFile(fileReference)))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                return _gpxReader.DeserializeFile(memoryStream, xmlType);
            }
        }

        public string DownloadFile(string fileRef, string fileName)
        {

            var fileBytes = _client.GetFile(fileRef);
            var filePath = string.Format("{0}{1}", HttpContext.Current.Server.MapPath("/Upload/"), !string.IsNullOrEmpty(fileName) ? fileName + ".tcx" : fileRef);
            using (var fileStream = File.OpenWrite(filePath))
            {
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    fileStream.WriteByte(fileBytes[i]);
                }
                fileStream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    if (fileBytes[i] != fileStream.ReadByte())
                    {
                        break;
                    }
                }
            }
            return filePath;
        }

        public string UploadFile(Stream filedata, string path, string fileName)
        {
            _client.UploadFile("/" + path, fileName, filedata);
            return fileName;
        }

        public string SaveStream(Stream stream, string fileName, string contentType, string extension)
        {
            var fileReference = String.Format("{0}.{1}", Guid.NewGuid(), extension);
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                _client.UploadFile("/Converted", fileReference, ms.ToArray());
            }
            return fileReference;
        }
    }


    public class DropboxFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public GpxFileRef GpxFile { get; set; }
    }

    public class GpxFileRef
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class DropboxResult
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public string FileType { get; set; }
        public string Sport { get; set; }
        public bool ShowExtraVariables { get; set; }
        public double Weight { get; set; }
        public string GpxVersion { get; set; }
    }
}
