using System;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Jobs;
using Microsoft.WindowsAzure.StorageClient;

namespace FileCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            var job = new JobHost();
            job.RunAndBlock();
            DeleteOldFiles();
        }

        public static void DeleteOldFiles()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
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
