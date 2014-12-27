using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal;

namespace PolarConverter.JSWeb.Helpers
{
    public static class PayPalHelper
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        // Static constructor for setting the readonly static members.
        static PayPalHelper()
        {
        }
    }
}
