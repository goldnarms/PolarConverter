using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class DistanseTester: BaseTest
    {
        [TestMethod]
        public void DistanseForLang()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Distanse\12093001.hrm", "12093001", @"Distanse\12093001.gpx")
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
                firstLap.Track[0].AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.Track[0].CadenceSpecified.ShouldBeFalse();
                TestHelper.AssertAvgAndMax(firstLap, 106, 149).ShouldBeTrue();
                firstLap.StartTime.ShouldEqual(new DateTime(2012, 9, 30, 15, 32, 27));
                firstLap.TotalTimeSeconds.ShouldEqual(4502);
                Math.Round(firstLap.DistanceMeters, 1).ShouldEqual(6852.4);
            }
        }
    }
}
