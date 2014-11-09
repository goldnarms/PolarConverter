using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPal;
using PayPal.Api.Payments;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class PayPalService : IPaymentService
    {
        private readonly APIContext _apiContext;
        private Plan _subscriptionPlan;

        public PayPalService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public void SetupPlan()
        {
            var plan = CreateSubscription();
            var createdPlan = plan.Create(_apiContext);
            var patch = new Patch()
            {
                op = "replace",
                path = "/",
                value = new Plan { state = "ACTIVE" }
            };
            var patchRequest = new PatchRequest { patch };
            createdPlan.Update(_apiContext, patchRequest);
            _subscriptionPlan = createdPlan;
        }

        private Plan CreateSubscription()
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

        public Agreement PayForSubscription()
        {
            var payer = new Payer { payment_method = "paypal" };
            if (_subscriptionPlan!= null)
            {
                var agreement = new Agreement
                {
                    name = "Yearly subscription of Pro",
                    description = "Agreement for Pro subscription",
                    start_date = DateTime.Now.ToString("yyyy-MM-dd z"),
                    payer = payer,
                    plan = _subscriptionPlan
                };
                var createdAgreement = agreement.Create(_apiContext);
                return createdAgreement.Execute(_apiContext);
                //var response = JObject.Parse(executedPlan.ConvertToJson()).ToString(Formatting.Indented);
                //// TODO: Check if successful
                //response.
            }
            return null;
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
