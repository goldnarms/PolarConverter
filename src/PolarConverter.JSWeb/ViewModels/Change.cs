using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolarConverter.JSWeb.ViewModels
{
    public class Change
    {
        public DateTime PublishDate { get; set; }
        public string Version { get; set; }
        public IEnumerable<string> Features { get; set; }
    }
}