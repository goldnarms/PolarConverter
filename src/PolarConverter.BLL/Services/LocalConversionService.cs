﻿using System;
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
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class LocalConversionService : IConversion
    {
        private LocalStorageHelper _storageHelper;
        private DataMapper _dataMapper;
        private XmlMapper _xmlMapper;

        public LocalConversionService()
        {
            _storageHelper = new LocalStorageHelper();
            _dataMapper = new DataMapper(_storageHelper);
            _xmlMapper = new XmlMapper(_storageHelper);

        }

        public ConversionResult Convert(UploadViewModel model)
        {
            var errorMessages = new List<string>();
            var readable =
                GetPipedStream(output =>
                {
                    using (var zip = new ZipFile())
                    {
                        zip.FlattenFoldersOnExtract = true;
                        foreach (var hrmFile in model.PolarFiles.Where(pf => pf.FileType == "hrm"))
                        {
                            try
                            {
                                var hrmFileData = _dataMapper.MapData(hrmFile, model);
                                var fileName = string.Format("{0}.{1}", RemoveFileExtension(hrmFile.Name),
                                    Enum.GetName(typeof(FilTyper), FilTyper.Tcx).ToLower());
                                zip.AddEntry(fileName, hrmFileData);
                            }
                            catch (Exception ex)
                            {
                                errorMessages.Add(ex.Message);
                            }
                        }

                        foreach (var xmlFile in model.PolarFiles.Where(pf => pf.FileType == "xml"))
                        {
                            try
                            {
                                var stream = _xmlMapper.MapData(xmlFile, model);
                                var fileName = StringHelper.Filnavnfikser(xmlFile.Name, FilTyper.Tcx);
                                zip.AddEntry(fileName, stream);
                            }
                            catch (Exception ex)
                            {
                                errorMessages.Add(ex.Message);
                            }
                        }
                        zip.Save(output);
                        //if (model.SendToStrava)
                        //    EpostHelper.SendTilStrava(model.StravaUsername, tcxFilstier);
                    }
                });

            var fileReference = _storageHelper.SaveStream(readable, "TcxFiles.zip", "application/zip", "zip");
            return new ConversionResult
            {
                ErrorMessages = errorMessages,
                FileName = "TcxFiles.zip",
                Reference = fileReference
            };
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

        private static string RemoveFileExtension(string filename)
        {
            if (filename.Length > 4)
            {
                if (filename.ToLower().Contains(".hrm") &&
                    filename.Substring(filename.LastIndexOf(".hrm"), 4).ToLower() == ".hrm")
                {
                    return filename.Substring(0, filename.LastIndexOf(".hrm"));
                }
                else if (filename.ToLower().Contains(".xml") &&
                    filename.Substring(filename.LastIndexOf(".xml"), 4).ToLower() == ".xml")
                {
                    return filename.Substring(0, filename.LastIndexOf(".xml"));
                }
            }
            return filename;
        }
    }
}
