using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ionic.Zip;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;

namespace PolarConverter.BLL
{
    public static class FilHandler
    {

        public static string LesFraFil(string sti)
        {
            using (var sr = File.OpenText(sti))
            {
                var data = new StringBuilder();
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    data.AppendLine(s);
                }

                return data.ToString();
            }
        }

        static Stream GetPipedStream(Action<Stream> writeAction)
        {
            var pipeServer = new AnonymousPipeServerStream();
            ThreadPool.QueueUserWorkItem(s =>
            {
                using (pipeServer)
                {
                    writeAction(pipeServer);
                    pipeServer.WaitForPipeDrain();
                }
            });
            return new AnonymousPipeClientStream(pipeServer.GetClientHandleAsString());
        }

        public static MemoryStream SkrivTilFil(PolarData data, string sti)
        {
            using (var memStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memStream))
                {
                    var dataSomSkalSkrives = DataSomSkalSkrives(data);
                    streamWriter.Write(dataSomSkalSkrives);
                    return memStream;
                }
            }
        }

        public static StringBuilder DataSomSkalSkrives(PolarData data)
        {
            var dataSomSkalSkrives = new StringBuilder();
            dataSomSkalSkrives.Append(data.XmlDoc + "\n");
            dataSomSkalSkrives.Append(data.Header + "\n");
            dataSomSkalSkrives.Append("<Activities>" + "\n");
            dataSomSkalSkrives.Append(string.Format("<Activity Sport=\"{0}\">\n", data.Sport));
            dataSomSkalSkrives.Append(string.Format("<Id>{0}</Id>\n", data.StartTime.ToPolarTime()));
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
                if (lap.HeartRateData != null)
                {
                    for (var i = 0; i < lap.HeartRateData.Count; i++)
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
                                                                    lap.StartTime.AddSeconds(i*
                                                                                             (data.RecordingRate ==
                                                                                              238
                                                                                                  ? 5
                                                                                                  : data.
                                                                                                        RecordingRate))
                                                                        .ToPolarTime()));
                        }
                        if (data.HarAltitude && lap.AltitudeData != null)
                            dataSomSkalSkrives.Append(string.Format("<AltitudeMeters>{0}</AltitudeMeters>\n",
                                                                    lap.AltitudeData[i]));
                        dataSomSkalSkrives.Append(
                            string.Format("<HeartRateBpm>\n<Value>{0}</Value>\n</HeartRateBpm>\n",
                                          lap.HeartRateData[i].HjerteFrekvens));
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
                    if (data.RecordingRate == 0)
                        data.RecordingRate = 5;
                    for (var i = 0; i < lap.AntallSekunder/data.RecordingRate; i++)
                    {
                        dataSomSkalSkrives.Append("<Trackpoint>\n");
                        dataSomSkalSkrives.Append(string.Format("<Time>{0}</Time>\n",
                                                                lap.StartTime.AddSeconds(i*
                                                                                         (data.RecordingRate == 238
                                                                                              ? 5
                                                                                              : data.RecordingRate)).ToPolarTime()));
                        dataSomSkalSkrives.Append(string.Format("<HeartRateBpm>\n<Value>{0}</Value>\n</HeartRateBpm>\n",
                                                                lap.SnittHjerteFrekvens));
                        dataSomSkalSkrives.Append("</Trackpoint>\n");
                    }
                }
                dataSomSkalSkrives.Append("</Track>\n");
                dataSomSkalSkrives.Append("</Lap>\n");
            }
            dataSomSkalSkrives.Append(string.Format("<Notes>{0}</Notes>\n", data.Note));
            if (data.UploadViewModel.ForceGarmin)
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

        public static void SlettFil(string filsti)
        {
            if (File.Exists(filsti))
            {
                try
                {
                    Task.Factory.StartNew(() => File.Delete(filsti));
                }
                catch (IOException e)
                {
                }
            }

        }
    }

    public enum FilTyper
    {
        Hrm,
        Gpx,
        Tcx,
        Xml
    }
}
