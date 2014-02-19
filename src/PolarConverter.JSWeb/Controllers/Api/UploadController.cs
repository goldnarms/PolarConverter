using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;
using PolarConverter.JSWeb.Helpers;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class UploadController : ApiController
    {
        [Route("api/upload")]
        [HttpPost]
        [HttpGet]
        public HttpResponseMessage Upload()
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var fileData = HttpContext.Current.Request.Files[0];

                if (fileData.ContentLength > 0)
                {
                    //Save to blob storage
                    var blobStorageHelper = new BlobStorageHelper("polarfiles");
                    var fileReference = blobStorageHelper.UploadFile(fileData);
                    var sport = CheckForSport(fileData);
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var result = new { name = fileData.FileName, reference = fileReference, fileType = GetFileExtension(fileData.FileName), sport = sport };
                    HttpContext.Current.Response.Write(serializer.Serialize(result));
                    HttpContext.Current.Response.StatusCode = 200;
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        private string CheckForSport(HttpPostedFile fileData)
        {
            var extension = GetFileExtension(fileData.FileName);
            var sport = "Other";
            if (extension == 1)
            {

                var settings = new XmlReaderSettings {ConformanceLevel = ConformanceLevel.Fragment};
                fileData.InputStream.Seek(0, SeekOrigin.Begin);
                using (var xmlReader = XmlReader.Create(fileData.InputStream, settings))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.Name == "type")
                        {
                            switch (xmlReader.ReadInnerXml())
                            {
                                case "CYCLING":
                                    return "Biking";
                                case "RUNNING":
                                    return "Running";
                                default:
                                    return "Other";
                            }
                        }
                    }
                }
            }
            else if (extension == 3)
            {
                fileData.InputStream.Seek(0, SeekOrigin.Begin);
                using (var textReader = new StreamReader(fileData.InputStream))
                {
                    while (!textReader.EndOfStream)
                    {
                        var line = textReader.ReadLine();
                        if (line != null && line.Contains("[Trip]"))
                        {
                            sport = "Biking";
                            break;
                        }
                    }
                }
            }
            return sport;
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
