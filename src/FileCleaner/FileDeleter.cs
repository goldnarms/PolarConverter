using System;
using System.Configuration;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace FileCleaner
{
    public class FileDeleter
    {
        public static void DeleteOldFiles()
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("polarfiles");
            container.FetchAttributes();
            foreach (var blob in from item in container.ListBlobs() where item.GetType() == typeof(CloudBlockBlob) select (CloudBlockBlob)item into blob let dateUploaded = Convert.ToDateTime(blob.Properties.LastModifiedUtc) where dateUploaded < DateTime.Now.AddDays(-5) select blob)
            {
                blob.Delete();
            }
        }

    }
}
