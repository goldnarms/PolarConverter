using DropNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<DropboxFile> GetFilesForUser(DropNet.Models.UserLogin userLogin)
        {
            _client.GetToken();
            _client.UserLogin = userLogin;
            
            //_client.GetAccessToken();
            var baseMeta = _client.GetMetaData();
            if(!baseMeta.Contents.Any(md => md.Is_Dir && md.Name == "Upload"))
            {
                _client.CreateFolder("Upload");
            }

            if(!baseMeta.Contents.Any(md => md.Is_Dir && md.Name == "Converted"))
            {
                _client.CreateFolder("Converted");
            }
            var allowedExtensions = new List<string> { "hrm", "gpx", "xml" };
            var contents = _client.GetMetaData("/Upload").Contents.ToList();
            var length = contents.Count();
            return contents.Where(md => !md.Is_Dir && allowedExtensions.Contains(md.Extension.ToLower()))
                .Select(md => new DropboxFile{ Name = md.Name, Path = md.Path });
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
    }
}
