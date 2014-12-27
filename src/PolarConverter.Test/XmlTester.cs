using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Entiteter;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class XmlTester: BaseTest
    {
        [TestMethod]
        public void ImportFromFilFraXml()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\børge_18.10.2012_export.xml", "børge_18.10.2012_export", fileType: "xml", sport: "Running")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc =
                    StorageHelper.ReadXmlDocument(reference, typeof (TrainingCenterDatabase_t)) as
                        TrainingCenterDatabase_t;
                var activityType = trainingDoc.Activities.Activity[0].Sport;
                activityType.ToString().ShouldContain("Running");
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 153, maxHeartrate = 167;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 10, 1, 21, 58, 22).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeFalse();
                firstLap.TotalTimeSeconds.ShouldEqual(281.5);
            }
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereRunderMedAutolaps()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\escalade_29.11.2012_export.xml", "escalade_29.11.2012_export", fileType: "xml", sport: "Biking")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc =
                    StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as
                        TrainingCenterDatabase_t;
                var activityType = trainingDoc.Activities.Activity[0].Sport;
                activityType.ToString().ShouldContain("Biking");
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(2);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 154, maxHeartrate = 167;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 11, 29, 7, 36, 52).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 11, 29, 7, 36, 52).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeTrue();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeTrue();
                byte cadence = 76;
                firstLap.Cadence.ShouldEqual(cadence);
                firstLap.TotalTimeSeconds.ShouldEqual(3380.0);
            }
        }

        [TestMethod]
        public void FeilerVedImport()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\escalade_12.12.2012_export.xml", "escalade_12.12.2012_export", fileType: "xml", sport: "Biking")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var activityType = trainingDoc.Activities.Activity[0].Sport;
                activityType.ToString().ShouldContain("Biking");
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(5);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadenceAltitude(firstLap, true, true).ShouldBeTrue();
                TestHelper.AssertStartTime(firstLap, new DateTime(2012, 12, 8, 19, 02, 04)).ShouldBeTrue();
                firstLap.TotalTimeSeconds.ShouldEqual(2520);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(5);
                firstLap.DistanceMeters.ShouldEqual(22124);
            }
        }

        [TestMethod]
        public void XmlFileWithGpx()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Oystein69_24.03.2014_export.xml", "Oystein", fileType: "xml",
                    gpxFileReference: @"XmlFil\Running-2014-3-23.gpx", gpxVersion: "1.1")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc =
                    StorageHelper.ReadXmlDocument(reference, typeof (TrainingCenterDatabase_t)) as
                        TrainingCenterDatabase_t;
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(3);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 146, 162, new DateTime(2014, 3, 23, 12, 57, 11, 0),
                    false, true);
                firstLap.Track[0].Position.ShouldNotBeNull();
                firstLap.Track[0].Position.LatitudeDegrees.ShouldEqual(59.227538);
                firstLap.Track[0].Position.LongitudeDegrees.ShouldEqual(10.954917);
            }
        }
    }
}
