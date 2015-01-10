using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class UploadController : ApiController
    {
        private readonly IStorageHelper _storageHelper;

        public UploadController()
        {
            _storageHelper = DependencyResolver.Current.GetService<IStorageHelper>();
        }
        public UploadController(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
        }

        [System.Web.Http.Route("api/upload")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Upload()
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var fileData = HttpContext.Current.Request.Files[0];
                if (fileData.ContentLength > 0)
                {
                    var fileReference = _storageHelper.UploadFile(fileData);
                    var showExtraVariables = false;
                    string sport;
                    double v02Max;
                    double weight;
                    string gpxVersion;
                    
                    var extension = fileData.FileName.Substring(fileData.FileName.Length - 3, 3).ToLower();
                    FileHelper.CheckForData(fileData.InputStream, extension, out sport, out v02Max, out weight, out gpxVersion);
                    if (v02Max < 1)
                    {
                        showExtraVariables = true;
                    }
                    var result = new
                    {
                        name = fileData.FileName,
                        reference = fileReference,
                        fileType = fileData.FileName.Substring(fileData.FileName.Length - 3, 3).ToLower(),
                        sport,
                        showExtraVariables,
                        weight,
                        gpxVersion
                    };
                    return Json(result);
                }
            }
            return BadRequest();
        }
    }
}
