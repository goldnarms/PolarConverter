using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using Ionic.Zip;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.BLL.Services
{
    public class ConversionService
    {
        public ConversionService()
        {
            
        }

        public string Convert(UploadViewModel model)
        {
            var tcxFilstier = new List<string>();
            //var hrmFiler = model.DropboxItems.Where(fil => fil.Filnavn.Contains(".hrm"));
            //var xmlFiler = model.DropboxItems.Where(fil => fil.Filnavn.Contains(".xml"));
            var blobStorageHelper = new BlobStorageHelper("polarfiles");
            var readable =
                GetPipedStream(output =>
                {
                    using (var zip = new ZipFile())
                    {
                        zip.FlattenFoldersOnExtract = true;
                        foreach (var hrmFile in model.PolarFiles.Where(pf => pf.FileType == "hrm"))
                        {

                            var hrmData = blobStorageHelper.ReadFile(hrmFile.Reference);
                            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
                            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);

                            var polarData = new PolarData
                            {
                                HrmData = hrmData,
                                UserInfo = new UserInfo{ Weight = model.Weight, TimeZoneOffset = model.TimeZoneOffset, ForceGarmin = model.ForceGarmin},
                                Sport = hrmFile.Sport,
                                Note = "",
                                Modus = modus,
                                ModusVerdi = modusVerdi,
                                HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                                HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                                ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                                HarSpeed = (modus == "SMode" && modusVerdi.Substring(0, 1) == "1") || (modus == "Mode" && modusVerdi.Substring(1, 1) == "1"),
                                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                                Device = System.Convert.ToInt32(StringHelper.HentVerdi("Monitor=", 2, hrmData).Trim()),
                                Intervall = System.Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
                            };

                            var startTid = System.Convert.ToDateTime(StringHelper.HentVerdi("StartTime=", 10, hrmData));
                            startTid = startTid.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneOffset));
                            var startDato = StringHelper.HentVerdi("Date=", 8, hrmData).KonvertertTilDato();
                            polarData.StartTime = new DateTime(startDato.Year, startDato.Month, startDato.Day, startTid.Hour, startTid.Minute, startTid.Second);
                            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);

                            if (hrmFile.GpxFile != null)
                            {
                                var gpxfil = hrmFile.GpxFile;
                                var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneOffset);
                                polarData.GpxDataString = KonverteringsHelper.VaskGpxString(blobStorageHelper.ReadFile(gpxfil.Reference), timeKorreksjon);
                                //SlettFil(gpxfil.hrmKey);
                            }

                            polarData.VaskHrData();
                            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);


                            var fileService = new FileService();
                            var memStreamArray = fileService.WriteToMemoryStream(polarData).ToArray();
                            //if (model.SendToStrava)
                            //{
                            //    using (var fs = File.OpenWrite(filSti))
                            //    {
                            //        fs.Write(memStreamArray, 0, memStreamArray.Length);
                            //    }
                            //    tcxFilstier.Add(filSti);
                            //}
                            zip.AddEntry(StringHelper.Filnavnfikser(hrmFile.Name, FilTyper.Tcx), memStreamArray);
                        }

                        //foreach (var xmlFil in model.PolarFiles.Where(pf => pf.FileType == "xml"))
                        //{
                        //    var xmlTekst = xmlFil.Value;
                        //    var exercises = xmlTekst.Split(new[] { "</exercise>" }, StringSplitOptions.RemoveEmptyEntries).Where(ex => ex.Contains("<exercise>"));
                        //    var i = 1;
                        //    foreach (var exercise in exercises.Where(ex => ex.Contains("<result>")))
                        //    {
                        //        var polarData = new PolarData
                        //        {
                        //            UserInfo = model.UserInfo,
                        //            HarCadence = exercise.Contains("<cadence>"),
                        //            HarAltitude = exercise.Contains("<altitude>"),
                        //            HarSpeed = exercise.Contains("<speed>"),
                        //            HarPower = exercise.Contains("<power>"),
                        //            XmlTekst = exercise,
                        //            RundeTider = KonverteringsHelper.VaskXmlTider(exercise)
                        //        };
                        //        int intervall;
                        //        polarData.Intervall = int.TryParse(StringHelper.HentVerdi("<recording-rate>", 3, exercise).Replace('<', ' ').Replace('/', ' ').Trim(), out intervall) ? intervall : 5;
                        //        var startDate = StringHelper.HentVerdi("<time>", 10, exercise).KonvertertTilDato();
                        //        var startTime = StringHelper.HentVerdi("<time>", 10, exercise, 11).ToPolarTid();
                        //        if (startTime != null)
                        //        {
                        //            startTime = startTime.Value.AddMinutes(IntHelper.HentTidsKorreksjon(model.TimeZoneCorrection));
                        //            polarData.StartTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Value.Hour, startTime.Value.Minute, startTime.Value.Second);
                        //        }

                        //        if (model.GpxFiles.ContainsKey(xmlFil.Key))
                        //        {
                        //            var gpxfil = model.GpxFiles[xmlFil.Key];
                        //            var timeKorreksjon = IntHelper.HentTidsKorreksjon(model.TimeZoneCorrection);
                        //            polarData.GpxDataString = KonverteringsHelper.VaskGpxString(gpxfil, timeKorreksjon);
                        //            //SlettFil(gpxfil.Filnavn);
                        //        }

                        //        polarData.VaskXmlHrData(exercise);
                        //        polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);
                        //        if (polarData.Runder != null)
                        //        {
                        //            var filSti = StringHelper.Filnavnfikser(xmlFil.Key, string.Format("({0})", i), FilTyper.Tcx);
                        //            var memStreamArray = SkrivTilFil(polarData, filSti).ToArray();
                        //            if (model.SendToStrava)
                        //            {
                        //                using (var fs = File.OpenWrite(filSti))
                        //                {
                        //                    fs.Write(memStreamArray, 0, memStreamArray.Length);
                        //                }
                        //                tcxFilstier.Add(filSti);
                        //            }
                        //            if (!zip.ContainsEntry(filSti.Substring(filSti.LastIndexOf('\\'))))
                        //                zip.AddEntry(filSti.Substring(filSti.LastIndexOf('\\')), memStreamArray);
                        //        }
                        //        i++;
                        //    }
                        //}

                        zip.Save(output);
                        //if (model.SendToStrava)
                        //    EpostHelper.SendTilStrava(model.StravaUsername, tcxFilstier);
                    }
                });

            return blobStorageHelper.SaveStream(readable, "TcxFiles.zip", "application/zip", "zip");
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
    }
}
