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

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class ConvertController : ApiController
    {
        private readonly IConversion _conversion;

        public ConvertController()
        {
            //_conversion = new ConversionService(new BlobStorageHelper("polarfiles"));
            _conversion = DependencyResolver.Current.GetService<IConversion>();
            //_conversion = new LocalConversionService();
        }

        public ConvertController(IConversion conversion)
        {
            _conversion = conversion;
        }

        [System.Web.Http.Route("api/convert")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Convert(UploadViewModel uploadViewModel)
        {
            var result = _conversion.Convert(uploadViewModel);
            if (!string.IsNullOrEmpty(uploadViewModel.Uid) && result.TcxReferences.Count > 0)
            {
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
