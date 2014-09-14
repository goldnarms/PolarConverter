using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.strava.api.Authentication;
using com.strava.api.Client;

namespace PolarConverter.JSWeb.Controllers
{
    public class ServicesController : Controller
    {
        private const string AccessToken = "38089b65e65d776e200557187ad216d6b66d389d";
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConnectToStrava()
        {
            var auth = new StaticAuthentication(AccessToken);
            var client = new StravaClient(auth);
            return View("Connected");
        }
    }
}