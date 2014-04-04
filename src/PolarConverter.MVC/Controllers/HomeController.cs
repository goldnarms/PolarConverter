using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using PolarConverter.BLL.Entiteter;
using System.IO;
using PolarConverter.BLL.Helpers;

namespace PolarConverter.MVC.Controllers
{
    
    using System.Linq;

    using BLL;
    using ViewModels;

    public class HomeController : Controller
    {
        private static List<DropboxItem> _filesToBeConverted = new List<DropboxItem>();
        private static string _status;

        [HttpGet]
        //[HandleError(View = "Error")]
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel { Message = TempData["message"] as string, BrukerGuid = Guid.NewGuid().ToString() };

            var httpCookieValue = HttpContext.Request.Cookies["dbAccessTokenValue"];
            var httpCookieSecret = HttpContext.Request.Cookies["dbAccessTokenSecret"];
            if (httpCookieSecret != null && httpCookieValue != null && !httpCookieValue.Value.ErTomEllerNull() && !httpCookieSecret.Value.ErTomEllerNull())
            {
                var suksess = DropboxHelper.LoginDropbox(httpCookieValue.Value, httpCookieSecret.Value);
                viewModel.DropboxAutorisert = suksess;
                if (suksess)
                {
                    var dropboxFilListeHrm = DropboxHelper.SokOppFilerFraDropboxMappe(FilTyper.Hrm);
                    var dropboxFilListeXml = DropboxHelper.SokOppFilerFraDropboxMappe(FilTyper.Xml);
                    viewModel.DropboxItems = dropboxFilListeHrm.Select(dbi => new DropboxItem { Filnavn = dbi, Valgt = true }).OrderByDescending(fil => fil.Filnavn).ToList();
                    viewModel.DropboxItems.AddRange(
                        dropboxFilListeXml.Select(dbi => new DropboxItem { Filnavn = dbi, Valgt = true }).
                            OrderByDescending(fil => fil.Filnavn).ToList());
                    viewModel.AntallDropboxItems = dropboxFilListeHrm.Count;
                }
                else
                {
                    viewModel.AntallDropboxItems = 0;
                }
            }

            return View(viewModel);
        }

        public void DropBoxIndex()
        {
            Response.Redirect(DropboxHelper.VideresendBrukerTilDropBox());
        }

        public ActionResult Dropboxlogin(string uid, string oauth_token)
        {
            var accessTokenResult = DropboxHelper.GenererAccessToken(uid, oauth_token);
            var cookieValue = HttpContext.Request.Cookies["dbAccessTokenValue"] ?? new HttpCookie("dbAccessTokenValue");
            cookieValue.Value = accessTokenResult.Value;
            cookieValue.Expires = DateTime.Now.AddDays(365);
            HttpContext.Response.Cookies.Add(cookieValue);
            var cookieSecret = HttpContext.Request.Cookies["dbAccessTokenSecret"] ?? new HttpCookie("dbAccessTokenSecret");
            cookieSecret.Value = accessTokenResult.Secret;
            cookieSecret.Expires = DateTime.Now.AddDays(365);
            HttpContext.Response.Cookies.Add(cookieSecret);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HandleError(View = "Error")]
        public ActionResult Upload(string id)
        {
            var fileData = Request.Files[0];
            if (fileData != null && fileData.ContentLength > 0)
            {
                var fileName = StringHelper.Filnavnfikser(Path.GetFileName(fileData.FileName), id);
                var path = Path.Combine(Server.MapPath("~/Upload"), fileName);
                fileData.SaveAs(path);
                _filesToBeConverted.Add(new DropboxItem { Filnavn = path, Sport = "Other", Valgt = true });
            }
            return View("Index", new IndexViewModel { BrukerGuid = id });
        }

        //[HttpPost]
        //[HandleError(View = "Error")]
        //public ActionResult Upload(HttpFileCollectionBase files)
        //{
        //    var fileData = Request.Files[0];
        //    if (fileData != null && fileData.ContentLength > 0)
        //    {
        //        var fileName = StringHelper.Filnavnfikser(Path.GetFileName(fileData.FileName), id);
        //        var path = Path.Combine(Server.MapPath("~/Upload"), fileName);
        //        fileData.SaveAs(path);
        //        _filesToBeConverted.Add(new DropboxItem { Filnavn = path, Sport = "Other", Valgt = true });
        //    }
        //    return View("Index", new IndexViewModel { BrukerGuid = id });
        //}



