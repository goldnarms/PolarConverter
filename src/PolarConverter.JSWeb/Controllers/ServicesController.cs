using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private const string StravaClientId = "2995";
        private const string RunkeeperUrl = "https://runkeeper.com";
        private const string RunkeeperClientId = "aa628d46ca704d69964f19c993a25207";
        private AccessTokenManager _tokenManager;

        public ServicesController()
        {
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult ConnectToStrava()
        {
            string returnUrl = Url.Action("ExternalLoginResult", "Services", null, null, Request.Url.Host);
            const string action = "/oauth/authorize";
            var uri = string.Format("{0}{1}?client_id={2}&response_type={3}&redirect_uri={4}&scope={5}&state={6}&approval_prompt={7}", StravaUrl, action, StravaClientId, "code", returnUrl, "write", User.Identity.Name, "auto");

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
                        { "client_id", StravaClientId},
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
        public ActionResult ConnectToRunkeeper()
        {
            string returnUrl = Url.Action("RunkeeperSuccess", "Services", null, null, Request.Url.Host);
            const string action = "/apps/authorize";
            var uri = string.Format("{0}{1}?client_id={2}&response_type=code&redirect_uri={3}", RunkeeperUrl, action, RunkeeperClientId, returnUrl);

            return Redirect(uri);
        }

        public async Task<ActionResult> RunkeeperSuccess(string code, string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                string returnUrl = Url.Action("RunkeeperSuccess", "Services", null, null, Request.Url.Host);
                const string authorizeAction = "/apps/authorize";
                var redirectUri = string.Format("{0}{1}?client_id={2}&response_type=code&redirect_uri={3}", RunkeeperUrl, authorizeAction, RunkeeperClientId, returnUrl);

                const string action = "/apps/token";
                var clientSecret = ConfigurationManager.AppSettings["RunkeeperClientSecret"];
                using (var client = new HttpClient { BaseAddress = new Uri(RunkeeperUrl) })
                {
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "authorization_code"),
                        new KeyValuePair<string, string>("code", code),
                        new KeyValuePair<string, string>("client_id", RunkeeperClientId),
                        new KeyValuePair<string, string>("client_secret", clientSecret),
                        new KeyValuePair<string, string>("redirect_uri", redirectUri)
                    });
                    //content.Headers.Add(.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                    //content.Headers.ContentType.CharSet = "UTF-8";
                    var runkeeperResult = await client.PostAsJsonAsync(action, content);
                    var responsContent = await runkeeperResult.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RunkeeperResult>(responsContent);
                    SaveTokenForUser(result.access_token, ProviderType.Runkeeper);
                }
            }
            return RedirectToAction("UserProfile", "Home");
        }

        public void DeauthRunkeeper()
        {
            // Url for deauthorizing Runkeeper
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