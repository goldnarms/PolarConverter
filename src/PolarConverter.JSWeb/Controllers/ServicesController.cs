using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using HealthGraphNet;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PolarConverter.JSWeb.Models;

namespace PolarConverter.JSWeb.Controllers
{
    [EnableCors(origins: "https://www.strava.com", headers: "*", methods: "*")]
    public class ServicesController : Controller
    {
        private const string StravaUrl = "https://www.strava.com";
        private const string ClientId = "2995";
        private AccessTokenManager _tokenManager;

        public string Code
        {
            get
            {
                return System.Web.HttpContext.Current.Request.QueryString["Code"];
            }
        }

        public ServicesController()
        {
            //InitTokenManager();
        }

        private void InitTokenManager()
        {
            _tokenManager = new AccessTokenManager(ConfigurationManager.AppSettings["RunkeeperClientId"],
                ConfigurationManager.AppSettings["RunkeeperClientSecret"],
                "http://localhost:50713/api/service/runkeeper");
        }


        // GET: Services
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult ConnectToStrava()
        {
            string returnUrl = Url.Action("ExternalLoginResult", "Services", null, null, Request.Url.Host);
            const string action = "/oauth/authorize";
            var uri = string.Format("{0}{1}?client_id={2}&response_type={3}&redirect_uri={4}&scope={5}&state={6}&approval_prompt={7}", StravaUrl, action, ClientId, "code", returnUrl, "write", User.Identity.Name, "auto");

            return Redirect(uri);
        }

        [System.Web.Mvc.Authorize]
        public async Task<ActionResult> ExternalLoginResult(string state, string code, string error = "")
        {
            if (string.IsNullOrEmpty(error))
            {
                const string action = "/oauth/token";
                var clientSecret = ConfigurationManager.AppSettings["StravaClientSecret"];
                using (var client = new HttpClient { BaseAddress = new Uri(StravaUrl) })
                {
                    var content = new Dictionary<string, string> {
                        { "client_id", ClientId},
                        { "client_secret", clientSecret},
                        { "code", code}
                    };
                    var stravaResult = await client.PostAsJsonAsync(action, content);
                    var responseContent = await stravaResult.Content.ReadAsStringAsync();
                    var athleteResult = JsonConvert.DeserializeObject<Rootobject>(responseContent);
                    SaveTokenForUser(athleteResult.access_token, ProviderType.Strava);
                }
            }
            return RedirectToAction("UserProfile", "Home");
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Http.HttpPost]
        public void ConnectToRunkeeper()
        {
            InitTokenManager();
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


        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpGet]
        public async Task<string> GetUserData()
        {
            using (var db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var userToken = db.OauthTokens.FirstOrDefault(oa => oa.UserId == userId);
                if (userToken != null)
                {
                    //var auth = new StaticAuthentication(userToken.Token);
                    //var client = new StravaClient(auth);
                    //var athlete = await client.Athletes.GetAthleteAsync();
                    //return athlete.LastName;
                }
            }

            return "";
        }

        private void SaveTokenForUser(string accessToken, ProviderType providerType)
        {
            using (var db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var existingStravaToken =
                    db.OauthTokens.FirstOrDefault(
                        oa => oa.ProviderType == ProviderType.Strava && oa.UserId == userId);
                if (existingStravaToken == null)
                {
                    db.OauthTokens.Add(new OauthToken
                    {
                        ProviderType = providerType,
                        UserId = userId,
                        Token = accessToken
                    });
                }
                else
                {
                    existingStravaToken.Token = accessToken;
                }
                db.SaveChanges();
            }
        }
    }
}