using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using Ionic.Zip;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Services
{
    public class ConversionService : IConversion
    {
        private readonly IStorageHelper _storageHelper;
        private readonly DataMapper _dataMapper;
        private readonly XmlMapper _xmlMapper;

        public ConversionService()
        {
            //_storageHelper = new BlobStorageHelper("polarfiles");
            _storageHelper = new LocalStorageHelper();
            _dataMapper = new DataMapper(_storageHelper);
            _xmlMapper = new XmlMapper(_storageHelper);
        }

        public ConversionService(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
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
                                zip.AddEntry(StringHelper.Filnavnfikser(hrmFile.Name, FilTyper.Tcx), hrmFileData);
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
                                var fileName = StringHelper.Filnavnfikser(xmlFile.Name, FilTyper.Tcx);
                                var stream = _xmlMapper.MapData(xmlFile, model);
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
    }
}
