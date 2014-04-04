using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Interfaces;
using PolarConverter.BLL.Services;

namespace PolarConverter.Test
{
    [TestClass]
    public class BaseTest
    {
        protected string FileRoot;
        protected IStorageHelper StorageHelper;
        protected ConversionService ConversionService;
        protected DataMapper DataMapper;

        public BaseTest()
        {
            FileRoot = ConfigurationManager.AppSettings["rootPath"];
            StorageHelper = new LocalStorageHelper();
            ConversionService = new ConversionService(StorageHelper);
            DataMapper = new DataMapper(StorageHelper);
        }

        public void TestInit()
        {
            
        }
    }
}
