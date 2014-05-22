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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 144, 159, new DateTime(2012, 6, 3, 14, 50, 33)).ShouldBeTrue();
                firstLap.TotalTimeSeconds.ShouldEqual(661.4);
                var lastLap = trainingDoc.Activities.Activity[0].Lap[1];
                lastLap.Calories.ShouldBeGreaterThan(Zero);
                TestHelper.AssertCadAltAvgMaxStarttime(lastLap, 166, 180, new DateTime(2012, 6, 3, 15, 1, 34, 400)).ShouldBeTrue();
                lastLap.TotalTimeSeconds.ShouldEqual(529.4);
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
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 100, 128, new DateTime(2012, 7, 22, 17, 55, 17), true, true).ShouldBeTrue();
                firstLap.TotalTimeSeconds.ShouldEqual(8007.2);
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 134, 167, new DateTime(2012, 7, 20, 12, 46, 45), true).ShouldBeTrue();
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 119, 129, new DateTime(2012, 7, 6, 17, 38, 27), false, false).ShouldBeTrue();
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(483.8);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[1], 119, 127, new DateTime(2012, 7, 6, 17, 46, 30, 800), false, false).ShouldBeTrue();
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
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 113, 127, new DateTime(2012, 8, 15, 19, 7, 18)).ShouldBeTrue();
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
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 108, 127, new DateTime(2012, 8, 15, 18, 14, 35)).ShouldBeTrue();
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
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 128, 143, new DateTime(2012, 7, 6, 17, 48, 26), true).ShouldBeTrue();
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(484.6);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[1], 130, 130, new DateTime(2012, 7, 6, 17, 56, 30, 600), true).ShouldBeTrue();
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[2], 130, 130, new DateTime(2012, 7, 6, 17, 56, 32, 400), true).ShouldBeTrue();
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
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 138, 169, new DateTime(2012, 7, 30, 17, 36, 25), true).ShouldBeTrue();
                firstLap.TotalTimeSeconds.ShouldEqual(4077.5);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[1], 115, 115, new DateTime(2012, 7, 30, 18, 44, 22, 500), true).ShouldBeTrue();
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 127, 166, new DateTime(2012, 7, 14, 17, 7, 32), false, true).ShouldBeTrue();
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 140, 156, new DateTime(2012, 7, 25, 5, 15, 15), false, false).ShouldBeTrue();
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 151, 163, new DateTime(2012, 8, 13, 17, 23, 7), true, true).ShouldBeTrue();
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 114, 128, new DateTime(2012, 6, 25, 17, 17, 40), false, false).ShouldBeTrue();
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
