using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPal;
using PolarConverter.BLL.Services;
using PolarConverter.JSWeb.Helpers;

namespace PolarConverter.JSWeb.Controllers
{
    public class ProController : Controller
    {
        private PayPalService _paypalService;

        public ProController()
        {
            //_paypalService = new PayPalService();
        }

        [HttpGet]
        public ActionResult Payment(string result)
        {

            // TODO: Update db
            // Start date, other subscription dates
            return RedirectToAction("Files", "Home");
        }

        [HttpGet]
        public ActionResult Successful()
        {

            // TODO: Update db
            // Start date, other subscription dates
            return RedirectToAction("Files", "Home");
        }

        [HttpGet]
        public ActionResult Cancel()
        {
            // TODO: Update db
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult OrderPro()
        {
            //_paypalService.SetupPlan();
            return View("Index");
        }
    }
}