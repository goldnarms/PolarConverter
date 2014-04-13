using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Services;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class KalorierTester: BaseTest
    {
        [TestMethod]
        public void TommeKalorier()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"TommeKalorier\12101601.hrm", "12101601", @"TommeKalorier\12101601.gpx")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 0, 0, new DateTime(2012, 10, 16, 18, 06, 08), false, true);
                var secondLap = trainingDoc.Activities.Activity[0].Lap[1];
                TestHelper.AssertCadAltAvgMaxStarttime(secondLap, 148, 164, new DateTime(2012, 10, 16, 18, 06, 08),
                    false, true);
                ushort cal = 89;
                secondLap.Calories.ShouldEqual(cal);
                secondLap.TotalTimeSeconds.ShouldEqual(423.5);
            }
        }
    }
}
