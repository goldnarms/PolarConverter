using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PolarConverter.JSWeb.Controllers
{
    public class UploadController : Controller
    {
        public HttpResponseMessage Index()
        {
            // Get a reference to the file that our jQuery sent.  Even with multiple files, they will all be their own request and be the 0 index
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[0];

            // do something with the file in this space 
            // {....}
            // end of file doing

            // Now we need to wire up a response so that the calling script understands what happened
            System.Web.HttpContext.Current.Response.ContentType = "text/plain";
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var result = new { name = file.FileName };

            System.Web.HttpContext.Current.Response.Write(serializer.Serialize(result));
            System.Web.HttpContext.Current.Response.StatusCode = 200;

            // For compatibility with IE's "done" event we need to return a result as well as setting the context.response
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //
        // GET: /Upload/
        //[HttpPost]
        //public ContentResult Index(HttpPostedFileBase file)
        //{
        //    if (file.ContentLength > 0)
        //    {
        //        var filename = Path.GetFileName(file.FileName);
        //        return CreateContentResult(filename);
        //    }
        //    return CreateContentResult("File invalid or empty.");
        //}

        //private static ContentResult CreateContentResult(string content)
        //{
        //    return new ContentResult
        //    {
        //        Content = content,
        //        ContentEncoding = Encoding.UTF8,
        //        ContentType = "text/plain"
        //    };
        //}
	}
}