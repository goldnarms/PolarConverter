using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class XmlTester: BaseTest
    {
        [TestMethod]
        public void ReadTypeFromXml()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Done\Goldnarms_09.07.2012_export(1).xml", "Goldnarms_09.07.2012_export(1)", fileType: "xml")
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
            }
        }

        [TestMethod]
        public void ImportFromFilFraXml()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\børge_18.10.2012_export.xml", "børge_18.10.2012_export", fileType: "xml", sport: "Biking")
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
                activityType.ToString().ShouldContain("Biking");
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 162, 177, new DateTime(2012, 10, 1, 17, 58, 22), false,
                    false);
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 155, 179, new DateTime(2012, 11, 29, 3, 36, 52), true,
                    true);
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
                TestHelper.AssertCadenceAltitude(firstLap, true, true);
                TestHelper.AssertStartTime(firstLap, new DateTime(2012, 12, 8, 15, 02, 04));
                firstLap.TotalTimeSeconds.ShouldEqual(2520);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(5);
                firstLap.DistanceMeters.ShouldEqual(22124);
            }
        }
    }
}
