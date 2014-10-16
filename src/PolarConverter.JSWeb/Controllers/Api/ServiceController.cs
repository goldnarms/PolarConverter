using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using com.strava.api.Activities;
using com.strava.api.Authentication;
using com.strava.api.Upload;
using HealthGraphNet;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PolarConverter.BLL.Interfaces;
using PolarConverter.JSWeb.Models;
using PolarConverter.JSWeb.OauthClients;
using com.strava.api;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class ServiceController : ApiController
    {
        private readonly IStorageHelper _storageHelper;

        private const string StravaUrl = "https://www.strava.com";
        private readonly string _stravaClientId;
        private AccessTokenManager _tokenManager;

        public ServiceController()
        {
            _storageHelper = DependencyResolver.Current.GetService<IStorageHelper>();
            _stravaClientId = ConfigurationManager.AppSettings["StravaClientId"];
            InitTokenManager();
        }

        public ServiceController(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _stravaClientId = ConfigurationManager.AppSettings["StravaClientId"];
            InitTokenManager();
        }

        private void InitTokenManager()
        {
            _tokenManager = new AccessTokenManager(ConfigurationManager.AppSettings["RunkeeperClientId"],
                ConfigurationManager.AppSettings["RunkeeperClientSecret"],
                "http://localhost:50713/api/service/runkeeper");
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Strava()
        {
            const string action = "/oauth/authorize";
            var uri = string.Format("{0}{1}?client_id={2}&response_type={3}&redirect_uri={4}&scope={5}&state={6}&approval_prompt={7}", StravaUrl, action, _stravaClientId, "code", "http://localhost:50713/api/service/StravaCode", "write", "connecting", "auto");
            using (var client = new HttpClient())
            {
                return Ok(await client.GetAsync(uri));
            }
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Runkeeper(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                _tokenManager.InitAccessTokenAsync(RunkeeperSuccess, Failure, code);
                return Ok();
            }
            return NotFound();
        }

        private void Failure(HealthGraphException healthGraphException)
        {
            throw new NotImplementedException();
        }

        public void RunkeeperSuccess()
        {
            var userId = User.Identity.GetUserId();
            using (var db = new ApplicationDbContext())
            {
                var oauth = new OauthToken
                {
                    ProviderType = ProviderType.Runkeeper,
                    UserId = userId,
                    Token = _tokenManager.Token.AccessToken
                };
                db.OauthTokens.Add(oauth);
                db.SaveChanges();
            }
        }

        public void StravaCode(string state, string code, string error = "")
        {
            if (string.IsNullOrEmpty(error))
            {
                const string action = "/oauth/token";
                var clientSecret = ConfigurationManager.AppSettings["StravaClientSecret"];
                using (var client = new HttpClient { BaseAddress = new Uri(StravaUrl) })
                {
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("client_id", _stravaClientId),
                        new KeyValuePair<string, string>("client_secret", clientSecret),
                        new KeyValuePair<string, string>("code", code)
                    });
                    var result = client.PostAsync(action, content).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;
                }
            }
        }

        public void StravaToken(string state, string code)
        {
            //Save code for user
            var userId = User.Identity.GetUserId();
            using (var db = new ApplicationDbContext())
            {
                db.OauthTokens.Add(new OauthToken
                {
                    ProviderType = ProviderType.Strava,
                    Token = code,
                    UserId = userId
                });
                db.SaveChanges();
            }
        }

        [System.Web.Http.Route("api/service/export")]
        public async Task<IHttpActionResult> Export(ExportFileData exportFileData)
        {
            if (string.IsNullOrEmpty(exportFileData.Reference))
                return NotFound();
            using (var db = new ApplicationDbContext())
            {
                var userToken =
                    await
                        db.OauthTokens.FirstOrDefaultAsync(
                            oa => oa.UserId == exportFileData.UserId && oa.ProviderType == ProviderType.Strava);
                if (userToken != null)
                {
                    var token = userToken.Token;
                    var auth = new StaticAuthentication(token);
                    var client = new com.strava.api.Client.StravaClient(auth);
                    var filepath = _storageHelper.DownloadFile(exportFileData.Reference, exportFileData.Name);
                    var status = await client.Uploads.UploadActivityAsync(filepath, DataFormat.Tcx);
                    //var s = await client.Uploads.CheckUploadStatusAsync(status.Id.ToString());
                    //var check = new UploadStatusCheck(token, status.Id.ToString());
                    //check.UploadChecked += (o, args) => Console.WriteLine(args.Status);
                    //check.Start();
                    return Ok();
                }
                return NotFound();
            }
        }
    }

    public class ExportFileData
    {
        public string Provider { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}
