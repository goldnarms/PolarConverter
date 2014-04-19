using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Entiteter;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class BugFixesTest : BaseTest
    {
        [TestMethod]
        public void EmptyFolder()
        {
            var polarFiles = new PolarFile[]
            {
                TestHelper.GeneratePolarFile(@"EmptyFiles\11101501.hrm", "11101501")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            result.ErrorMessages.Count.ShouldEqual(0);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 123, 202, new DateTime(2011, 10, 15, 03, 48, 37), true, true).ShouldBeTrue();
                Math.Round(firstLap.DistanceMeters, 1).ShouldEqual(73285.1);
                firstLap.Calories.ShouldNotEqual(Zero);
            }
        }

        [TestMethod]
        public void Bugs01()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"EmptyFiles\13021901.hrm", "13021901", @"EmptyFiles\13021901.gpx", gpxVersion: "1.0")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            result.ErrorMessages.Count.ShouldEqual(1);
        }
    }
}
