using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPal;
using PayPal.Api;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class PayPalService : IPaymentService
    {
        private APIContext _apiContext;
        private Plan _subscriptionPlan;

        public PayPalService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Plan ActivatePlan(Plan plan)
        {
            var createdPlan = plan.Create(_apiContext);
            var patchRequest = new PatchRequest
            {
                new Patch()
                {
                    op = "replace",
                    path = "/",
                    value = new Plan() { state = "ACTIVE" }
                }
            };
            createdPlan.Update(_apiContext, patchRequest);
            return createdPlan;
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
                    return_url = ConfigurationManager.AppSettings["PayPal_ReturnUrl"],
                    auto_bill_amount = "YES",
                    initial_fail_amount_action = "CONTINUE",
                    max_fail_attempts = "0"
                },
                name = "Pro edition",
                description = "One year of Pro features, will continue to run unless stopped",
                type = "INFINITE",
                payment_definitions = new List<PaymentDefinition> { yearlyPlan }
            };
        }

        public IEnumerable<string> SetupSubscription()
        {
            var agreementUrls = new List<string>();
            var payer = new Payer { payment_method = "paypal" };
            Plan plan;
            if (_subscriptionPlan != null)
            {
                plan = _subscriptionPlan;
                //var response = JObject.Parse(executedPlan.ConvertToJson()).ToString(Formatting.Indented);
                //// TODO: Check if successful
                //response.
            }
            else
            {
                var subscription = CreateSubscription();
                plan = ActivatePlan(subscription);
                _subscriptionPlan = plan;
            }
            var agreement = new Agreement
            {
                name = "Yearly subscription of Pro",
                description = "Agreement for Pro subscription",
                start_date = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddThh:mm:ssZ"),
                payer = payer,
                plan = new Plan { id = plan.id },
            };

            try
            {
                var createdAgreement = agreement.Create(_apiContext);

                var links = createdAgreement.links.GetEnumerator();

                while (links.MoveNext())
                {
                    var link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        agreementUrls.Add(link.href);
                    }
                }

            }
            catch (Exception e)
            {
                var message = e.Message;
                throw;
            }

            return agreementUrls;
        }

        public Agreement ExecutePayment(string token)
        {
            var agr = new Agreement { token = token };
            var executedAgreement = agr.Execute(_apiContext);

            return executedAgreement;
        }

        public void CancelSubscription(string agreementId)
        {
            var agr = new Agreement { id = agreementId };
            try
            {
                agr.Cancel(_apiContext, new AgreementStateDescriptor {
                    note = "Cancellation of PolarConverter Pro subscription",
                    amount = GetCurrency("12")
                });
            }
            catch (PayPalException pe)
            {
                var t = pe;
            }
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
