using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;
using Spring.Collections;

namespace PolarConverter.BLL.Services
{
    public class TcxService
    {
        public StringBuilder DataSomSkalSkrives(PolarData data)
        {
            var dataSomSkalSkrives = new StringBuilder();
            dataSomSkalSkrives.Append(WriteHeader(data.Sport, data.StartTime));
            foreach (var lap in data.Runder)
            {
                dataSomSkalSkrives.Append(string.Format("<Lap StartTime=\"{0}\">\n", lap.StartTime.ToPolarTime()));
                dataSomSkalSkrives.Append(string.Format("<TotalTimeSeconds>{0}</TotalTimeSeconds>\n",
                                                        lap.AntallSekunder.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<DistanceMeters>{0}</DistanceMeters>\n", lap.Distanse.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<MaximumSpeed>{0}</MaximumSpeed>\n", lap.MaksHastighet.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<Calories>{0}</Calories>\n", lap.Kalorier));
                dataSomSkalSkrives.Append(string.Format("<AverageHeartRateBpm><Value>{0}</Value></AverageHeartRateBpm>\n",
                                                        lap.SnittHjerteFrekvens.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<MaximumHeartRateBpm><Value>{0}</Value></MaximumHeartRateBpm>\n",
                                                        lap.MaksHjertefrekvens.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<Intensity>{0}</Intensity>\n", lap.Intensitet));
                if (data.HarCadence)
                    dataSomSkalSkrives.Append(string.Format("<Cadence>{0}</Cadence>\n", lap.SnittCadense.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<TriggerMethod>{0}</TriggerMethod>\n", lap.TriggerMetode));
                dataSomSkalSkrives.Append("<Track>\n");
                if (lap.HrData != null)
                {
                    for (var i = 0; i < lap.HrData.Count; i++)
                    {
                        dataSomSkalSkrives.Append("<Trackpoint>\n");
                        if (lap.GpsData != null && lap.GpsData.Count >= i + 1)
                        {
                            dataSomSkalSkrives.Append(string.Format("<Time>{0}</Time>\n",
                                                                    lap.GpsData[i].Tid.Tidspunkt.ToPolarTime()));
                            dataSomSkalSkrives.Append(
                                string.Format(
                                    "<Position>\n<LatitudeDegrees>{0}</LatitudeDegrees>\n<LongitudeDegrees>{1}</LongitudeDegrees>\n</Position>\n",
                                    lap.GpsData[i].Koordinater.Latitude, lap.GpsData[i].Koordinater.Longitude));
                        }
                        else
                        {
                            dataSomSkalSkrives.Append(string.Format("<Time>{0}</Time>\n",
                                                                    lap.StartTime.AddSeconds(i *
                                                                                             (data.Intervall ==
                                                                                              238
                                                                                                  ? 5
                                                                                                  : data.
                                                                                                        Intervall))
                                                                        .ToPolarTime()));
                        }
                        if (data.HarAltitude && lap.AltitudeData != null)
                            dataSomSkalSkrives.Append(string.Format("<AltitudeMeters>{0}</AltitudeMeters>\n",
                                                                    lap.AltitudeData[i]));
                        dataSomSkalSkrives.Append(
                            string.Format("<HeartRateBpm>\n<Value>{0}</Value>\n</HeartRateBpm>\n",
                                          lap.HrData[i].HjerteFrekvens));
                        if (data.HarCadence && lap.CadenseData != null)
                            dataSomSkalSkrives.Append(string.Format("<Cadence>{0}</Cadence>\n",
                                                                    lap.CadenseData[i]));
                        if (data.HarSpeed && lap.AntallMeterData != null)
                            dataSomSkalSkrives.Append(string.Format("<DistanceMeters>{0}</DistanceMeters>\n",
                                                                    lap.AntallMeterData[i].ToPolarDouble()));
                        if (data.HarPower && lap.PowerData != null)
                            dataSomSkalSkrives.Append(
                                string.Format(
                                    "<Extensions><TPX xmlns=\"http://www.garmin.com/xmlschemas/ActivityExtension/v2\"><Watts>{0}</Watts></TPX></Extensions>\n",
                                    lap.PowerData[i].ToPolarDouble()));
                        dataSomSkalSkrives.Append("</Trackpoint>\n");
                    }
                }
                else
                {
                    if (data.Intervall == 0)
                        data.Intervall = 5;
                    for (var i = 0; i < lap.AntallSekunder / data.Intervall; i++)
                    {
                        dataSomSkalSkrives.Append("<Trackpoint>\n");
                        dataSomSkalSkrives.Append(string.Format("<Time>{0}</Time>\n",
                                                                lap.StartTime.AddSeconds(i *
                                                                                         (data.Intervall == 238
                                                                                              ? 5
                                                                                              : data.Intervall)).ToPolarTime()));
                        dataSomSkalSkrives.Append(string.Format("<HeartRateBpm>\n<Value>{0}</Value>\n</HeartRateBpm>\n",
                                                                lap.SnittHjerteFrekvens));
                        dataSomSkalSkrives.Append("</Trackpoint>\n");
                    }
                }
                dataSomSkalSkrives.Append("</Track>\n");
                dataSomSkalSkrives.Append("</Lap>\n");
            }
            dataSomSkalSkrives.Append(string.Format("<Notes>{0}</Notes>\n", data.Note));
            if (data.UserInfo.ForceGarmin)
                dataSomSkalSkrives.Append(
                    "<Creator xsi:type=\"Device_t\">\n<Name>Garmin Edge 500</Name>\n<UnitId>0</UnitId>\n<ProductID>0</ProductID>\n<Version>\n<VersionMajor>2</VersionMajor>\n<VersionMinor>60</VersionMinor>\n<BuildMajor>0</BuildMajor>\n<BuildMinor>0</BuildMinor>\n</Version>\n</Creator>\n");
            else if (PolarData.Devices.ContainsKey(data.Device))
                dataSomSkalSkrives.Append(
                    string.Format(
                        "<Creator xsi:type=\"Device_t\">\n<Name>{0}</Name>\n<UnitId>0</UnitId>\n<ProductID>0</ProductID>\n<Version>\n<BuildMajor>0</BuildMajor>\n<BuildMinor>0</BuildMinor>\n</Version>\n</Creator>\n",
                        PolarData.Devices[data.Device]));
            dataSomSkalSkrives.Append("</Activity>\n");
            dataSomSkalSkrives.Append("</Activities>\n");

            dataSomSkalSkrives.Append("</TrainingCenterDatabase>");
            return dataSomSkalSkrives;
        }
        public StringBuilder DataSomSkalSkrives(XmlPolarData data)
        {
            var intervall = data.RecordingRate == 238 ? 5 : data.RecordingRate == 0 ? 5 : data.RecordingRate;
            var dataSomSkalSkrives = new StringBuilder();
            dataSomSkalSkrives.Append(WriteHeader(data.Sport, data.StartTime));
            foreach (var lap in data.Laps)
            {
                dataSomSkalSkrives.Append(string.Format("<Lap StartTime=\"{0}\">\n", lap.StartTime.ToPolarTime()));
                dataSomSkalSkrives.Append(string.Format("<TotalTimeSeconds>{0}</TotalTimeSeconds>\n",
                                                        lap.AntallSekunder.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<DistanceMeters>{0}</DistanceMeters>\n", lap.Distanse.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<MaximumSpeed>{0}</MaximumSpeed>\n", lap.MaksHastighet.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<Calories>{0}</Calories>\n", lap.Kalorier));
                dataSomSkalSkrives.Append(string.Format("<AverageHeartRateBpm><Value>{0}</Value></AverageHeartRateBpm>\n",
                                                        lap.SnittHjerteFrekvens.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<MaximumHeartRateBpm><Value>{0}</Value></MaximumHeartRateBpm>\n",
                                                        lap.MaksHjertefrekvens.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<Intensity>{0}</Intensity>\n", lap.Intensitet));
                if (data.AvgCadence.HasValue)
                    dataSomSkalSkrives.Append(string.Format("<Cadence>{0}</Cadence>\n", data.AvgCadence.Value.ToPolarDouble()));
                dataSomSkalSkrives.Append(string.Format("<TriggerMethod>{0}</TriggerMethod>\n", lap.TriggerMetode));
                dataSomSkalSkrives.Append("<Track>\n");

                if (data.LapTimes != null)
                {
                    var k = 0;
                    for (var i = 0; i < data.LapTimes.Count; i++)
                    {

                        for (var j = 0; j < data.LapTimes[i].TotalSeconds / intervall; j++)
                        {
                            dataSomSkalSkrives.Append("<Trackpoint>\n");
                            if (lap.GpsData != null && lap.GpsData.Count >= i + 1)
                            {
                                dataSomSkalSkrives.Append(string.Format("<Time>{0}</Time>\n",
                                    lap.GpsData[k].Tid.Tidspunkt.ToPolarTime()));
                                dataSomSkalSkrives.Append(
                                    string.Format(
                                        "<Position>\n<LatitudeDegrees>{0}</LatitudeDegrees>\n<LongitudeDegrees>{1}</LongitudeDegrees>\n</Position>\n",
                                        lap.GpsData[k].Koordinater.Latitude, lap.GpsData[k].Koordinater.Longitude));
                            }
                            else
                            {
                                dataSomSkalSkrives.Append(string.Format("<Time>{0}</Time>\n",
                                    lap.StartTime.AddSeconds(k * intervall)
                                        .ToPolarTime()));
                            }
                            if (data.Altitude != null && data.Altitude.Count() > 0)
                            {
                                dataSomSkalSkrives.Append(string.Format("<AltitudeMeters>{0}</AltitudeMeters>\n",
                                    data.Altitude[k].ToPolarDouble()));
                            }
                            else if (data.AvgAltitude.HasValue)
                            {
                                dataSomSkalSkrives.Append(string.Format("<AltitudeMeters>{0}</AltitudeMeters>\n",
                                    data.AvgAltitude.Value.ToPolarDouble()));
                            }
                            if (data.Cadence != null && data.Cadence.Length > 0)
                            {
                                dataSomSkalSkrives.Append(string.Format("<Cadence>{0}</Cadence>\n",
                                    data.Cadence[k]));
                            }
                            else if (data.AvgCadence.HasValue)
                            {
                                dataSomSkalSkrives.Append(
                                    string.Format("<Cadence>{0}</Cadence>\n",
                                        data.AvgCadence.Value));
                            }
                            if (data.Speed != null && data.Speed.Length > 0)
                            {
                                dataSomSkalSkrives.Append(string.Format("<DistanceMeters>{0}</DistanceMeters>\n",
                                    CalculateMetersTraveled(data.Speed[k], lap.Distanse).ToPolarDouble()));
                            }
                            if (data.Power != null && data.Power.Length > 0)
                            {
                                dataSomSkalSkrives.Append(
                                    string.Format(
                                        "<Extensions><TPX xmlns=\"http://www.garmin.com/xmlschemas/ActivityExtension/v2\"><Watts>{0}</Watts></TPX></Extensions>\n",
                                        data.Power[j].ToPolarDouble()));
                            }
                            else if (data.AvgPower.HasValue)
                            {
                                dataSomSkalSkrives.Append(
                                    string.Format(
                                        "<Extensions><TPX xmlns=\"http://www.garmin.com/xmlschemas/ActivityExtension/v2\"><Watts>{0}</Watts></TPX></Extensions>\n",
                                        data.AvgPower.Value.ToPolarDouble()));
                            }
                            dataSomSkalSkrives.Append(
                                    string.Format("<HeartRateBpm>\n<Value>{0}</Value>\n</HeartRateBpm>\n",
                                        lap.HrData[i].HjerteFrekvens));

                            dataSomSkalSkrives.Append("</Trackpoint>\n");
                        }
                        k++;
                    }
                }
                else
                {
                    for (var i = 0; i < lap.AntallSekunder / intervall; i++)
                    {
                        dataSomSkalSkrives.Append("<Trackpoint>\n");
                        dataSomSkalSkrives.Append(string.Format("<Time>{0}</Time>\n",
                                                                lap.StartTime.AddSeconds(i * intervall).ToPolarTime()));
                        dataSomSkalSkrives.Append(string.Format("<HeartRateBpm>\n<Value>{0}</Value>\n</HeartRateBpm>\n",
                                                                lap.SnittHjerteFrekvens));
                        dataSomSkalSkrives.Append("</Trackpoint>\n");
                    }
                }
                dataSomSkalSkrives.Append("</Track>\n");
                dataSomSkalSkrives.Append("</Lap>\n");
            }
            dataSomSkalSkrives.Append(string.Format("<Notes>{0}</Notes>\n", data.Note));
            if (data.UserInfo.ForceGarmin)
                dataSomSkalSkrives.Append(
                    "<Creator xsi:type=\"Device_t\">\n<Name>Garmin Edge 500</Name>\n<UnitId>0</UnitId>\n<ProductID>0</ProductID>\n<Version>\n<VersionMajor>2</VersionMajor>\n<VersionMinor>60</VersionMinor>\n<BuildMajor>0</BuildMajor>\n<BuildMinor>0</BuildMinor>\n</Version>\n</Creator>\n");
            dataSomSkalSkrives.Append("</Activity>\n");
            dataSomSkalSkrives.Append("</Activities>\n");

            dataSomSkalSkrives.Append("</TrainingCenterDatabase>");
            return dataSomSkalSkrives;
        }

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
                    writer.WriteAttributeString("xmlns", "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2");
                }
            }
        }

        private string WriteHeader(string sport, DateTime startTime)
        {
            var headerInfo = new StringBuilder();
            headerInfo.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + "\n");
            headerInfo.Append("<TrainingCenterDatabase xmlns=\"http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2 http://www.garmin.com/xmlschemas/TrainingCenterDatabasev2.xsd\">" + "\n");
            headerInfo.Append("<Activities>" + "\n");
            headerInfo.Append(string.Format("<Activity Sport=\"{0}\">\n", sport));
            headerInfo.Append(string.Format("<Id>{0}</Id>\n", startTime.ToPolarTime()));
            return headerInfo.ToString();
        }
        private double CalculateMetersTraveled(double speed, double distance)
        {
            throw new NotImplementedException();
        }
    }
}
