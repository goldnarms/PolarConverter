using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Services;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class ConvertController : ApiController
    {
        [Route("api/convert")]
        [HttpPost]
        [HttpGet]
        public HttpResponseMessage Convert(UploadViewModel uploadViewModel)
        {
            var conversionService = new ConversionService();
            var zipFil = conversionService.Convert(uploadViewModel);
            var result = new { name = "Result", reference = zipFil };
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            HttpContext.Current.Response.Write(serializer.Serialize(result));
            HttpContext.Current.Response.StatusCode = 200;
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
