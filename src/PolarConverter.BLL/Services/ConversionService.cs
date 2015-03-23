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
using PolarConverter.DAL.Models;

namespace PolarConverter.BLL.Services
{
    public class ConversionService : IConversion
    {
        private readonly IStorageHelper _storageHelper;
        private readonly DataMapper _dataMapper;
        private readonly XmlMapper _xmlMapper;
        private readonly DropboxService _dropboxService;

        public ConversionService(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _dataMapper = new DataMapper(_storageHelper);
            _xmlMapper = new XmlMapper(_storageHelper);
            _dropboxService = new DropboxService();
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
                                    using(var db = new DAL.Context())
                                    {
                                        DropNet.Models.UserLogin userLogin = null;
                                        var dropboxToken = db.OauthTokens.FirstOrDefault(oa => oa.UserId == model.Uid && oa.ProviderType == (int)ProviderType.Dropbox);
                                        if (dropboxToken != null)
                                        {
                                            userLogin = new DropNet.Models.UserLogin();
                                            userLogin.Token = dropboxToken.Token;
                                            userLogin.Secret = dropboxToken.Secret;
                                            _dropboxService.Init(userLogin);
                                            _dropboxService.SaveStream(new MemoryStream(hrmFileData), fileName, "application/xml", "tcx");
                                        }
                                    }
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
            var filenameLower = filename.ToLower();
            if (filenameLower.Length > 4)
            {
                if (filenameLower.Contains(".hrm") &&
                    filenameLower.Substring(filenameLower.LastIndexOf(".hrm"), 4) == ".hrm")
                {
                    return filenameLower.Substring(0, filenameLower.LastIndexOf(".hrm"));
                }
                else if (filenameLower.Contains(".xml") &&
                    filenameLower.Substring(filenameLower.LastIndexOf(".xml"), 4) == ".xml")
                {
                    return filenameLower.Substring(0, filenameLower.LastIndexOf(".xml"));
                }
            }
            return filenameLower;
        }
    }
}
