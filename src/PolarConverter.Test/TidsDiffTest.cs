using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class TidsDiffTest : BaseTest
    {
        [TestMethod]
        public void TidForFort()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"distansetoolong.hrm", "distansetoolong")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            //File not found
            result.ErrorMessages.Count.ShouldEqual(1);
        }
    }
}