        [HttpPost]
        [HandleError(View = "Error")]
        public RedirectToRouteResult Index(IndexViewModel viewModel)
        {
            _status = string.Empty;
            if (viewModel.ViserDropbox.HasValue && viewModel.ViserDropbox.Value && viewModel.DropboxItems.Any(dbi => dbi.Valgt))
            {
                var serversti = Server.MapPath("~/Upload");
                var dropboxFilListeGpx = DropboxHelper.SokOppFilerFraDropboxMappe(FilTyper.Gpx);
                var dropboxFilListeXml = DropboxHelper.SokOppFilerFraDropboxMappe(FilTyper.Xml);

                foreach (var valgteDropBox in viewModel.DropboxItems.Where(dbi => dbi.Valgt))
                {
                    var filnavnHrm = valgteDropBox.Filnavn;
                    _filesToBeConverted.Add(new DropboxItem { Filnavn = filnavnHrm, Sport = valgteDropBox.Sport, Valgt = valgteDropBox.Valgt, Notat = valgteDropBox.Notat });
                    if (dropboxFilListeGpx.Any(dbi => dbi.Contains(filnavnHrm.Substring(0, filnavnHrm.Length - 4))))
                    {
                        _filesToBeConverted.Add(new DropboxItem { Filnavn = dropboxFilListeGpx.SingleOrDefault(dbi => dbi.Contains(filnavnHrm.Substring(0, filnavnHrm.Length - 4))), Sport = valgteDropBox.Sport, Valgt = valgteDropBox.Valgt, Notat = valgteDropBox.Notat });
                    }
                }

                DropboxHelper.LastInnFilerFraDropbox(_filesToBeConverted, serversti, viewModel.BrukerGuid);
                _filesToBeConverted = _filesToBeConverted.Select(fil => new DropboxItem { Filnavn = string.Format("{0}\\{1}", serversti, fil.Filnavn), Sport = fil.Sport, Valgt = fil.Valgt, Notat = fil.Notat }).ToList();
                var brukerModel = new BrukerModel
                {
                    DropboxItems = _filesToBeConverted.Select(fil => new DropboxItem
                    {
                        Filnavn = StringHelper.Filnavnfikser(fil.Filnavn, viewModel.BrukerGuid),
                        Sport = fil.Sport,
                        Valgt = fil.Valgt,
                        Notat = fil.Notat
                    }).ToList(),
                    BrukerGuid = viewModel.BrukerGuid,
                    Vekt = viewModel.Vekt,
                    Notat = viewModel.Notat,
                    SendTilStrava = viewModel.SendTilStrava,
                    StravaBrukernavn = viewModel.StravaBrukernavn,
                    Sport = viewModel.Sport,
                    ForceGarmin = viewModel.ForceGarmin,
                    TimeZoneCorrection = viewModel.TimeZoneCorrection
                };
                //DropboxHelper.LagreResultatTilDropbox(FilHandler.LesFraFiler(brukerModel), serversti);
                _status = "File uploaded to your dropbox folder.";
                _filesToBeConverted.Clear();
                return RedirectToAction("Index");
            }
            TempData["ViewModel"] = viewModel;
            return RedirectToAction("ReturnerFil");
        }

        [HttpGet]
        [HandleError(View = "Error")]
        public ActionResult ReturnerFil()
        {
            try
            {
                var stream = LesFraFil();
                var filestream = new FileStreamResult(stream, System.Net.Mime.MediaTypeNames.Application.Zip) { FileDownloadName = "TcxFiles.zip" };
                return filestream;
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public ActionResult HentStatus()
        {
            if (_status.ErTomEllerNull())
                return null;
            return Json(new { visDialog = "1" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }

        public PartialViewResult HentDialog(string id)
        {
            ViewData["status"] = id;
            return PartialView("_HentDialog");
        }
        private Stream LesFraFil()
        {
            var viewModel = TempData["ViewModel"] as IndexViewModel;
            var brukerModel = new BrukerModel
            {
                DropboxItems = _filesToBeConverted.Select(fil => new DropboxItem { Filnavn = fil.Filnavn, Sport = viewModel.Sport, Valgt = fil.Valgt, Notat = fil.Notat }).ToList(),
                BrukerGuid = viewModel.BrukerGuid,
                Vekt = viewModel.Vekt,
                Notat = viewModel.Notat,
                SendTilStrava = viewModel.SendTilStrava,
                StravaBrukernavn = viewModel.StravaBrukernavn,
                Sport = viewModel.Sport,
                ForceGarmin = viewModel.ForceGarmin,
                TimeZoneCorrection = viewModel.TimeZoneCorrection
            };
            _filesToBeConverted.Clear();
            _status = "Files converted successfully!";
            try
            {
                //var stream = FilHandler.LesFraFiler(brukerModel);
                ////using (FileStream file = File.OpenWrite(""))
                ////{
                ////    FileIOHelper.CopyStream(FilHandler.LesFraFiler(brukerModel), file);
                ////}
                //return stream;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult Donate()
        {
            return View();
        }
    }
}
