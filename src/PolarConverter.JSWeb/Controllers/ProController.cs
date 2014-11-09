using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (Session["paypalAccessToken"] == null)
            {
                var config = PayPal.Manager.ConfigManager.Instance.GetProperties();
                var clientId = config[BaseConstants.ClientId];
                var clientSecret = config[BaseConstants.ClientSecret];

                var accessToken = new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken();
                Session.Add("paypalAccessToken", accessToken);
            }
            var apiContext = new APIContext(Session["paypalAccessToken"].ToString());
            var plan = CreateYearPlan();
            System.Web.HttpContext.Current.Items.Add("RequestJSON", JObject.Parse(plan.ConvertToJson()).ToString(Formatting.Indented));
            var createdPlan = plan.Create(apiContext);
            System.Web.HttpContext.Current.Items.Add("ResponseJSON", JObject.Parse(createdPlan.ConvertToJson()).ToString(Formatting.Indented));
            return View("Index");
        }

        [HttpGet]
        public ActionResult Plans()
        {
            if (Session["paypalAccessToken"] == null)
            {
                var config = PayPal.Manager.ConfigManager.Instance.GetProperties();
                var clientId = config[BaseConstants.ClientId];
                var clientSecret = config[BaseConstants.ClientSecret];

                var accessToken = new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken();
                Session.Add("paypalAccessToken", accessToken);
            }
            var apiContext = new APIContext(Session["paypalAccessToken"].ToString());
            var planList = Plan.List(apiContext);
            if (planList != null)
            {
                var result = JObject.Parse(planList.ConvertToJson());
            }
            return View();
        }

        [HttpGet]
        public ActionResult Activate()
        {
            if (Session["paypalAccessToken"] == null)
            {
                var config = PayPal.Manager.ConfigManager.Instance.GetProperties();
                var clientId = config[BaseConstants.ClientId];
                var clientSecret = config[BaseConstants.ClientSecret];

                var accessToken = new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken();
                Session.Add("paypalAccessToken", accessToken);
            }
            var apiContext = new APIContext(Session["paypalAccessToken"].ToString());
            var planList = Plan.List(apiContext);
            var plan = planList.plans.FirstOrDefault();
            if (plan != null)
            {
                var patch = new Patch()
                {
                    op = "replace",
                    path = "/",
                    value = new Plan { state = "ACTIVE" }
                };
                var patchRequest = new PatchRequest {patch};
                plan.Update(apiContext, patchRequest);                
            }
            return View();
        }

        private Plan CreateYearPlan()
        {
            var yearlyPlan = new PaymentDefinition
            {
                amount = GetCurrency("12"),
                frequency_interval = "1",
                frequency = "YEAR",
                cycles = "0",
                name = "Yearly plan",
                type = "REGULAR"
            };
            return new Plan
            {
                merchant_preferences = new MerchantPreferences
                {
                    cancel_url = ConfigurationManager.AppSettings["PayPal_CancelUrl"],
                    return_url = ConfigurationManager.AppSettings["PayPal_ReturnUrl"]
                },
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