using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Helpers;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class GeneratedXmlTests : BaseTest
    {
	

        [TestMethod]
        public void Xml120820Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\120820.xml", "120820", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\120820.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void Xmlbørge18102012exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\børge_18.10.2012_export.xml", "børge18102012export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\børge_18.10.2012_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void Xmlescalade12122012exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\escalade_12.12.2012_export.xml", "escalade12122012export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\escalade_12.12.2012_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void Xmlescalade29112012exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\escalade_29.11.2012_export.xml", "escalade29112012export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\escalade_29.11.2012_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void XmlGoldnarms21072012exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Goldnarms_21.07.2012_export.xml", "Goldnarms21072012export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\Goldnarms_21.07.2012_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void Xmlinspiring21072012exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\inspiring_21.07.2012_export.xml", "inspiring21072012export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\inspiring_21.07.2012_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void Xmljbnoon30092012export1Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\jbnoon_30.09.2012_export (1).xml", "jbnoon30092012export1", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\jbnoon_30.09.2012_export (1).xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void XmlJoerund01092012exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Joerund_01.09.2012_export.xml", "Joerund01092012export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\Joerund_01.09.2012_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void XmlMattias24220120730exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Mattias242_2012-07-30_export.xml", "Mattias24220120730export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\Mattias242_2012-07-30_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
            }
        }
	

        [TestMethod]
        public void XmlMattias24220120731exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Mattias242_2012-07-31_export.xml", "Mattias24220120731export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\Mattias242_2012-07-31_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void XmlOystein6924032014export1Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Oystein69_24.03.2014_export (1).xml", "Oystein6924032014export1", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\Oystein69_24.03.2014_export (1).xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void XmlOystein6924032014exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\Oystein69_24.03.2014_export.xml", "Oystein6924032014export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\Oystein69_24.03.2014_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void Xmlsebnor08272012exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\sebnor_08-27-2012_export.xml", "sebnor08272012export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\sebnor_08-27-2012_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
	

        [TestMethod]
        public void Xmlttfje14082012exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"XmlFil\ttfje_14.08.2012_export.xml", "ttfje14082012export", fileType:"xml")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\XmlFil\ttfje_14.08.2012_export.xml");
            var time = StringHelper.HentVerdi("<time>", 21, fileContent);
			var invertedTimezoneOffset = ViewModel.TimeZoneOffset * -1;
            var startTime = time.KonverterTilDato().AddHours(invertedTimezoneOffset);
            var duration = StringHelper.HentVerdi("<duration>", 8, fileContent.Substring(fileContent.IndexOf("<result>"))).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.StartTime.ShouldEqual(startTime);
            }
        }
    }
}

