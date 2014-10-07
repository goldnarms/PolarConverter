using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;
using System.Web.Script.Serialization;
using PolarConverter.JSWeb.Models;

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
                    CheckForData(fileData, out sport, out v02Max, out weight, out gpxVersion);
                    if (v02Max < 1)
                    {
                        showExtraVariables = true;
                    }
                    var serializer = new JavaScriptSerializer();
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
                    //HttpContext.Current.Response.Write(serializer.Serialize(result));
                    //HttpContext.Current.Response.StatusCode = 200;
                    //HttpContext.Current.Response.
                    return Json(result);
                }
            }
            return BadRequest();
        }

        private void CheckForData(HttpPostedFile fileData, out string sport, out double v02Max, out double weight,
            out string gpxVersion)
        {
            var extension = fileData.FileName.Substring(fileData.FileName.Length - 3, 3).ToLower();
            sport = "Other";
            v02Max = 0;
            weight = 0;
            gpxVersion = "";
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
                                    if (string.IsNullOrEmpty(v02result))
                                    {
                                        v02result = StringHelper.HentVerdi("VO2max=", 1, line).Trim();
                                    }
                                }
                                if (!string.IsNullOrEmpty(v02result))
                                {
                                    v02Max = v02result.ToPolarDouble();
                                }
                            }
                            if (line.Contains("Weight"))
                            {
                                var weightResult = StringHelper.HentVerdi("Weight=", 3, line).Trim();
                                if (string.IsNullOrEmpty(weightResult))
                                {
                                    weightResult = StringHelper.HentVerdi("Weight=", 2, line).Trim();
                                }
                                if (!string.IsNullOrEmpty(weightResult))
                                {
                                    weight = weightResult.ToPolarDouble();
                                }
                            }
                            if (line.Contains("[Trip]"))
                            {
                                sport = "Biking";
                                break;
                            }
                            // Got to far, abort
                            if (line.Contains("[HRData]"))
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else if (extension == "gpx")
            {
                fileData.InputStream.Seek(0, SeekOrigin.Begin);
                using (var textReader = new StreamReader(fileData.InputStream))
                {
                    var gpxNodeHit = false;
                    while (!textReader.EndOfStream)
                    {
                        var line = textReader.ReadLine();
                        if (line != null)
                        {
                            if (line.Contains("gpx") && line.Contains("version="))
                            {
                                gpxVersion = ReadGpxVersion(line);
                                break;
                            }
                            if (line.Contains("gpx"))
                            {
                                gpxNodeHit = true;
                            }
                            // Can read version after xml
                            else if (gpxNodeHit && line.Contains("version="))
                            {
                                gpxVersion = ReadGpxVersion(line);
                            }
                        }

                    }
                }
            }
        }

        private string ReadGpxVersion(string versionString)
        {
            return StringHelper.HentVerdi("version=", 5, versionString)
                .Replace("\\", "")
                .Replace("\"", "")
                .Trim();
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
