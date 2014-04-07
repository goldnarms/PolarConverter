using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Services;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class TidsDiffTest: BaseTest
    {
        [TestMethod]
        public void TidForFort()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"distansetoolong.hrm", "distansetoolong")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 113, 149, new DateTime(2013, 3, 10, 12, 1, 29), true, true);
                firstLap.TotalTimeSeconds.ShouldEqual(6359.2);
            }
        }
    }
}
