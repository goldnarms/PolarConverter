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
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Duration\12101601_2.hrm", "12101601_2")
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
                firstLap.Track[0].CadenceSpecified.ShouldBeTrue();
                TestHelper.AssertAvgAndMax(firstLap, 134, 158).ShouldBeTrue();
                firstLap.StartTime.ShouldEqual(new DateTime(2012, 10, 16, 20, 57, 44));
                firstLap.TotalTimeSeconds.ShouldEqual(3014);
                Math.Round(firstLap.DistanceMeters, 1).ShouldEqual(30175.8);
            }
        }

        [TestMethod]
        public void ForKortDuration()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Duration\12112501.hrm", "12112501", @"Duration\12112501.gpx", gpxVersion: "1.0")
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
                TestHelper.AssertAvgAndMax(firstLap, 123, 138).ShouldBeTrue();
                firstLap.StartTime.ShouldEqual(new DateTime(2012, 11, 25, 17, 19, 42));
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(159.3);
                Math.Round(firstLap.DistanceMeters, 1).ShouldEqual(974.7);
            }
        }

        [TestMethod]
        public void ForKortDuration2()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Duration\12120801.hrm", "12120801", @"Duration\12120801.gpx", gpxVersion: "1.0")
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
                firstLap.Track[0].AltitudeMetersSpecified.ShouldBeTrue();
                firstLap.Track[0].CadenceSpecified.ShouldBeFalse();
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(8);
                TestHelper.AssertAvgAndMax(firstLap, 138, 153).ShouldBeTrue();
                firstLap.StartTime.ShouldEqual(new DateTime(2012, 12, 8, 9, 14, 30));
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(4129.4);
                Math.Round(firstLap.DistanceMeters, 1).ShouldEqual(6906.2);
                var lastLap = trainingDoc.Activities.Activity[0].Lap[7];
                lastLap.Track[0].AltitudeMetersSpecified.ShouldBeTrue();
                lastLap.Track[0].CadenceSpecified.ShouldBeFalse();
                TestHelper.AssertAvgAndMax(lastLap, 145, 154).ShouldBeTrue();
                lastLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 12, 8, 15, 22, 20).ToShortTimeString());
                Math.Round(lastLap.TotalTimeSeconds, 1).ShouldEqual(2382.6);
            }
        }
    }
}
