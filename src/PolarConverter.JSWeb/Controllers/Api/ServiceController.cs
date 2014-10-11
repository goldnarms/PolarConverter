using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using com.strava.api.Activities;
using com.strava.api.Authentication;
using com.strava.api.Upload;
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
        private string _clientId;

        public ServiceController()
        {
        }

        public ServiceController(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _clientId = ConfigurationManager.AppSettings["StravaClientId"];
        }

        [HttpGet]
        public async Task<IHttpActionResult> Strava()
        {
            const string action = "/oauth/authorize";
            var uri = string.Format("{0}{1}?client_id={2}&response_type={3}&redirect_uri={4}&scope={5}&state={6}&approval_prompt={7}", StravaUrl, action, _clientId, "code", "http://localhost:50713/api/service/StravaCode", "write", "connecting", "auto");
            using (var client = new HttpClient())
            {
                return Ok(await client.GetAsync(uri));
            }
        }

        [HttpPost]
        //[Route("api/services/post/{data}")]
        public IHttpActionResult Post([FromBody]ExportFileData data)
        {
            //Test
            return Ok();
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
                        new KeyValuePair<string, string>("client_id", _clientId),
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

        public async Task<IHttpActionResult> Export(ExportFileData exportFileData)
        {
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
                    var filepath = _storageHelper.DownloadFile(exportFileData.FileReference, exportFileData.FileName);
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
        public string FileReference { get; set; }
        public string FileName { get; set; }
        public string UserId { get; set; }
    }
}
