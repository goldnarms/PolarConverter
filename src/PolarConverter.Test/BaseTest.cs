using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Interfaces;
using PolarConverter.BLL.Services;

namespace PolarConverter.Test
{
    [TestClass]
    public class BaseTest
    {
        protected ushort Zero = 0;
        protected IStorageHelper StorageHelper;
        protected ConversionService ConversionService;
        protected DataMapper DataMapper;
        protected UploadViewModel ViewModel;
        protected string ZipFileReference;
        //protected string FileRoot = "";

        [TestInitialize]
        public void Init()
        {
            //var path = AppDomain.CurrentDomain.BaseDirectory + "\\ConvertedFiles\\";
            StorageHelper = new LocalStorageHelper();
            ConversionService = new ConversionService(StorageHelper);
            DataMapper = new DataMapper(StorageHelper);
            ViewModel = new UploadViewModel
            {
                Age = 22,
                ForceGarmin = false,
                Gender = "m",
                Notes = "Freakkin kewl note",
                TimeZoneOffset = -2,
                WeightMode = "kg",
                Weight = 82,
                V02Max = 52
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //if(ZipFileReference != null)
            //    File.Delete(ZipFileReference);
        }

        public void SetPolarFiles(PolarFile[] polarFiles)
        {
            ViewModel.PolarFiles = polarFiles;
        }
    }
}
