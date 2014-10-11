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

        public ConversionService(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _dataMapper = new DataMapper(_storageHelper);
            _xmlMapper = new XmlMapper(_storageHelper);
        }
        public ConversionResult Convert(UploadViewModel model)
        {
            var errorMessages = new List<string>();
            var tcxReferences = new Dictionary<string, string>();
            var successfulFiles = 0;
            var readable =
                GetPipedStream(output =>
                {
                    using (var zip = new ZipFile())
                    {
                        zip.FlattenFoldersOnExtract = true;
                        foreach (var hrmFile in model.PolarFiles.Where(pf => pf.FileType.ToLower() == "hrm"))
                        {
                            try
                            {
                                var hrmFileData = _dataMapper.MapData(hrmFile, model);
                                var shortFileName = RemoveFileExtension(hrmFile.Name);
                                var fileName = string.Format("{0}.{1}", shortFileName, Enum.GetName(typeof(FilTyper), FilTyper.Tcx).ToLower());
                                zip.AddEntry(fileName, hrmFileData);
                                if (!string.IsNullOrEmpty(model.Uid))
                                {
                                    tcxReferences.Add(_storageHelper.SaveStream(new MemoryStream(hrmFileData), fileName, "application/xml", "tcx"), shortFileName);
                                }
                                successfulFiles++;
                            }
                            catch (Exception ex)
                            {
                                errorMessages.Add(string.Format("Error in file {0}: {1}", hrmFile.Name, ex.Message));
                            }

                        }

                        foreach (var xmlFile in model.PolarFiles.Where(pf => pf.FileType.ToLower() == "xml"))
                        {
                            try
                            {
                                var stream = _xmlMapper.MapData(xmlFile, model);
                                var fileName = StringHelper.Filnavnfikser(xmlFile.Name, FilTyper.Tcx);
                                zip.AddEntry(fileName, stream);
                                if (!string.IsNullOrEmpty(model.Uid))
                                {
                                    tcxReferences.Add(_storageHelper.SaveStream(new MemoryStream(stream), fileName, "application/xml", "tcx"), xmlFile.Name);
                                }

                                successfulFiles++;
                            }
                            catch (Exception ex)
                            {
                                errorMessages.Add(string.Format("Error in file {0}: {1}", xmlFile.Name, ex.Message));
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
                FileName = successfulFiles > 0 ? "TcxFiles.zip" : "",
                Reference = successfulFiles > 0 ? fileReference : null,
                TcxReferences = tcxReferences
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
