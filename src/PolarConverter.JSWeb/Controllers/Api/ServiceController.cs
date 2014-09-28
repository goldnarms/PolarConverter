using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PolarConverter.JSWeb.Models;
using PolarConverter.JSWeb.OauthClients;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class ServiceController : ApiController
    {

        private const string StravaUrl = "https://www.strava.com";
        private string _clientId;
        private UserManager<ApplicationUser> _userManager;

        public ServiceController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public ServiceController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _clientId = ConfigurationManager.AppSettings["StravaClientId"];

            var stravaClient = new StravaOauthClient(_clientId, ConfigurationManager.AppSettings["StravaClientSecret"]);            
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
    }

    public class ExportFileData
    {
        public string Provider { get; set; }
        public string FileReference { get; set; }
    }
}
