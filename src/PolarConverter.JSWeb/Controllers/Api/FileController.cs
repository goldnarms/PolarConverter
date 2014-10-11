using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using PolarConverter.BLL.Interfaces;
using PolarConverter.BLL.Services;
using PolarConverter.JSWeb.Models;
using PolarFile = PolarConverter.BLL.Entiteter.PolarFile;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class FileController : ApiController
    {
        private readonly IStorageHelper _storageHelper;

        public FileController()
        {
            //_storageHelper = new BlobStorageHelper("/polarfiles");
            //_storageHelper = new LocalStorageHelper();
            _storageHelper = DependencyResolver.Current.GetService<IStorageHelper>();
        }

        public FileController(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
        }

        public IHttpActionResult Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var files = new List<UserFile>();
                using (var db = new ApplicationDbContext())
                {
                    files = db.UserFiles.Where(uf => uf.UserId == id).ToList();
                }
                return Ok(files);
            }
            return NotFound();
        }
    }
}
