using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PolarConverter.JSWeb.Models
{
    // You can add profile data for the user by adding more properties to your int  ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public double Weight { get; set; }
        //public string StravaEmail { get; set; }
        //public bool ForceGarmin { get; set; }
        public bool PreferKg { get; set; }
        public bool IsMale { get; set; }
        //public double TimeZoneOffset { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<OauthToken> OauthTokens { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}