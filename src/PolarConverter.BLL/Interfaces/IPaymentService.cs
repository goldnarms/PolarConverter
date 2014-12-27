using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal.Api;

namespace PolarConverter.BLL.Interfaces
{
    public interface IPaymentService
    {
        Plan ActivatePlan(Plan plan);
        IEnumerable<string> SetupSubscription();
        Agreement ExecutePayment(string token);

        void CancelSubscription(string agreementId);
    }
}
