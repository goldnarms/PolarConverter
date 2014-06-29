using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PolarConverter.JSWeb.Models;

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

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult Files()
        {
            var frontPageModel = new FrontPageModel
            {
                BlobPath = _blobPath
            };
            return View(frontPageModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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