using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
using Microsoft.WindowsAzure.Storage;
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class UploadController : ApiController
    {
        [Route("api/upload")]
        [HttpPost]
        [HttpGet]
        public HttpResponseMessage Upload()
        {
            // Get a reference to the file that our jQuery sent.  Even with multiple files, they will all be their own request and be the 0 index
            var id = "1";
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var fileData = HttpContext.Current.Request.Files[0];

                if (fileData.ContentLength > 0)
                {
                    //Save to blob storage
                    var storageAccount =
                        CloudStorageAccount.Parse(
                            ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
                    var client = storageAccount.CreateCloudBlobClient();
                    var container = client.GetContainerReference("polarfiles");
                    container.CreateIfNotExists();
                    var fileReference = Guid.NewGuid().ToString();
                    var fileName = StringHelper.Filnavnfikser(Path.GetFileName(fileData.FileName), id);
                    var blob = container.GetBlockBlobReference(fileReference);
                    blob.Metadata.Add(new KeyValuePair<string, string>("FileName", fileName));
                    blob.Properties.ContentType = fileData.ContentType;
                    blob.UploadFromStream(fileData.InputStream);
                    var extension = GetFileExtension(fileData.FileName);
                    if (extension == 1)
                    {
                        using (var xmlr = XmlReader.Create(fileData.InputStream))
                        {
                            var line = "";
                            var found = false;
                            while ((line = xmlr.ReadContentAsString()) != null && !found)
                            {
                                if (line.Contains("<type>"))
                                {
                                    var index = line.IndexOf("<type>");
                                    var sport = line.Substring(index, line.IndexOf("</type>") - index);
                                    found = true;
                                }
                            }
                        }
                    }
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var result = new { name = fileName, reference = fileReference, fileType = GetFileExtension(fileData.FileName) };

                    HttpContext.Current.Response.Write(serializer.Serialize(result));
                    HttpContext.Current.Response.StatusCode = 200;

                    // For compatibility with IE's "done" event we need to return a result as well as setting the context.response
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        private int GetFileExtension(string filenName)
        {
            switch (filenName.Substring(filenName.Length - 3, 3).ToLower())
            {
                case "xml":
                    return 1;
                case "gpx":
                    return 2;
                case "hrm":
                    return 3;
                default:
                    return 0;
            }
        }
    }
}
