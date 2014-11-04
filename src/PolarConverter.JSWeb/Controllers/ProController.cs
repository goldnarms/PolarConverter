using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolarConverter.JSWeb.Controllers
{
    public class ProController : Controller
    {
        // GET: Pro
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderPro()
        {
            return View("Index");
        }
    }
}