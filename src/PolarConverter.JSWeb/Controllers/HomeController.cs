﻿using System.Collections.Generic;
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
using PolarConverter.JSWeb.Helpers;

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
        public async Task<ActionResult> Index()
        {
            var hasDropbox = false;
			var hasRunkeeper = false;
			var hasStrava = false;
			var runkeeperUsername = "";
            UserViewModel user = null;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                using (var context = new ApplicationDbContext())
                {
                    hasDropbox = await context.OauthTokens.AnyAsync(oa => oa.UserId == userId && oa.ProviderType == DAL.Models.ProviderType.Dropbox);
					hasRunkeeper = await context.OauthTokens.AnyAsync(oa => oa.UserId == userId && oa.ProviderType == DAL.Models.ProviderType.Runkeeper);
					hasStrava = await context.OauthTokens.AnyAsync(oa => oa.UserId == userId && oa.ProviderType == DAL.Models.ProviderType.Strava);
					runkeeperUsername = await context.OauthTokens.AnyAsync(oa => oa.UserId == userId && oa.ProviderType == DAL.Models.ProviderType.Runkeeper) ? context.OauthTokens.First(oa => oa.UserId == userId && oa.ProviderType == DAL.Models.ProviderType.Runkeeper).Username : "";
                    var applicationUser = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                    user = applicationUser != null ? MapToViewModel(applicationUser) : null;
                }
            }
                var frontPageModel = new FrontPageModel
                {
                    BlobPath = _blobPath,
                    HasDropbox = hasDropbox,
					HasRunkeeper = hasRunkeeper,
					HasStrava = hasStrava,
                    User = user,
					RunkeeperUsername = runkeeperUsername
                };
            return View(frontPageModel);
        }

        [Authorize]
        public async Task<ActionResult> UserProfile()
        {
            var userViewModel = await MappedUser();
            var timeZones = TimeZoneHelper.GetTimeZones();

            ViewBag.TimeZones = new SelectList(timeZones, "Offset", "Text");
            return View(userViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> UserProfile(UserViewModel viewModel)
        {
            var timeZones = TimeZoneHelper.GetTimeZones();

            ViewBag.TimeZones = new SelectList(timeZones, "Offset", "Text");

            if (ModelState.IsValid)
            {
                using(var context = new ApplicationDbContext())
                {
                    var userId = User.Identity.GetUserId();
                    var user = await context.Users.Include(u => u.OauthTokens)
                    .Include(u => u.Subscriptions)
                    .FirstOrDefaultAsync(u => u.Id == userId);
                    user.IsMale = viewModel.IsMale;
                    user.ForceGarmin = viewModel.ForceGarmin;
                    user.PreferKg = viewModel.PreferKg;
                    user.TimeZoneOffset = viewModel.TimezoneOffset;
                    user.Weight = viewModel.Weight;
                    user.BirthDate = viewModel.BirthDate;
                    await context.SaveChangesAsync();
                    TempData["message"] = "Changes saved.";
                    return View(MapToViewModel(user));
                }
            }
            return View(viewModel);
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

            var temp = new UserViewModel
            {
                Email = applicationUser.Email,
                BirthDate = applicationUser.BirthDate,
                IsMale = applicationUser.IsMale,
                PreferKg = applicationUser.PreferKg,
                Weight = applicationUser.Weight,
                ForceGarmin = applicationUser.ForceGarmin,
                TimezoneOffset = applicationUser.TimeZoneOffset,
                Providers = applicationUser.OauthTokens != null ? applicationUser.OauthTokens.Select(ot => new RegisteredProvider { ProviderType = ot.ProviderType, Username = ot.Username }).ToList() : null,
                ActiveSubscription = applicationUser.Subscriptions != null ? applicationUser.Subscriptions.FirstOrDefault(s => s.Paid && s.StartTime <= today && s.EndTime >= today) : null
            };

			return temp;
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
                    Answer = "Be sure to select the .gpx file in the 'Gpx file' dropdown next to 'Sport' for each activity. Note that .gpx files that match the name of the .hrm / .xml file is automatically selected."
                },
                new FrequentlyAskedQuestion
                {
                    TimeAdded = new System.DateTime(2014, 11, 15),
                    Question = "How can i upload my training files from polar flow with my v800?",
                    Answer = "As stated under Data transfer at Polar's own site: http://www.polar.com/en/products/maximize_performance/running_multisport/V800, export of files will come in september."
                },
                new FrequentlyAskedQuestion
                {
                    TimeAdded = new System.DateTime(2015, 4, 2),
                    Question = "My map file is not accepted?",
                    Answer = "Only map files ending with .gpx is accepted, if you have a file with a .gpx.xml ending, just remove .xml and try again."
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
                        PublishDate = new System.DateTime(2015, 3, 15),
                        Version = "1.1.0",
                        Features = new List<string> {
                            { "Activities with multiple laps might sometimes have a lot of data that is not part of any lap. Theese data is now assigned to a lap and converted over with the rest." },
                            { "Removing Author tag as it was causing an issue with Garmin Connect." },
                            { "Allow for large file uploads." },
                            { "Added Pro features: export to Strava and Runkeeper, integration with Dropbox and saving userprofiles and files uploaded." },
							{ "Fixed bug with .gpx files that was on one line." }
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