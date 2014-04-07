﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Storage;
using PolarConverter.BLL.Interfaces;
using BlobContainerPermissions = Microsoft.WindowsAzure.Storage.Blob.BlobContainerPermissions;
using BlobContainerPublicAccessType = Microsoft.WindowsAzure.Storage.Blob.BlobContainerPublicAccessType;
using CloudBlobClient = Microsoft.WindowsAzure.Storage.Blob.CloudBlobClient;
using CloudBlobContainer = Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer;

namespace PolarConverter.BLL.Services
{
    public class BlobStorageHelper: IStorageHelper
    {
        private readonly CloudBlobContainer _container;
        public BlobStorageHelper(string containerName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            _container = client.GetContainerReference(containerName);
            if (_container.CreateIfNotExists())
            {
                BlobContainerPermissions permissions = _container.GetPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                _container.SetPermissions(permissions);
            }
            BlobContainerPermissions permissions1 = _container.GetPermissions();
            permissions1.PublicAccess = BlobContainerPublicAccessType.Container;
            _container.SetPermissions(permissions1);
        }

        public string UploadFile(HttpPostedFile fileData)
        {
            return SaveStream(fileData.InputStream, fileData.FileName, fileData.ContentType, fileData.FileName.Substring(fileData.FileName.Length - 3));
        }

        public string SaveStream(Stream stream, string fileName, string contentType, string extension)
        {
            var fileReference = String.Format("{0}.{1}", Guid.NewGuid(), extension);
            var blob = _container.GetBlockBlobReference(fileReference);
            blob.Metadata.Add(new KeyValuePair<string, string>("FileName", fileName));
            blob.Properties.ContentType = contentType;
            blob.UploadFromStream(stream);
            return fileReference;
        }

        public string ReadFile(string fileReference)
        {
            var blob = _container.GetBlockBlobReference(fileReference);
            using (var memoryStream = new MemoryStream())
            {
                blob.DownloadToStream(memoryStream);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public object ReadXmlDocument(string fileReference, Type xmlType)
        {
            var ser = new XmlSerializer(xmlType);            
            var blob = _container.GetBlockBlobReference(fileReference);

            using (var memoryStream = new MemoryStream())
            {
                blob.DownloadToStream(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return ser.Deserialize(memoryStream);
            }
        }

        public IEnumerable<string> Unzip(string fileReference)
        {
            throw new NotImplementedException();
        }
    }
}