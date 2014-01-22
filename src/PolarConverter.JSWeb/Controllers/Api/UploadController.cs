using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.WindowsAzure.Storage;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class UploadController : ApiController
    {
        private List<DropboxItem> _filesToBeConverted;

        [System.Web.Http.Route("api/upload")]
        [HttpPost]
        [HttpGet]
        public HttpResponseMessage Upload()
        {
            // Get a reference to the file that our jQuery sent.  Even with multiple files, they will all be their own request and be the 0 index
            var id = "1";
            var fileData = HttpContext.Current.Request.Files[0];
            if (fileData != null && fileData.ContentLength > 0){
                //Save to blob storage
                var storageAccount =
                    CloudStorageAccount.Parse(
                        ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
                var client = storageAccount.CreateCloudBlobClient();
                var container = client.GetContainerReference("polarfiles");
                container.Create();
                var fileName = StringHelper.Filnavnfikser(Path.GetFileName(fileData.FileName), id);
                var blob = container.GetBlockBlobReference(fileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload"), fileName);
                using (var filestream = System.IO.File.OpenRead(path))
                {
                    blob.UploadFromStream(filestream);
                }
                fileData.SaveAs(path);
                _filesToBeConverted.Add(new DropboxItem { Filnavn = path, Sport = "Other", Valgt = true });

                //HttpPostedFile file = HttpContext.Current.Request.Files[0];
                //HttpContext.Current.Response.ContentType = "text/plain";
                //var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                //var result = new { name = file.FileName };

                //HttpContext.Current.Response.Write(serializer.Serialize(result));
                //HttpContext.Current.Response.StatusCode = 200;

            }
            // For compatibility with IE's "done" event we need to return a result as well as setting the context.response
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
