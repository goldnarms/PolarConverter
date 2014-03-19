using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;
using PolarConverter.BLL.Hjelpeklasser;
using PolarConverter.BLL.Services;

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
                    var showExtraVariables = false;
                    string sport;
                    double v02Max;
                    double weight;
                    CheckForData(fileData, out sport, out v02Max, out weight);
                    if (v02Max < 1)
                    {
                        showExtraVariables = true;
                    }
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var result = new { name = fileData.FileName, reference = fileReference, fileType = fileData.FileName.Substring(fileData.FileName.Length - 3, 3).ToLower(), sport = sport, showExtraVariables = showExtraVariables, weight = weight };
                    HttpContext.Current.Response.Write(serializer.Serialize(result));
                    HttpContext.Current.Response.StatusCode = 200;
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        private void CheckForData(HttpPostedFile fileData, out string sport, out double v02Max, out double weight)
        {
            var extension = fileData.FileName.Substring(fileData.FileName.Length - 3, 3).ToLower();
            sport = "Other";
            v02Max = 0;
            weight = 0;
            if (extension == "xml")
            {
                var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
                fileData.InputStream.Seek(0, SeekOrigin.Begin);
                using (var xmlReader = XmlReader.Create(fileData.InputStream, settings))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.Name == "type")
                        {
                            switch (xmlReader.ReadInnerXml().Trim())
                            {
                                case "CYCLING":
                                    sport = "Biking";
                                    break;
                                case "RUNNING":
                                    sport = "Running";
                                    break;
                                default:
                                    sport = "Other";
                                    break;
                            }
                        }
                        else if (xmlReader.Name == "vo2max")
                        {
                            v02Max = xmlReader.ReadInnerXml().Trim().ToPolarDouble();
                        }
                        else if (xmlReader.Name == "weight")
                        {
                            weight = xmlReader.ReadInnerXml().Trim().ToPolarDouble();
                        }
                        else if (xmlReader.Name == "samples")
                        {
                            break;
                        }
                    }
                }
            }
            else if (extension == "hrm")
            {
                fileData.InputStream.Seek(0, SeekOrigin.Begin);
                using (var textReader = new StreamReader(fileData.InputStream))
                {
                    while (!textReader.EndOfStream)
                    {
                        var line = textReader.ReadLine();
                        if (line != null)
                        {
                            if (line.Contains("VO2max"))
                            {
                                var v02result = StringHelper.HentVerdi("VO2max=", 3, line).Trim();
                                if (string.IsNullOrEmpty(v02result))
                                {
                                    v02result = StringHelper.HentVerdi("VO2max=", 2, line).Trim();
                                    if(string.IsNullOrEmpty(v02result))
                                        v02result = StringHelper.HentVerdi("VO2max=", 1, line).Trim();
                                }
                                v02Max = v02result.ToPolarDouble();
                            }
                            if (line.Contains("Weight"))
                            {
                                var weightResult = StringHelper.HentVerdi("Weight=", 3, line).Trim();
                                if (string.IsNullOrEmpty(weightResult))
                                    weightResult = StringHelper.HentVerdi("Weight=", 2, line).Trim();
                                weight = weightResult.ToPolarDouble();
                            }
                            if (line.Contains("[Trip]"))
                            {
                                sport = "Biking";
                                break;
                            }
                        }
                    }
                }
            }
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
