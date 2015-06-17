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
        public static Extensions_t WritePowerData(Extensions_t extensions, string powerValue)
        {
			return WriteExtension(extensions, "Watts", powerValue);
		}

		public static Extensions_t WriteTemperature(Extensions_t extensions, string temperature)
		{
			return WriteExtension(extensions, "Temp", temperature);
		}

		private static Extensions_t WriteExtension(Extensions_t extensions, string type, string value)
		{
			var ns = @"http://www.garmin.com/xmlschemas/ActivityExtension/v2";
			if (extensions == null)
				extensions = new Extensions_t();
			var doc = new XmlDocument();
			var tpxElement = doc.CreateElement("TPX", ns);
			var element = doc.CreateElement(type, ns);
			element.Attributes.RemoveAll();
			element.InnerText = value;
			tpxElement.AppendChild(element);

			if (extensions.Any == null)
			{
				extensions.Any = new[] { tpxElement };
			}
			else
			{
				var extensionList = extensions.Any.ToList();
				extensionList.Add(tpxElement);
				extensions.Any = extensionList.ToArray();
			}

			return extensions;
		}
    }
}
