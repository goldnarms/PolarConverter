﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PolarConverter.JSWeb.Models;
using PolarConverter.JSWeb.Providers;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Facebook;
using System.Security.Claims;
using System.Configuration;

namespace PolarConverter.JSWeb
{
    public partial class Startup
    {
        // Enable the application to use OAuthAuthorization. You can then secure your Web APIs
        public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
            PublicClientId = "web";
            UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>(new ApplicationDbContext()));

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                AuthorizeEndpointPath = new PathString("/Account/Authorize"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
        }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(20),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            app.UseFacebookAuthentication(SetupFacebookAuth());

            app.UseTwitterAuthentication(
                consumerKey: ConfigurationManager.AppSettings["TwitterKey"],
                consumerSecret: ConfigurationManager.AppSettings["TwitterSecret"]
            );

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "323230180928-b3nogpucorjpd68qnrbr67nd150flbh9.apps.googleusercontent.com",
                ClientSecret = "9x6wjqPHYz7LJvFMaMVsPkHN "
            });
        }

        private FacebookAuthenticationOptions SetupFacebookAuth()
        {
            var options = new FacebookAuthenticationOptions
            {
                AppId = ConfigurationManager.AppSettings["FacebookId"],
                AppSecret = ConfigurationManager.AppSettings["FacebookSecret"],
                AuthenticationType = "Facebook",
                SignInAsAuthenticationType = "ExternalCookie",
                Provider = new FacebookAuthenticationProvider
                {
                    OnAuthenticated = async ctx =>
                    {
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.DateOfBirth, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.Gender, ctx.User["gender"].ToString()));
                    }
                }
            };

            options.Scope.Add("user_birthday");
            return options;
        }
    }
}
