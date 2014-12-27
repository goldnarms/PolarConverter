using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Helpers
{
    public static class DataHelper
    {
        public static Extensions_t WritePowerData(string powerValue)
        {
            var doc = new XmlDocument();
            var tpxElement = doc.CreateElement("TPX", @"http://www.garmin.com/xmlschemas/ActivityExtension/v2");
            var wattElement = doc.CreateElement("Watts");
            wattElement.InnerText = powerValue;
            tpxElement.AppendChild(wattElement);
            return new Extensions_t { Any = new[] { tpxElement } };
        }

    }
}
