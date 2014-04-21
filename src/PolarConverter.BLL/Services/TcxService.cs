using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Services
{
    public class TcxService
    {
        public void WriteToTcxFile(XmlPolarData xmlData)
        {
            XNamespace osgb = "http://namespaces.ordnancesurvey.co.uk/cmd/local/v1.1";
            XNamespace gml = "http://www.opengis.net/gml";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";

            var doc = new XDocument(
                new XElement(osgb + "FeatureCollection",
                   new XAttribute(XNamespace.Xmlns + "osgb", osgb),
                   new XAttribute(XNamespace.Xmlns + "gml", gml),
                   new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                   new XAttribute(xsi + "schemaLocation", "http://namespaces.ordnancesurvey.co.uk/cmd/local/v1.1 http://www.ordnancesurvey.co.uk/oswebsite/xml/cmdschema/local/V1.1/CMDFeatures.xsd"),
                   new XAttribute("fid", ""),
                   new XElement(gml + "description", "Ordnance Survey ..."),
                   new XElement(osgb + "creationDate",
                // TODO: Find a better way of doing this
                                DateTime.Today.ToString("yyyy-MM-dd"))));
            Console.WriteLine(doc);

            var settings = new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Fragment, Indent = true};
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(memoryStream, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("TrainingCenterDatabase");
                    writer.WriteAttributeString("xmlns", "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2");
                }
            }
        }
    }
}
