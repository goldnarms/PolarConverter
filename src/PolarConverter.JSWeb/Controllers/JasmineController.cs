using System;
using System.Web.Mvc;

namespace PolarConverter.JSWeb.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
