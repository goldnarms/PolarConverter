using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Interfaces;
using PolarConverter.BLL.Services;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class ConvertController : ApiController
    {
        private readonly IConversion _conversion;

        public ConvertController()
        {
            //_conversion = new ConversionService(new BlobStorageHelper("polarfiles"));
            //_conversion = DependencyResolver.Current.GetService<IConversion>();
            _conversion = new LocalConversionService();
        }

        public ConvertController(IConversion conversion)
        {
            _conversion = conversion;
        }

        [System.Web.Http.Route("api/convert")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Convert(UploadViewModel uploadViewModel)
        {
            var result = _conversion.Convert(uploadViewModel);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            HttpContext.Current.Response.Write(serializer.Serialize(result));
            HttpContext.Current.Response.StatusCode = 200;
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
