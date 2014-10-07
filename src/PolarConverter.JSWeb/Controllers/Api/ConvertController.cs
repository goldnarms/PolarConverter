using System;
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

            var logonUser = HttpContext.Current.Request.LogonUserIdentity;
            var IsApproved = ((ClaimsIdentity)User.Identity).Claims.Where(c => c.Type.Equals("IsApproved")).SingleOrDefault();
            if (logonUser != null && logonUser.IsAuthenticated)
            {
                var userFile = new UserFile
                {
                    Date = DateTime.UtcNow,
                    FileRef = result.Reference,
                    UserId = logonUser.GetUserId()
                };

                using (var db = new ApplicationDbContext())
                {
                    db.UserFiles.Add(userFile);
                    await db.SaveChangesAsync();
                }
            }

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            HttpContext.Current.Response.Write(serializer.Serialize(result));
            HttpContext.Current.Response.StatusCode = 200;
            return Ok(serializer.Serialize(result));
            //new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
