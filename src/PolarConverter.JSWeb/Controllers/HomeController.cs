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
using System;

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
            var hasDropbox = false;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                using (var context = new ApplicationDbContext())
                {
                    hasDropbox = context.OauthTokens.Any(oa => oa.UserId == userId && oa.ProviderType == DAL.Models.ProviderType.Dropbox);
                }
            }
                var frontPageModel = new FrontPageModel
                {
                    BlobPath = _blobPath,
                    HasDropbox = hasDropbox
                };
            return View(frontPageModel);
        }

        [Authorize]
        public async Task<ActionResult> UserProfile()
        {
            var userViewModel = await MappedUser();
            var timeZones = new List<TimeZone>() {
                new TimeZone { Offset = -12, Text = "(GMT -12:00) Etc/GMT" },
                new TimeZone { Offset = -11, Text = "(GMT -11:00) Pacific/Pago_Pago" },
                new TimeZone { Offset = -10, Text = "(GMT -10:00) America/Adak" },
                new TimeZone { Offset = -10, Text = "(GMT -10:00) Pacific/Honolulu" },
                new TimeZone { Offset = -9.5, Text = "(GMT -9:30) Pacific/Marquesas" },
                new TimeZone { Offset = -9, Text = "(GMT -9:00) Pacific/Gambier" },
                new TimeZone { Offset = -9, Text = "(GMT -9:00) America/Anchorage" },
                new TimeZone { Offset = -8, Text = "(GMT -8:00) America/Los_Angeles" },
                new TimeZone { Offset = -8, Text = "(GMT -8:00) Pacific/Pitcairn" },
                new TimeZone { Offset = -7, Text = "(GMT -7:00) America/Phoenix" },
                new TimeZone { Offset = -7, Text = "(GMT -7:00) America/Denver" },
                new TimeZone { Offset = -6, Text = "(GMT -6:00) America/Guatemala" },
                new TimeZone { Offset = -6, Text = "(GMT -6:00) America/Chicago" },
                new TimeZone { Offset = -6, Text = "(GMT -6:00) Pacific/Easter" },
                new TimeZone { Offset = -5, Text = "(GMT -5:00) America/Bogota" },
                new TimeZone { Offset = -5, Text = "(GMT -5:00) America/New_York" },
                new TimeZone { Offset = -4.5, Text = "(GMT -4:30) America/Caracas" },
                new TimeZone { Offset = -4, Text = "(GMT -4:00) America/Halifax" },
                new TimeZone { Offset = -4, Text = "(GMT -4:00) America/Santo_Domingo" },
                new TimeZone { Offset = -4, Text = "(GMT -4:00) America/Asuncion" },
                new TimeZone { Offset = -3.5, Text = "(GMT -3:30) America/St_Johns" },
                new TimeZone { Offset = -3, Text = "(GMT -3:00) America/Godthab" },
                new TimeZone { Offset = -3, Text = "(GMT -3:00) America/Argentina/Buenos_Aires" },
                new TimeZone { Offset = -3, Text = "(GMT -3:00) America/Montevideo" },
                new TimeZone { Offset = -2, Text = "(GMT -2:00) America/Noronha" },
                new TimeZone { Offset = -2, Text = "(GMT -2:00) Etc/GMT+2" },
                new TimeZone { Offset = -1, Text = "(GMT -1:00) Atlantic/Azores" },
                new TimeZone { Offset = -1, Text = "(GMT -1:00) Atlantic/Cape_Verde" },
                new TimeZone { Offset = 0, Text = "(GMT 0:00) Etc/UTC" },
                new TimeZone { Offset = 0, Text = "(GMT 0:00) Europe/London" },
                new TimeZone { Offset = 1, Text = "(GMT +1:00) Europe/Berlin" },
                new TimeZone { Offset = 1, Text = "(GMT +1:00) Africa/Lagos" },
                new TimeZone { Offset = 1, Text = "(GMT +1:00) Africa/Windhoek" },
                new TimeZone { Offset = 2, Text = "(GMT +2:00) Asia/Beirut" },
                new TimeZone { Offset = 2, Text = "(GMT +2:00) Africa/Johannesburg" },
                new TimeZone { Offset = 3, Text = "(GMT +3:00) Europe/Moscow" },
                new TimeZone { Offset = 3, Text = "(GMT +3:00) Asia/Baghdad" },
                new TimeZone { Offset = 3.5, Text = "(GMT +3:30) Asia/Tehran" },
                new TimeZone { Offset = 4, Text = "(GMT +4:00) Asia/Dubai" },
                new TimeZone { Offset = 4, Text = "(GMT +4:00) Asia/Yerevan" },
                new TimeZone { Offset = 4.5, Text = "(GMT +4:30) Asia/Kabul" },
                new TimeZone { Offset = 5, Text = "(GMT +5:00) Asia/Yekaterinburg" },
                new TimeZone { Offset = 5, Text = "(GMT +5:00) Asia/Karachi" },
                new TimeZone { Offset = 5.5, Text = "(GMT +5:30) Asia/Kolkata" },
                new TimeZone { Offset = 5.75, Text = "(GMT +5:45) Asia/Kathmandu" },
                new TimeZone { Offset = 6, Text = "(GMT +6:00) Asia/Dhaka" },
                new TimeZone { Offset = 6, Text = "(GMT +6:00) Asia/Omsk" },
                new TimeZone { Offset = 6.5, Text = "(GMT +6:30) Asia/Rangoon" },
                new TimeZone { Offset = 7, Text = "(GMT +7:00) Asia/Krasnoyarsk" },
                new TimeZone { Offset = 7, Text = "(GMT +7:00) Asia/Jakarta" },
                new TimeZone { Offset = 8, Text = "(GMT +8:00) Asia/Shanghai" },
                new TimeZone { Offset = 8, Text = "(GMT +8:00) Asia/Irkutsk" },
                new TimeZone { Offset = 8.75, Text = "(GMT +8:45) Australia/Eucla" },
                new TimeZone { Offset = 8.75, Text = "(GMT +8:45) 'Australia/Eucla" },
                new TimeZone { Offset = 9, Text = "(GMT +9:00) Asia/Yakutsk" },
                new TimeZone { Offset = 9, Text = "(GMT +9:00) Asia/Tokyo" },
                new TimeZone { Offset = 9.5, Text = "(GMT +9:30) Australia/Darwin" },
                new TimeZone { Offset = 9.5, Text = "(GMT +9:30) Australia/Adelaide" },
                new TimeZone { Offset = 10, Text = "(GMT +10:00) Australia/Brisbane" },
                new TimeZone { Offset = 10, Text = "(GMT +10:00) Asia/Vladivostok" },
                new TimeZone { Offset = 10, Text = "(GMT +10:00) Australia/Sydney" },
                new TimeZone { Offset = 10.5, Text = "(GMT +10:30) Australia/Lord_Howe" },
                new TimeZone { Offset = 11, Text = "(GMT +11:00) Asia/Kamchatka" },
                new TimeZone { Offset = 11, Text = "(GMT +11:00) Pacific/Noumea" },
                new TimeZone { Offset = 11.5, Text = "(GMT +11:30) Pacific/Norfolk" },
                new TimeZone { Offset = 12, Text = "(GMT +12:00) Pacific/Auckland" },
                new TimeZone { Offset = 12, Text = "(GMT +12:00) Pacific/Tarawa" },
                new TimeZone { Offset = 12.75, Text = "(GMT +12:45) Pacific/Chatham" },
                new TimeZone { Offset = 13, Text = "(GMT +13:00) Pacific/Tongatapu" },
                new TimeZone { Offset = 13, Text = "(GMT +13:00) Pacific/Apia" },
                new TimeZone { Offset = 14, Text = "(GMT +14:00) Pacific/Kiritimati" }
            };

            ViewBag.TimeZones = new SelectList(timeZones, "Offset", "Text");
            return View(userViewModel);
        }

        private async Task<UserViewModel> MappedUser()
        {
            var userId = User.Identity.GetUserId();
            using (var db = new ApplicationDbContext())
            {
                var applicationUser = await db.Users
                    .Include(u => u.OauthTokens)
                    .Include(u => u.Subscriptions)
                    .FirstOrDefaultAsync(u => u.Id == userId);
                var userViewModel = MapToViewModel(applicationUser);

                return userViewModel;
            }
        }

        private UserViewModel MapToViewModel(ApplicationUser applicationUser)
        {
            var today = DateTime.Today;
            return new UserViewModel
            {
                Email = applicationUser.Email,
                BirthDate = applicationUser.BirthDate,
                IsMale = applicationUser.IsMale,
                PreferKg = applicationUser.PreferKg,
                Weight = applicationUser.Weight,
                RegisteredProviders = applicationUser.OauthTokens.Select(ot => ot.ProviderType).ToList(),
                ActiveSubscription = applicationUser.Subscriptions.FirstOrDefault(s => s.Paid && s.StartTime <= today && s.EndTime >= today)
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
    public class TimeZone
    {
        public double Offset { get; set; }

        public string Text { get; set; }
    }
}