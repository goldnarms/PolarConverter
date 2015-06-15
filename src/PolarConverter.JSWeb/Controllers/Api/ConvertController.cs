using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Interfaces;
using PolarConverter.BLL.Services;
using PolarConverter.JSWeb.Models;
using System.IO;
using PolarConverter.DAL.Models;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class ConvertController : ApiController
    {
        private readonly IConversion _conversion;
        private readonly DropboxService _dropboxService;

        public ConvertController()
        {
            //_conversion = new ConversionService(new BlobStorageHelper("polarfiles"));
            _conversion = DependencyResolver.Current.GetService<IConversion>();
            _dropboxService = new DropboxService();
            //_conversion = new LocalConversionService();
        }

        public ConvertController(IConversion conversion)
        {
            _conversion = conversion;
            _dropboxService = new DropboxService();
        }

        [System.Web.Http.Route("api/convert")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Convert(UploadViewModel uploadViewModel)
        {
            var result = _conversion.Convert(uploadViewModel);
            if (!string.IsNullOrEmpty(uploadViewModel.Uid) && result.TcxReferences != null && result.TcxReferences.Count > 0)
            {
				var serviceController = new ServiceController();
				using (var db = new ApplicationDbContext())
                {
                    foreach (var tcxFileReference in result.TcxReferences)
                    {
                        var userFile = new UserFile
                        {
                            Date = DateTime.UtcNow,
                            Reference = tcxFileReference.Key,
                            Name = tcxFileReference.Value,
                            UserId = uploadViewModel.Uid,
                            Activity = Sport.Other
                        };

                        db.UserFiles.Add(userFile);


						var userId = uploadViewModel.Uid;
						var exportFileData = new ServiceController.ExportFileData
						{
							Name = tcxFileReference.Value,
							Provider = "Runkeeper",
							Reference = tcxFileReference.Key,
							UserId = userId
						};

						var runkeeperToken = db.OauthTokens.SingleOrDefault(oa => oa.UserId == userId && oa.ProviderType == ProviderType.Runkeeper);
						if (runkeeperToken != null) {
							try
							{
								exportFileData.Provider = "Runkeeper";
								serviceController.ExportToRunkeeper(runkeeperToken.Token, exportFileData);
							}
							catch (Exception ex)
							{
								throw new Exception("Could not export to Runkeeper, " + ex.Message);
							}
                        }

						var stravaToken = db.OauthTokens.SingleOrDefault(oa => oa.UserId == userId && oa.ProviderType == ProviderType.Strava);
						if (stravaToken != null)
						{
							try
							{
								exportFileData.Provider = "Strava";
								serviceController.ExportToStrava(stravaToken.Token, exportFileData);
							}
							catch (Exception ex)
							{
								throw new Exception("Could not export to Strava, " + ex.Message);
							}
						}
                    }
                    try
                    {
                        await db.SaveChangesAsync();
                    }
                    catch (DbEntityValidationException dbException)
                    {
                        foreach (var dbValidationError in dbException.EntityValidationErrors.SelectMany(error => error.ValidationErrors))
                        {
                            result.ErrorMessages.Add(dbValidationError.ErrorMessage);
                        }
                    }
                }
            }
            return Json(result);
        }
    }
}
