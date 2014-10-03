using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PolarConverter.JSWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<OauthToken> OauthTokens { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}