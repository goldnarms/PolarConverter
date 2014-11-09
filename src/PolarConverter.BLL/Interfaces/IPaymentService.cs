using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal.Api.Payments;

namespace PolarConverter.BLL.Interfaces
{
    public interface IPaymentService
    {
        void SetupPlan();
        Agreement PayForSubscription();
    }
}
