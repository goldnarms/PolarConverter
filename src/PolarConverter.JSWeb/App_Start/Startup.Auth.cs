using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Owin;

namespace PolarConverter.JSWeb
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");
            var authOptions = new FacebookAuthenticationOptions();
            authOptions.Scope.Add("email");
            authOptions.Scope.Add("user_about_me");
            authOptions.Scope.Add("user_hometown");
            authOptions.AppId = "128362510636193";
            authOptions.AppSecret = "14b9e0999d5338185d26551cf09d674f";
            authOptions.Provider = new FacebookAuthenticationProvider()
            {
                OnAuthenticated = async context => context.Identity.AddClaim(
                    new System.Security.Claims.Claim("FacebookAccessToken",
                        context.AccessToken))
            };
            authOptions.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
            app.UseFacebookAuthentication(authOptions);

            app.UseGoogleAuthentication();
        }
    }
}