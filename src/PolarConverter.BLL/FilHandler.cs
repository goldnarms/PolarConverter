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
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.BLL
{
    public static class FilHandler
    {

        public static Stream LesFraFiler(UserModel model)
        {
            var tcxFilstier = new List<string>();
            //var hrmFiler = model.DropboxItems.Where(fil => fil.Filnavn.Contains(".hrm"));
            //var xmlFiler = model.DropboxItems.Where(fil => fil.Filnavn.Contains(".xml"));

            var readable =
                GetPipedStream(output =>
                {
                    using (var zip = new ZipFile())
                    {
                        zip.FlattenFoldersOnExtract = true;
                        foreach (var hrmFile in model.HrmFiles)
                        {
                            var hrmData = hrmFile.Value;
                            var hrmKey = hrmFile.Key;
                            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
                            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);

                            var polarData = new PolarData
                                {
                                    HrmData = hrmData,
                                    UserInfo = model.UserInfo,
                                    Modus = modus,
                                    ModusVerdi = modusVerdi,
                                    HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                                    HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                                    ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                                    HarSpeed = (modus == "SMode" && modusVerdi.Substring(0, 1) == "1") || (modus == "Mode" && modusVerdi.Substring(1, 1) == "1"),
                                    HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                                    Device = Convert.ToInt32(StringHelper.HentVerdi("Monitor=", 2, hrmData).Trim()),
                                    Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
                                };

                            var startTid = Convert.ToDateTime(StringHelper.HentVerdi("StartTime=", 10, hrmData));
                            startTid = startTid.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneCorrection));
                            var startDato = StringHelper.HentVerdi("Date=", 8, hrmData).KonverterTilDato();
                            polarData.StartTime = new DateTime(startDato.Year, startDato.Month, startDato.Day, startTid.Hour, startTid.Minute, startTid.Second);
                            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);

                            if (model.GpxFiles.ContainsKey(hrmKey))
                            {
                                var gpxfil = model.GpxFiles[hrmKey];
                                var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneCorrection);
                                polarData.GpxDataString = KonverteringsHelper.VaskGpxString(hrmKey, timeKorreksjon);
                                //SlettFil(gpxfil.hrmKey);
                            }

                            polarData.VaskHrData();
                            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

                            //SlettFil(hrmfil.Filnavn);
                            var filSti = StringHelper.Filnavnfikser(hrmKey, FilTyper.Tcx);
                            var memStreamArray = SkrivTilFil(polarData, filSti).ToArray();
                            if (model.SendToStrava)
                            {
                                using (var fs = File.OpenWrite(filSti))
                                {
                                    fs.Write(memStreamArray, 0, memStreamArray.Length);
                                }
                                tcxFilstier.Add(filSti);
                            }
                            zip.AddEntry(filSti.Substring(filSti.LastIndexOf('\\')), memStreamArray);
                        }

                        foreach (var xmlFil in model.XmlFiles)
                        {
                            var xmlTekst = xmlFil.Value;
                            var exercises = xmlTekst.Split(new[] { "</exercise>" }, StringSplitOptions.RemoveEmptyEntries).Where(ex => ex.Contains("<exercise>"));
                            var i = 1;
                            foreach (var exercise in exercises.Where(ex => ex.Contains("<result>")))
                            {
                                var polarData = new PolarData
                                                    {
                                                        UserInfo = model.UserInfo,
                                                        HarCadence = exercise.Contains("<cadence>"),
                                                        HarAltitude = exercise.Contains("<altitude>"),
                                                        HarSpeed = exercise.Contains("<speed>"),
                                                        HarPower = exercise.Contains("<power>"),
                                                        XmlTekst = exercise,
                                                        RundeTider = KonverteringsHelper.VaskXmlTider(exercise)
                                                    };
                                int intervall;
                                polarData.Intervall = int.TryParse(StringHelper.HentVerdi("<recording-rate>", 3, exercise).Replace('<', ' ').Replace('/', ' ').Trim(), out intervall) ? intervall : 5;
                                var startDate = StringHelper.HentVerdi("<time>", 10, exercise).KonverterTilDato();
                                var startTime = StringHelper.HentVerdi("<time>", 10, exercise, 11).ToPolarTid();
                                if (startTime != null)
                                {
                                    startTime = startTime.Value.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneCorrection));
                                    polarData.StartTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Value.Hour, startTime.Value.Minute, startTime.Value.Second);
                                }

                                if (model.GpxFiles.ContainsKey(xmlFil.Key))
                                {
                                    var gpxfil = model.GpxFiles[xmlFil.Key];
                                    var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneCorrection);
                                    polarData.GpxDataString = KonverteringsHelper.VaskGpxString(gpxfil, timeKorreksjon);
                                    //SlettFil(gpxfil.Filnavn);
                                }

                                polarData.VaskXmlHrData(exercise);
                                polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);
                                if (polarData.Runder != null)
                                {
                                    var filSti = StringHelper.Filnavnfikser(xmlFil.Key, string.Format("({0})", i), FilTyper.Tcx);
                                    var memStreamArray = SkrivTilFil(polarData, filSti).ToArray();
                                    if (model.SendToStrava)
                                    {
                                        using (var fs = File.OpenWrite(filSti))
                                        {
                                            fs.Write(memStreamArray, 0, memStreamArray.Length);
                                        }
                                        tcxFilstier.Add(filSti);
                                    }
                                    if (!zip.ContainsEntry(filSti.Substring(filSti.LastIndexOf('\\'))))
                                        zip.AddEntry(filSti.Substring(filSti.LastIndexOf('\\')), memStreamArray);
                                }
                                i++;
                            }
                        }

                        zip.Save(output);
                        if (model.SendToStrava)
                            EpostHelper.SendTilStrava(model.StravaUsername, tcxFilstier);
                    }
                });

            return readable;
        }

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
                    if (data.Intervall == 0)
                        data.Intervall = 5;
                    for (var i = 0; i < lap.AntallSekunder/data.Intervall; i++)
                    {
                        dataSomSkalSkrives.Append("<Trackpoint>\n");
                        dataSomSkalSkrives.Append(string.Format("<Time>{0}</Time>\n",
                                                                lap.StartTime.AddSeconds(i*
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
