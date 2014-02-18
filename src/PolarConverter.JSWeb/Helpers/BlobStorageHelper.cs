using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.JSWeb.Helpers
{
    public class BlobStorageHelper
    {
        private CloudStorageAccount _storageAccount;
        private CloudBlobClient _client;
        private CloudBlobContainer _container;
        public BlobStorageHelper(string containerName)
        {
            _storageAccount =
    CloudStorageAccount.Parse(
        ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            _client = _storageAccount.CreateCloudBlobClient();
            _container = _client.GetContainerReference(containerName);
            _container.CreateIfNotExists();
        }

        public string UploadFile(HttpPostedFile fileData)
        {
            var fileReference = Guid.NewGuid().ToString();
            var randomNumber = new Random();
            var id = randomNumber.Next(3000, 9000);
            var fileName = StringHelper.Filnavnfikser(Path.GetFileName(fileData.FileName), id.ToString());
            var blob = _container.GetBlockBlobReference(fileReference);
            blob.Metadata.Add(new KeyValuePair<string, string>("FileName", fileName));
            blob.Properties.ContentType = fileData.ContentType;
            blob.UploadFromStream(fileData.InputStream);
            return fileReference;
        }
    }
}