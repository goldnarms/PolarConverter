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
    public class DurationTest: BaseTest
    {
        [TestMethod]
        public void ForLangDuration()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Distanse\12101601_2.hrm", "12101601_2")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.Track[0].CadenceSpecified.ShouldBeTrue();
                TestHelper.AssertAvgAndMax(firstLap, 133, 158).ShouldBeTrue();
                firstLap.StartTime.ShouldEqual(new DateTime(2012, 10, 16, 16, 57, 44));
                firstLap.TotalTimeSeconds.ShouldEqual(3014);
                Math.Round(firstLap.DistanceMeters, 1).ShouldEqual(6850.6);
            }
        }

        [TestMethod]
        public void ForKortDuration()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Distanse\12112501.hrm", "12112501", @"Duration\12112501.gpx")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.Track[0].CadenceSpecified.ShouldBeFalse();
                TestHelper.AssertAvgAndMax(firstLap, 124, 138).ShouldBeTrue();
                firstLap.StartTime.ShouldEqual(new DateTime(2012, 11, 25, 13, 19, 42));
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(9151.3);
                Math.Round(firstLap.DistanceMeters, 1).ShouldEqual(6850.6);
            }
        }

        [TestMethod]
        public void ForKortDuration2()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Distanse\12120801.hrm", "12120801", @"Duration\12120801.gpx")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldBeTrue();
                firstLap.Track[0].CadenceSpecified.ShouldBeFalse();
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(8);
                TestHelper.AssertAvgAndMax(firstLap, 138, 153).ShouldBeTrue();
                firstLap.StartTime.ShouldEqual(new DateTime(2012, 12, 8, 5, 14, 30));
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(4129.4);
                Math.Round(firstLap.DistanceMeters, 1).ShouldEqual(6850.6);
                var lastLap = trainingDoc.Activities.Activity[0].Lap[7];
                lastLap.Track[0].AltitudeMetersSpecified.ShouldBeTrue();
                lastLap.Track[0].CadenceSpecified.ShouldBeFalse();
                TestHelper.AssertAvgAndMax(lastLap, 145, 154).ShouldBeTrue();
                lastLap.StartTime.ShouldEqual(new DateTime(2012, 12, 8, 11, 22, 20));
                Math.Round(lastLap.TotalTimeSeconds, 1).ShouldEqual(2383.1);
            }
        }
    }
}
