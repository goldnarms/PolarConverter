using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PolarConverter.JSWeb.Models;
using PolarConverter.JSWeb.ViewModels;

namespace PolarConverter.JSWeb.Controllers
{
    public class HomeController : Controller
    {
        private string _blobPath;

        public HomeController()
        {
            _blobPath = ConfigurationManager.AppSettings["BlobPath"].Contains("http")
                ? ConfigurationManager.AppSettings["BlobPath"]
                //: AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["BlobPath"];
                : "";
        }
        public ActionResult Index()
        {
            var frontPageModel = new FrontPageModel
            {
                BlobPath = _blobPath                
            };
            return View(frontPageModel);
        }

        [Authorize]
        public async Task<ActionResult> UserProfile()
        {
            var userViewModel = await MappedUser();
            return View(userViewModel);
        }

        private async Task<UserViewModel> MappedUser()
        {
            var userId = User.Identity.GetUserId();
            using (var db = new ApplicationDbContext())
            {
                var applicationUser = await db.Users.Include(u => u.OauthTokens).FirstOrDefaultAsync(u => u.Id == userId);
                var userViewModel = MapToViewModel(applicationUser);
                return userViewModel;
            }
        }

        private UserViewModel MapToViewModel(ApplicationUser applicationUser)
        {
            return new UserViewModel
            {
                BirthDate = applicationUser.BirthDate,
                IsMale = applicationUser.IsMale,
                PreferKg = applicationUser.PreferKg,
                Weight = applicationUser.Weight,
                RegisteredProviders = applicationUser.OauthTokens.Select(ot => ot.ProviderType).ToList()
            };
        }

        [Authorize]
        public async Task<ActionResult> Files()
        {
            ViewData["BlobPath"] = _blobPath;
            var userViewModel = await MappedUser();
            return View(userViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }

    }
}