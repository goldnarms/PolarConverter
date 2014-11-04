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

        public ActionResult Faq()
        {
            var questions = new List<FrequentlyAskedQuestion>
            {
                new FrequentlyAskedQuestion
                {
                    TimeAdded = new System.DateTime(2014, 11, 15),
                    Question = "I have attached a .gpx file, but I can’t see the track on map?",
                    Answer = "Be sure to select the .gpx file in the 'Gpx file' dropdown next to 'Sport' for each activity."
                },
                new FrequentlyAskedQuestion
                {
                    TimeAdded = new System.DateTime(2014, 11, 15),
                    Question = "How can i upload my training files from polar flow with my v800?",
                    Answer = "As stated under Data transfer at Polar's own site: http://www.polar.com/en/products/maximize_performance/running_multisport/V800, export of files will come in september."
                }
            };
            return View(questions);
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult ChangeLog()
        {
            var changes = new List<Change>
            {
                {
                    new Change {
                        PublishDate = new System.DateTime(2014, 11, 15),
                        Version = "1.1.0",
                        Features = new List<string> { { "Activities with multiple laps might sometimes have a lot of data that is not part of any lap. Theese data is now assigned to a lap and converted over with the rest." },
                            { "Removing Author tag as it was causing an issue with Garmin Connect." }
                        }
                    }
                }
            };
            return View(changes.OrderByDescending(c => c.PublishDate));
        }

        public ActionResult Donate()
        {
            return View();
        }
    }
}