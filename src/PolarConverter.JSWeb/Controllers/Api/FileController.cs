using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Interfaces;
using PolarConverter.BLL.Services;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class FileController : ApiController
    {
        private readonly IStorageHelper _storageHelper;

        public FileController()
        {
            //_storageHelper = new BlobStorageHelper("/polarfiles");
            _storageHelper = new LocalStorageHelper();
        }

        public FileController(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
        }

        public HttpResponseMessage Get(int id)
        {
            var files = _storageHelper.GetFilesForUser(id);
            if (files == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse<IEnumerable<PolarFile>>(HttpStatusCode.OK, files);
        }
    }
}
