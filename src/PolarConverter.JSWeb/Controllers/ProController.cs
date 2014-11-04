using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPal;
using PayPal.Api.Payments;

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
            if (Session["paypalAccessToken"] == null)
            {
                var config = PayPal.Manager.ConfigManager.Instance.GetProperties();
                var clientId = config[BaseConstants.ClientId];
                var clientSecret = config[BaseConstants.ClientSecret];

                var accessToken = new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken();
                Session.Add("paypalAccessToken", accessToken);
                var apiContext = new APIContext(accessToken);
                var plan = CreateYearPlan();
                System.Web.HttpContext.Current.Items.Add("RequestJSON", JObject.Parse(plan.ConvertToJson()).ToString(Formatting.Indented));
                //var createdPlan = plan.Create(apiContext);
                //System.Web.HttpContext.Current.Items.Add("ResponseJSON", JObject.Parse(createdPlan.ConvertToJson()).ToString(Formatting.Indented));
            }
            return View("Index");
        }

        private Plan CreateYearPlan()
        {
            var yearlyPlan = new PaymentDefinition
            {
                amount = GetCurrency("12"),
                frequency_interval = "1",
                frequency = "YEAR",
                cycles = "8",
                name = "Yearly plan",
                type = "REGULAR"
            };
            return new Plan
            {
                name = "Pro edition",
                description = "One year of Pro features, will continue to run unless stopped",
                type = "INFINITE",
                payment_definitions = new List<PaymentDefinition> { yearlyPlan }
            };
        }

        /// <summary>
        /// Helper method for getting a currency amount.
        /// </summary>
        /// <param name="value">The value for the currency object.</param>
        /// <returns></returns>
        private static Currency GetCurrency(string value)
        {
            return new Currency() { value = value, currency = "USD" };
        }
    }
}