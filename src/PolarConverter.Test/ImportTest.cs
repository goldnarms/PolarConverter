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
    public class ImportTest: BaseTest
    {
        [TestMethod]
        public void ImportFromFilMedFlereRunder()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"FlereRunder\12060301.hrm", "12060301", @"FlereRunder\12060301.gpx")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 144, 159, new DateTime(2012, 6, 3, 14, 50, 33));
                firstLap.TotalTimeSeconds.ShouldEqual(661.4);
                var lastLap = trainingDoc.Activities.Activity[0].Lap[1];
                lastLap.Calories.ShouldBeGreaterThan(Zero);
                TestHelper.AssertCadAltAvgMaxStarttime(lastLap, 166, 180, new DateTime(2012, 6, 3, 15, 1, 34));
                firstLap.TotalTimeSeconds.ShouldEqual(529.8);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(5);
            }
        }

        [TestMethod]
        public void ImportFromFilGmtAmerika()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Vanlig\12072201.hrm", "12072201", @"Vanlig\12072201.gpx")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 144, 159, new DateTime(2012, 7, 22, 17, 55, 17), true, true);
                firstLap.TotalTimeSeconds.ShouldEqual(661.4);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void ImportFromFilMedGpsUtenDatoINavn()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"GpsNavnUtenDato\rondjeRotte.hrm", "rondjeRotte", @"GpsNavnUtenDato\rondjeRotte.gpx")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 133, 167, new DateTime(2012, 7, 20, 12, 46, 45), true, false);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void ImportFromFilUtenGpx()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"KunHrm\12070601.hrm", "12070601")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 119, 129, new DateTime(2012, 7, 6, 17, 38, 27), true, false);
                firstLap.TotalTimeSeconds.ShouldEqual(483.8);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[1], 119, 127, new DateTime(2012, 7, 6, 17, 46, 30), true, false);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(1);
            }
        }

        [TestMethod]
        public void ImportFromFilUtenGpx2()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"KunHrm\12081502.hrm", "12081502")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 112, 127, new DateTime(2012, 8, 15, 19, 7, 18));
                firstLap.TotalTimeSeconds.ShouldEqual(1410);
            }
        }

        [TestMethod]
        public void ImportFromFilUtenGpx3()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"KunHrm\12081501.hrm", "12081501")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 108, 127, new DateTime(2012, 8, 15, 18, 14, 35));
                firstLap.TotalTimeSeconds.ShouldEqual(1620);
            }
        }

        [TestMethod]
        public void ImportFromFilUtenGpxMedSpeed()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"KunHrm\12070602.hrm", "12070602")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 130, 143, new DateTime(2012, 7, 6, 17, 48, 26), true);
                firstLap.TotalTimeSeconds.ShouldEqual(1617.4);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[1], 130, 130, new DateTime(2012, 7, 6, 17, 56, 30), true);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[2], 130, 130, new DateTime(2012, 7, 6, 17, 56, 32), true);
            }
        }

        [TestMethod]
        public void ImportSomFeiler()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"stiilnomapinstrava\12073001.hrm", "12073001", @"stiilnomapinstrava\12073001.gpx")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 115, 169, new DateTime(2012, 7, 30, 17, 36, 25), true);
                firstLap.TotalTimeSeconds.ShouldEqual(4077.5);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[1], 115, 138, new DateTime(2012, 7, 30, 18, 44, 22), true);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[2], 130, 130, new DateTime(2012, 7, 6, 17, 56, 32), true);
            }
        }

        [TestMethod]
        public void ImportSomManglerGPSData()
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 139, 165, new DateTime(2012, 8, 11, 5, 45, 14), true);
                firstLap.TotalTimeSeconds.ShouldEqual(11670);
                TestHelper.AssertCadAltAvgMaxStarttime(trainingDoc.Activities.Activity[0].Lap[1], 115, 138, new DateTime(2012, 7, 30, 18, 44, 22), true);
            }
        }

        [TestMethod]
        public void ForkortetFil()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Filer\12082401.hrm", "12082401", @"Filer\12082401.gpx")
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
                TestHelper.AssertCadenceAltitude(firstLap, true, false);
            }
        }

        [TestMethod]
        public void OldieFil()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Oldies\1998\98011201.hrm", "98011201")
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
                TestHelper.AssertCadenceAltitude(firstLap, false, false);
            }
        }

        [TestMethod]
        public void OldieFil2()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Oldies\1998\98011801.hrm", "98011801")
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
                TestHelper.AssertCadenceAltitude(firstLap, false, false);
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
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadenceAltitude(firstLap, false, false);
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
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadenceAltitude(firstLap, false, false);
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
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 126, 167, new DateTime(2012, 7, 14, 17, 7, 32), false, true);
                firstLap.TotalTimeSeconds.ShouldEqual(1712.7);
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
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 126, 163, new DateTime(2012, 6, 26, 16, 0, 0), true, false);
                firstLap.TotalTimeSeconds.ShouldEqual(3026.7);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(2);
            }
        }

        [TestMethod]
        public void FeiVedImportFromFilFraXml2()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Mattias242_2012-07-31_export.xml", "Mattias242_2012-07-31_export.xml", fileType: "xml")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 126, 156, new DateTime(2012, 7, 25, 5, 15, 15), true, false);
                firstLap.TotalTimeSeconds.ShouldEqual(394.1);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(24);
            }
        }

        [TestMethod]
        public void FeiVedImportFromFilFraXml3()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\ttfje_14.08.2012_export.xml", "ttfje_14.08.2012_export.xml", fileType: "xml")
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
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 126, 164, new DateTime(2012, 8, 13, 17, 23, 7), true, true);
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
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 126, 128, new DateTime(2012, 6, 25, 17, 17, 40), true, false);
                firstLap.TotalTimeSeconds.ShouldEqual(706.6);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldEqual(3);
            }
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereExercises2()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\120820.xml", "120820", fileType: "xml")
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
                firstLap.TotalTimeSeconds.ShouldEqual(706.6);
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldBeGreaterThan(0);
            }
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereExercises3()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Joerund_01.09.2012_export.xml", "Joerund_01.09.2012_export", fileType: "xml")
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
                trainingDoc.Activities.Activity[0].Lap.Length.ShouldBeGreaterThan(0);
            }

        }
    }
}
