using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class DataTypeTest: BaseTest
    {
        [TestMethod]
        public void CaloriesShouldBeInt()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Vanlig\12081101.hrm", "12081101", @"Vanlig\12081101.gpx")
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
                firstLap.Calories.ShouldBeGreaterThan(Zero);
            }
        }
    }
}
