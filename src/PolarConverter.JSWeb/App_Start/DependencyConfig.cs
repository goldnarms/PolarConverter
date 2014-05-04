using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Mvc.AlternateType;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PolarConverter.BLL.Interfaces;
using PolarConverter.BLL.Services;
using PolarConverter.JSWeb.Helpers;

namespace PolarConverter.JSWeb
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<IConversion, ConversionService>();
            container.RegisterType<IStorageHelper, BlobStorageHelper>();
        }
    }
}