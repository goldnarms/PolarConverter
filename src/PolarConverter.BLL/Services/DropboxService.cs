using DropNet;
using PolarConverter.BLL.Helpers;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace PolarConverter.BLL.Services
{
    public class DropboxService
    {
        private DropNetClient _client;

        public DropboxService()
        {
            _client = new DropNetClient(ConfigurationManager.AppSettings["Dropbox_Key"], ConfigurationManager.AppSettings["Dropbox_Secret"]);
            _client.UseSandbox = true;
        }

        public DropNet.Models.UserLogin GetToken()
        {
            return _client.GetToken();
        }

        public string GetAuthorizeUrl()
        {
            return _client.BuildAuthorizeUrl(ConfigurationManager.AppSettings["Dropbox_Callback"]);
        }

        public IEnumerable<DropboxResult> GetFilesForUser(DropNet.Models.UserLogin userLogin)
        {
            _client.GetToken();
            _client.UserLogin = userLogin;

            //_client.GetAccessToken();
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

        public void VerifyToken(DropNet.Models.UserLogin userLogin)
        {
            _client.UserLogin = userLogin;
        }
        public DropNet.Models.UserLogin GetUserToken(DropNet.Models.UserLogin userLogin)
        {
            _client.UserLogin = userLogin;
            return _client.GetAccessToken();
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
