using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Services;
using Should;


namespace PolarConverter.Test
{
    using BLL;
    using BLL.Entiteter;

    [TestClass]
    public class ImportTest : BaseTest
    {
        [TestMethod]
        public void ImportFromFilMedFlereRunder()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"FlereRunder\12060301.hrm", "12060301", @"FlereRunder\12060301.gpx", gpxVersion: "1.0")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;            
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                const byte avgHeartrate = 144, maxHeartrate = 159;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 6, 3, 18, 50, 33).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 6, 3, 18, 50, 33).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeFalse();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(661.0);
                var lastLap = trainingDoc.Activities.Activity[0].Lap[1];
                lastLap.Calories.ShouldBeGreaterThan(Zero);
                const byte lastAvgHeartrate = 166, lastMaxHeartrate = 180;
                lastLap.AverageHeartRateBpm.Value.ShouldEqual(lastAvgHeartrate);
                lastLap.MaximumHeartRateBpm.Value.ShouldEqual(lastMaxHeartrate);
                lastLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 6, 3, 19, 1, 34, 400).ToShortDateString());
                lastLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 6, 3, 19, 1, 34, 400).ToShortTimeString());
                Math.Round(lastLap.TotalTimeSeconds, 1).ShouldEqual(529.0);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(5);
            }
        }

        [TestMethod]
        public void ImportFromFilGmtAmerika()
        {
            ViewModel.TimeZoneOffset = 2;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Vanlig\12072201.hrm", "12072201", @"Vanlig\12072201.gpx", gpxVersion:"1.0")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 100, maxHeartrate = 128;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 22, 13, 55, 17).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 22, 13, 55, 17).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeTrue();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeTrue();
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                Math.Round(firstLap.TotalTimeSeconds, 0).ShouldEqual(8007);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void ImportFromFilMedGpsUtenDatoINavn()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"GpsNavnUtenDato\rondjeRotte.hrm", "rondjeRotte", @"GpsNavnUtenDato\rondjeRotte.gpx")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                const byte avgHeartrate = 134, maxHeartrate = 167;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 20, 16, 46, 45).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 20, 16, 46, 45).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeTrue();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void ImportFromFilUtenGpx()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"KunHrm\12070601.hrm", "12070601")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                const byte avgHeartrate = 119, maxHeartrate = 128, avgHeartrate2 = 119, maxHeartrate2 = 127;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 6, 21, 38, 27).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 6, 21, 38, 27).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeFalse();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(483.8);
                var secondLap = trainingDoc.Activities.Activity[0].Lap[1];
                secondLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate2);
                secondLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate2);
                secondLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 6, 21, 46, 30).ToShortDateString());
                secondLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 6, 21, 46, 30).ToShortTimeString());
                secondLap.CadenceSpecified.ShouldBeFalse();
                secondLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(3);
            }
        }

        [TestMethod]
        public void ImportFromFilUtenGpx2()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"KunHrm\12081502.hrm", "12081502")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 113, maxHeartrate = 127;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 8, 15, 23, 7, 18).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 8, 15, 23, 7, 18).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeFalse();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.TotalTimeSeconds.ShouldEqual(1410.7);
            }
        }

        [TestMethod]
        public void ImportFromFilUtenGpx3()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"KunHrm\12081501.hrm", "12081501")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 108, maxHeartrate = 127;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 8, 15, 22, 14, 35).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 8, 15, 22, 14, 35).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeFalse();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(1617.4);
            }
        }

        [TestMethod]
        public void ImportFromFilUtenGpxMedSpeed()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"KunHrm\12070602.hrm", "12070602")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 128, maxHeartrate = 143;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 6, 21, 48, 26).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 6, 21, 48, 26).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeTrue();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(484.6);
                const byte avgHeartrate2 = 130, maxHeartrate2 = 130;
                var secondLap = trainingDoc.Activities.Activity[0].Lap[1];
                secondLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate2);
                secondLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate2);
                secondLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 6, 21, 56, 30).ToShortDateString());
                secondLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 6, 21, 56, 30).ToShortTimeString());
                secondLap.CadenceSpecified.ShouldBeTrue();
                secondLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                const byte avgHeartrate3 = 0, maxHeartrate3 = 0;
                var thirdLap = trainingDoc.Activities.Activity[0].Lap[2];
                thirdLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate3);
                thirdLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate3);
                thirdLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 6, 21, 56, 32).ToShortDateString());
                thirdLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 6, 21, 56, 32).ToShortTimeString());
                thirdLap.CadenceSpecified.ShouldBeFalse();
            }
        }

        [TestMethod]
        public void ImportSomFeiler()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"stiilnomapinstrava\12073001.hrm", "12073001", @"stiilnomapinstrava\12073001.gpx", gpxVersion:"1.0")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 138, maxHeartrate = 169;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 30, 21, 36, 25).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 30, 21, 36, 25).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeTrue();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.TotalTimeSeconds.ShouldEqual(4077.5);
                var secondLap = trainingDoc.Activities.Activity[0].Lap[1];
                const byte avgHeartrate2 = 0, maxHeartrate2 = 0;
                secondLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate2);
                secondLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate2);
                secondLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 7, 30, 22, 44, 22).ToShortDateString());
                secondLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 30, 22, 44, 22).ToShortTimeString());
                secondLap.CadenceSpecified.ShouldBeTrue();
                secondLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
            }
        }

        [TestMethod]
        public void ImportSomManglerGPSData()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Vanlig\12081101.hrm", "12081101", @"Vanlig\12081101.gpx")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 139, 165, new DateTime(2012, 8, 11, 5, 45, 14), true).ShouldBeTrue();
                firstLap.TotalTimeSeconds.ShouldEqual(11666);
            }
        }

        [TestMethod]
        public void ForkortetFil()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Filer\12082401.hrm", "12082401", @"Filer\12082401.gpx", gpxVersion: "1.0")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadenceAltitude(firstLap, true).ShouldBeTrue();
            }
        }

        [TestMethod]
        public void OldieFil()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Oldies\1998\98011201.hrm", "98011201")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadenceAltitude(firstLap, false, false).ShouldBeTrue();
            }
        }

        [TestMethod]
        public void OldieFil2()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Oldies\1998\98011801.hrm", "98011801")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadenceAltitude(firstLap, false, false).ShouldBeTrue();
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(4);
            }
        }

        [TestMethod]
        public void OldieFil3()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Oldies\1998\98011802.hrm", "98011802")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadenceAltitude(firstLap, false, false).ShouldBeTrue();
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void OldieFil4()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Oldies\1998\98012101.hrm", "98012101")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadenceAltitude(firstLap, false, false).ShouldBeTrue();
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void ImportFromFilFraXml()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Goldnarms_21.07.2012_export.xml", "Goldnarms_21.07.2012_export", fileType: "xml")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 127, maxHeartrate = 166;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 7, 14, 21, 7, 32).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeFalse();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeTrue();
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(1712.7);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void FeiVedImportFromFilFraXml()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Mattias242_2012-07-30_export.xml", "Mattias242_2012-07-30_export.xml", fileType: "xml")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                trainingDoc.Activities.Activity.Length.ShouldEqual(32);
            }
        }

        [TestMethod]
        public void FeiVedImportFromFilFraXml2()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Mattias242_2012-07-31_export.xml", "Mattias242_2012-07-31_export.xml", fileType: "xml")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 140, 156, new DateTime(2012, 7, 25, 9, 15, 15), false, false).ShouldBeTrue();
                firstLap.TotalTimeSeconds.ShouldEqual(3911.7);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void FeiVedImportFromFilFraXml3()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\ttfje_14.08.2012_export.xml", "ttfje_14.08.2012_export.xml", fileType: "xml")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 151, maxHeartrate = 163;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 8, 13, 21, 23, 7).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeTrue();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeTrue();
                firstLap.TotalTimeSeconds.ShouldEqual(374);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(3);
            }
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereExercises()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\inspiring_21.07.2012_export.xml", "inspiring_21.07.2012_export", fileType: "xml")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                trainingDoc.Activities.Activity.Length.ShouldEqual(30);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                const byte avgHeartrate = 114, maxHeartrate = 128;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 6, 25, 21, 17, 40).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 6, 25, 21, 17, 40).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeFalse();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.TotalTimeSeconds.ShouldEqual(771.5);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereExercises2()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\120820.xml", "120820", fileType: "xml")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.TotalTimeSeconds.ShouldEqual(1643.0);
                trainingDoc.Activities.Activity.Length.ShouldEqual(153);
            }
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereExercises3()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Joerund_01.09.2012_export.xml", "Joerund_01.09.2012_export", fileType: "xml")
            };
            SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldBeGreaterThan(0);
            }

        }
    }
}
