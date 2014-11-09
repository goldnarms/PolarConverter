using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarConverter.BLL.Entiteter
{

    public class PayPalErrorMessage
    {
        public string name { get; set; }
        public string message { get; set; }
        public string information_link { get; set; }
        public string details { get; set; }
    }
}
