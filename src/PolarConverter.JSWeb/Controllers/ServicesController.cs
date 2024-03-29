﻿using System;
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
using PolarConverter.BLL.Services;
using PolarConverter.DAL.Models;

namespace PolarConverter.JSWeb.Controllers
{
    [EnableCors(origins: "https://www.strava.com", headers: "*", methods: "*")]
    public class ServicesController : Controller
    {
        private AccessTokenManager _tokenManager;
        private DropboxService _dropboxService;
        private string _stravaUrl;
        private string _stravaClientId;
        private string _runkeeperUrl;
        private string _runkeeperClientId;

        public ServicesController()
        {
            _dropboxService = new DropboxService();
            _stravaUrl = ConfigurationManager.AppSettings["StravaUrl"];
            _stravaClientId = ConfigurationManager.AppSettings["StravaClientId"];
            _runkeeperUrl = ConfigurationManager.AppSettings["RunkeeperUrl"];
            _runkeeperClientId = ConfigurationManager.AppSettings["RunkeeperClientId"];
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult ConnectToStrava()
        {
            string returnUrl = Url.Action("ExternalLoginResult", "Services", null, null, Request.Url.Host);
            const string action = "/oauth/authorize";
            var uri = string.Format("{0}{1}?client_id={2}&response_type={3}&redirect_uri={4}&scope={5}&state={6}&approval_prompt={7}", _stravaUrl, action, _stravaClientId, "code", returnUrl, "write", User.Identity.Name, "auto");

            return Redirect(uri);
        }

        [System.Web.Mvc.Authorize]
        public async Task<ActionResult> ExternalLoginResult(string state, string code, string error = "")
        {
            if (string.IsNullOrEmpty(error))
            {
                const string action = "/oauth/token";
                var clientSecret = ConfigurationManager.AppSettings["StravaClientSecret"];
                using (var client = new HttpClient { BaseAddress = new Uri(_stravaUrl) })
                {
                    var content = new Dictionary<string, string> {
                        { "client_id", _stravaClientId},
                        { "client_secret", clientSecret},
                        { "code", code}
                    };
                    var stravaResult = await client.PostAsJsonAsync(action, content);
                    var responseContent = await stravaResult.Content.ReadAsStringAsync();
                    var athleteResult = JsonConvert.DeserializeObject<Rootobject>(responseContent);

                    SaveTokenForUser(athleteResult.access_token, athleteResult.athlete.email, ProviderType.Strava);
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
            var uri = string.Format("{0}{1}?client_id={2}&response_type=code&redirect_uri={3}", _runkeeperUrl, action, _runkeeperClientId, returnUrl);

            return Redirect(uri);
        }

        public async Task<ActionResult> RunkeeperSuccess(string code, string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                string returnUrl = Url.Action("RunkeeperSuccess", "Services", null, null, Request.Url.Host);
                const string authorizeAction = "/apps/authorize";
                var redirectUri = string.Format("{0}{1}?client_id={2}&response_type=code&redirect_uri={3}", _runkeeperUrl, authorizeAction, _runkeeperClientId, returnUrl);

                const string action = "/apps/token";
                var clientSecret = ConfigurationManager.AppSettings["RunkeeperClientSecret"];
                using (var client = new HttpClient { BaseAddress = new Uri(_runkeeperUrl) })
                {
                    var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("client_id", _runkeeperClientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("redirect_uri", returnUrl)
                };
                    var formContent = new FormUrlEncodedContent(postData);

                    var response = await client.PostAsync("https://runkeeper.com/apps/token", formContent);
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RunkeeperResult>(content);
                    if (result.access_token != null)
                    {
						var tokenManager = new AccessTokenManager(_runkeeperClientId, clientSecret, returnUrl, result.access_token);
						var userRequest = new UsersEndpoint(tokenManager);
						var userResult = userRequest.GetUser();
						var profileRequest = new ProfileEndpoint(tokenManager, userResult);
						var profile = profileRequest.GetProfile();
						var profileUrl = profile.Profile;
						var startIndex = profileUrl.IndexOf("/user/") + 6;
						var username = profileUrl.Substring(startIndex, profileUrl.Length - startIndex);
						SaveTokenForUser(result.access_token, username, ProviderType.Runkeeper);
                    }
                }
            }
            return RedirectToAction("UserProfile", "Home");
        }

        public ActionResult ConnectToDropbox()
        {
            Session["UserLogin"] = _dropboxService.GetToken();
            var url = _dropboxService.GetAuthorizeUrl();
            return Redirect(url);
        }

        public ActionResult DropboxCallback(string oauth_token, string uid)
        {
            string ot = oauth_token;
            string u = uid;
            if (Session["UserLogin"] != null)
            {
                var userLogin = _dropboxService.GetUserToken(Session["UserLogin"] as DropNet.Models.UserLogin);
                Session["UserLogin"] = userLogin;

                using (var db = new ApplicationDbContext())
                {
                    var oauthToken = new OauthToken();
                    oauthToken.UserId = User.Identity.GetUserId();
                    oauthToken.ProviderType = ProviderType.Dropbox;
                    oauthToken.Token = userLogin.Token;
                    oauthToken.Secret = userLogin.Secret;
                    db.OauthTokens.Add(oauthToken);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("UserProfile", "Home");
        }

        public void DeauthRunkeeper()
        {
            // Url for deauthorizing Runkeeper
        }

        public ActionResult RemoveProvider(int id)
        {
            var providerType = (ProviderType)id;
            var userId = User.Identity.GetUserId();
            using (var db = new ApplicationDbContext())
            {
                var oauth = db.OauthTokens.FirstOrDefault(oa => oa.ProviderType == providerType && oa.UserId == userId);
                if(oauth != null)
                {
                    db.OauthTokens.Remove(oauth);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("UserProfile", "Home");
        }

        public void GetFiles()
        {
            var userId = User.Identity.GetUserId();
            using(var db = new ApplicationDbContext())
            {
                var dropboxToken = db.OauthTokens.FirstOrDefault(oa => oa.UserId == userId && oa.ProviderType == ProviderType.Dropbox);
                var userLogin = new DropNet.Models.UserLogin();
                userLogin.Token = dropboxToken.Token;
                userLogin.Secret = dropboxToken.Secret;
                _dropboxService.Init(userLogin);
                _dropboxService.GetFilesForUser();
            }
        }

        private void SaveTokenForUser(string accessToken, string username, ProviderType providerType)
        {
            using (var db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var existingToken =
                    db.OauthTokens.FirstOrDefault(
                        oa => oa.ProviderType == providerType && oa.UserId == userId);
                if (existingToken == null)
                {
                    db.OauthTokens.Add(new OauthToken
                    {
                        ProviderType = providerType,
                        UserId = userId,
						Username = username,
                        Token = accessToken
                    });
                }
                else
                {
                    existingToken.Token = accessToken;
                }
                db.SaveChanges();
            }
        }
    }
}