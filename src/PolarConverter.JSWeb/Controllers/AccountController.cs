using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PayPal.Api;
using PolarConverter.BLL.Services;
using PolarConverter.JSWeb.Models;
using PolarConverter.JSWeb.ViewModels;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using PolarConverter.DAL.Models;
using HealthGraphNet;

namespace PolarConverter.JSWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private PayPalService _payPalService;
        private DropboxService _dropboxService;
        private string _stravaUrl;
        private string _stravaClientId;
        private string _runkeeperUrl;
        private string _runkeeperClientId;

        public AccountController()
        {
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            _payPalService = new PayPalService(apiContext);
            _dropboxService = new DropboxService();
            _stravaUrl = ConfigurationManager.AppSettings["StravaUrl"];
            _stravaClientId = ConfigurationManager.AppSettings["StravaClientId"];
            _runkeeperUrl = ConfigurationManager.AppSettings["RunkeeperUrl"];
            _runkeeperClientId = ConfigurationManager.AppSettings["RunkeeperClientId"];
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            _payPalService = new PayPalService(apiContext);
            _dropboxService = new DropboxService();
            _stravaUrl = ConfigurationManager.AppSettings["StravaUrl"];
            _stravaClientId = ConfigurationManager.AppSettings["StravaClientId"];
            _runkeeperUrl = ConfigurationManager.AppSettings["RunkeeperUrl"];
            _runkeeperClientId = ConfigurationManager.AppSettings["RunkeeperClientId"];
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // The Authorize Action is the end point which gets called when you access any
        // protected Web API. If the user is not logged in then they will be redirected to 
        // the Login page. After a successful login you can call a Web API.
        [HttpGet]
        public ActionResult Authorize()
        {
            var claims = new ClaimsPrincipal(User).Claims.ToArray();
            var identity = new ClaimsIdentity(claims, "Bearer");
            AuthenticationManager.SignIn(identity);
            return new EmptyResult();
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    // check if user has a Pro subscription
                    var userId = User.Identity.GetUserId();
                    var today = DateTime.Today;
                    var startTime = today.AddDays(2);
                    var endTime = today.AddDays(-2);
                    using (var db = new ApplicationDbContext())
                    {
                        var hasValidSubscription = db.Subscriptions.Any(
                            s =>
                                s.UserId == userId && s.Paid == true &&
                                s.StartTime <= startTime && s.EndTime < endTime);
                        if (!hasValidSubscription)
                        {
                            AuthenticationManager.SignOut();
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult RegisterWithStrava()
        {
            string returnUrl = Url.Action("StravaResult", "Account", null, null, Request.Url.Host);
            const string action = "/oauth/authorize";
            var uri = string.Format("{0}{1}?client_id={2}&response_type={3}&redirect_uri={4}&scope={5}&state={6}&approval_prompt={7}", _stravaUrl, action, _stravaClientId, "code", returnUrl, "write", User.Identity.Name, "auto");

            return Redirect(uri);
        }

        [AllowAnonymous]
        public async Task<ActionResult> StravaResult(string state, string code, string error = "")
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
                    using(var db = new ApplicationDbContext())
                    {
                        var dbOathEntry = db.OauthTokens.Include("User").SingleOrDefault(oa => oa.Token == athleteResult.access_token && oa.ProviderType == ProviderType.Strava);
                        if(dbOathEntry != null)
                        {
                            await SignInAsync(dbOathEntry.User, false);
                            return RedirectToAction("UserProfile", "Home");
                        }
                        else
                        {
                            var user = new ApplicationUser
                            {
                                Email = athleteResult.athlete.email,
                                UserName = athleteResult.athlete.email,
                                PreferKg = athleteResult.athlete.measurement_preference == "meters",
                                IsMale = athleteResult.athlete.sex == null || (string)athleteResult.athlete.sex == "M"
                            };
                            return await CreateUser(user, athleteResult.access_token, ProviderType.Strava);
                        }
                    }
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult LoginRunkeeper() {
            string returnUrl = Url.Action("RunkeeperSuccess", "Account", null, null, Request.Url.Host);
            const string action = "/apps/authorize";
            var uri = string.Format("{0}{1}?client_id={2}&response_type=code&redirect_uri={3}", _runkeeperUrl, action, _runkeeperClientId, returnUrl);

            return Redirect(uri);
        }

        [AllowAnonymous]
        public async Task<ActionResult> RunkeeperSuccess(string code, string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                string returnUrl = Url.Action("RunkeeperSuccess", "Account", null, null, Request.Url.Host);
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
                        //SaveTokenForUser(result.access_token, ProviderType.Runkeeper);

                        var tokenManager = new AccessTokenManager(_runkeeperClientId, clientSecret, returnUrl, result.access_token);
                        var userRequest = new UsersEndpoint(tokenManager);
                        var userResult = userRequest.GetUser();
                        var profileRequest = new ProfileEndpoint(tokenManager, userResult);
                        var profile = profileRequest.GetProfile();

                        var settingsRequest = new SettingsEndpoint(tokenManager, userResult);
                        var settings = settingsRequest.GetSettings();
                        var weightRequest = new WeightEndpoint(tokenManager, userResult);
                        var weightFeed = weightRequest.GetFeedPage(pageIndex: 1, pageSize: 1);
                        var weight = weightFeed.Items.Count == 1 ? weightFeed.Items[0].Weight : null;

                        var user = new ApplicationUser
                        {
                            PreferKg = settings.WeightUnits == "kg",
                            IsMale = profile.Gender == null || profile.Gender == "M",
                            BirthDate = profile.Birthday,
                            Weight = weight
                        };
                        return await CreateUser(user, result.access_token, ProviderType.Runkeeper);
                        var name = !string.IsNullOrEmpty(profile.Name) ? profile.Name : "N/A";
                        var gender = !string.IsNullOrEmpty(profile.Gender) ? profile.Gender : "N/A";
                        var birthDate = profile.Birthday.HasValue ? profile.Birthday.Value.ToShortDateString() : "N/A";

                    }
                }
            }
            return RedirectToAction("UserProfile", "Home");
        }

        private void SaveTokenForUser(string accessToken, ProviderType providerType)
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

        private async Task<ActionResult> CreateUser(ApplicationUser user, string token, ProviderType providerType)
        {
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    SaveTokenForUser(token, providerType, user.Id);
                    await SignInAsync(user, isPersistent: false);
                    var agreementUrl = _payPalService.SetupSubscription();
                    return Redirect(agreementUrl.First());
                }
                else
                {
                    AddErrors(result);
                    return View();
                }
        }

        private void SaveTokenForUser(string accessToken, ProviderType providerType, string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var existingToken =
                    db.OauthTokens.FirstOrDefault(
                        oa => oa.ProviderType == providerType && oa.UserId == userId);
                if (existingToken == null)
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
                    existingToken.Token = accessToken;
                }
                db.SaveChanges();
            }
        }
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                DateTime bdDate;
                DateTime.TryParseExact(model.BirthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowTrailingWhite, out bdDate);

                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PreferKg = model.PreferKg,
                    BirthDate = bdDate,
                    IsMale = model.IsMale,
                    Weight = model.Weight
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    var agreementUrl = _payPalService.SetupSubscription();
                    return Redirect(agreementUrl.First());
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Cancel(string token)
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("UserProfile", "Home");
        }

        [HttpPost]
        public ActionResult AbortSubscription([System.Web.Http.FromBody]string id)
        {
            _payPalService.CancelSubscription(id);
            var userId = User.Identity.GetUserId();
            using (var db = new ApplicationDbContext())
            {
                var activeSubscription = db.Subscriptions.Where(s => s.UserId == userId && s.Paid).OrderByDescending(s => s.Id).FirstOrDefault();
                if(activeSubscription != null)
                {
                    activeSubscription.Paid = false;
                }
                db.SaveChanges();
            }
                return RedirectToAction("UserProfile", "Home");
        }

        public ActionResult OrderSubscription()
        {
            var agreementUrl = _payPalService.SetupSubscription();
            return Redirect(agreementUrl.First());
        }
        
        public ActionResult Payment(string token)
        {
            var agreement = _payPalService.ExecutePayment(token);
            DateTime startDate = DateTime.Today;
            var endDate = startDate.AddYears(1);
            var subscription = new Subscription
            {
                SubscriptionId = agreement.id,
                StartTime = startDate,
                EndTime = endDate,
                UserId = User.Identity.GetUserId(),
                Paid = true
            };
            using (var db = new ApplicationDbContext())
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
            }
            return RedirectToAction("UserProfile", "Home");
        }

        private async void GetExternalInfo(string userId)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, userId);
            if (loginInfo != null)
            {
                var result = await UserManager.AddLoginAsync(userId, loginInfo.Login);
                if (result.Succeeded)
                {
                    var currentUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    //await StoreFacebookAuthToken(currentUser);
                }
            }
        }
        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var user = await UserManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
            }
        }

        //
        // POST: /Account/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        }

        //
        // GET: /Account/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            if (result.Succeeded)
            {
                return RedirectToAction("Manage");
            }
            return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            var user = await UserManager.FindByIdAsync(await SignInManager.GetVerifiedUserIdAsync());
            if (user != null)
            {
                var code = await UserManager.GenerateTwoFactorTokenAsync(user.Id, provider);
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }


        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        [HttpGet]
        [AllowAnonymous]
        public string CurrentUserId()
        {
            return User.Identity.IsAuthenticated ? User.Identity.GetUserId() : "";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}