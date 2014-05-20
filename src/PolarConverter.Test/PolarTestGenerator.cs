using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Helpers;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class GeneratedTests : BaseTest
    {
	

        [TestMethod]
        public void Hrm00011701Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\00011701.hrm", "00011701")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\00011701.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm00022701Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\00022701.hrm", "00022701")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\00022701.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm00032501Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\00032501.hrm", "00032501")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\00032501.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm01ITGiroMortiroloAndresMedagliaScore3122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\01-IT_GiroMortirolo_Andres Medaglia_Score_3-12-2013.hrm", "01ITGiroMortiroloAndresMedagliaScore3122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\01-IT_GiroMortirolo_Andres Medaglia_Score_3-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm01TimeTrial40KMAndresMedagliaScore3112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\01-Time Trial 40KM_Andres Medaglia_Score_31-1-2014.hrm", "01TimeTrial40KMAndresMedagliaScore3112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\01-Time Trial 40KM_Andres Medaglia_Score_31-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm010214Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\01.02.14.hrm", "010214")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\01.02.14.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm03DEHenningerAndresMedagliaScore422014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\03-DE_Henninger_Andres Medaglia_Score_4-2-2014.hrm", "03DEHenningerAndresMedagliaScore422014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\03-DE_Henninger_Andres Medaglia_Score_4-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm04DEHenningerAndresMedagliaScore2812014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\04-DE_Henninger_Andres Medaglia_Score_28-1-2014.hrm", "04DEHenningerAndresMedagliaScore2812014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\04-DE_Henninger_Andres Medaglia_Score_28-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm04TimeTrial40KMAndresMedagliaScore522014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\04-Time Trial 40KM_Andres Medaglia_Score_5-2-2014.hrm", "04TimeTrial40KMAndresMedagliaScore522014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\04-Time Trial 40KM_Andres Medaglia_Score_5-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm05FrielM2CruiseInterval5x6minAndresMedagliaScore2022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\05-Friel  M2-CruiseInterval - 5x6min_Andres Medaglia_Score_20-2-2014.hrm", "05FrielM2CruiseInterval5x6minAndresMedagliaScore2022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\05-Friel  M2-CruiseInterval - 5x6min_Andres Medaglia_Score_20-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm05032014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\05.03.2014.hrm", "05032014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\05.03.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm06TimeTrial40KMAndresMedagliaScore2522014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\06-Time Trial 40KM_Andres Medaglia_Score_25-2-2014.hrm", "06TimeTrial40KMAndresMedagliaScore2522014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\06-Time Trial 40KM_Andres Medaglia_Score_25-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm06032014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\06.03.2014.hrm", "06032014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\06.03.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm07M1Tempo50min1h10mAndresMedagliaScore2722014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\07-M1_Tempo - 50min - 1h10m_Andres Medaglia_Score_27-2-2014.hrm", "07M1Tempo50min1h10mAndresMedagliaScore2722014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\07-M1_Tempo - 50min - 1h10m_Andres Medaglia_Score_27-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm08DEHenningerAndresMedagliaScore2822014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\08-DE_Henninger_Andres Medaglia_Score_28-2-2014.hrm", "08DEHenningerAndresMedagliaScore2822014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\08-DE_Henninger_Andres Medaglia_Score_28-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm090114Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\09.01.14.hrm", "090114")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\09.01.14.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12032014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12.03.2014.hrm", "12032014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12.03.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12ChrisScore312014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12_Chris_Score_3-1-2014.hrm", "12ChrisScore312014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12_Chris_Score_3-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13032014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13.03.2014.hrm", "13032014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13.03.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm131208015772403aab724e4e83e89d73bdb2bf6bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\131208015772403a-ab72-4e4e-83e8-9d73bdb2bf6b.hrm", "131208015772403aab724e4e83e89d73bdb2bf6b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\131208015772403a-ab72-4e4e-83e8-9d73bdb2bf6b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13121401530cd87d1778449e95777ac9780f0e36Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13121401530cd87d-1778-449e-9577-7ac9780f0e36.hrm", "13121401530cd87d1778449e95777ac9780f0e36")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13121401530cd87d-1778-449e-9577-7ac9780f0e36.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm131220017937194a71344569a113406c1c5650fcTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\131220017937194a-7134-4569-a113-406c1c5650fc.hrm", "131220017937194a71344569a113406c1c5650fc")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\131220017937194a-7134-4569-a113-406c1c5650fc.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122101709226d92eaa44a4ba0efc8a9ff20b49Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122101709226d9-2eaa-44a4-ba0e-fc8a9ff20b49.hrm", "13122101709226d92eaa44a4ba0efc8a9ff20b49")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122101709226d9-2eaa-44a4-ba0e-fc8a9ff20b49.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122102709226d92eaa44a4ba0efc8a9ff20b49Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122102709226d9-2eaa-44a4-ba0e-fc8a9ff20b49.hrm", "13122102709226d92eaa44a4ba0efc8a9ff20b49")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122102709226d9-2eaa-44a4-ba0e-fc8a9ff20b49.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm131222011d39c96c3527427786f243022f3cc575Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\131222011d39c96c-3527-4277-86f2-43022f3cc575.hrm", "131222011d39c96c3527427786f243022f3cc575")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\131222011d39c96c-3527-4277-86f2-43022f3cc575.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm131222012f6e267674ec4be7883c15549bb3e5a2Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\131222012f6e2676-74ec-4be7-883c-15549bb3e5a2.hrm", "131222012f6e267674ec4be7883c15549bb3e5a2")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\131222012f6e2676-74ec-4be7-883c-15549bb3e5a2.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm131222013dfb1273e5304b268c6be8d9d6ca9da7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\131222013dfb1273-e530-4b26-8c6b-e8d9d6ca9da7.hrm", "131222013dfb1273e5304b268c6be8d9d6ca9da7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\131222013dfb1273-e530-4b26-8c6b-e8d9d6ca9da7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1312220181510cce98414d82ac8ec2920cad181bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1312220181510cce-9841-4d82-ac8e-c2920cad181b.hrm", "1312220181510cce98414d82ac8ec2920cad181b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1312220181510cce-9841-4d82-ac8e-c2920cad181b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201a821dde0f1084c5b813aad00e4ef730aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201a821dde0-f108-4c5b-813a-ad00e4ef730a.hrm", "13122201a821dde0f1084c5b813aad00e4ef730a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201a821dde0-f108-4c5b-813a-ad00e4ef730a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201b1d0d1900b3f4d84b63ba7d0b7617261Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201b1d0d190-0b3f-4d84-b63b-a7d0b7617261.hrm", "13122201b1d0d1900b3f4d84b63ba7d0b7617261")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201b1d0d190-0b3f-4d84-b63b-a7d0b7617261.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201b8efa298988145da9218daf8685282ecTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201b8efa298-9881-45da-9218-daf8685282ec.hrm", "13122201b8efa298988145da9218daf8685282ec")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201b8efa298-9881-45da-9218-daf8685282ec.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201bba7dc11534e4c48ae81889f6ca778dcTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201bba7dc11-534e-4c48-ae81-889f6ca778dc.hrm", "13122201bba7dc11534e4c48ae81889f6ca778dc")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201bba7dc11-534e-4c48-ae81-889f6ca778dc.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201d6ca01ffb22742b2a5b603f78d0b7c9bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201d6ca01ff-b227-42b2-a5b6-03f78d0b7c9b.hrm", "13122201d6ca01ffb22742b2a5b603f78d0b7c9b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201d6ca01ff-b227-42b2-a5b6-03f78d0b7c9b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201e72bfd9bc6bf4593a5fe3ecb9a6aedbfTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201e72bfd9b-c6bf-4593-a5fe-3ecb9a6aedbf.hrm", "13122201e72bfd9bc6bf4593a5fe3ecb9a6aedbf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201e72bfd9b-c6bf-4593-a5fe-3ecb9a6aedbf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201ebd310460b804467a6dad0cf987eb142Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201ebd31046-0b80-4467-a6da-d0cf987eb142.hrm", "13122201ebd310460b804467a6dad0cf987eb142")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201ebd31046-0b80-4467-a6da-d0cf987eb142.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201f15f8c412c294dc485760c6b6c41d10dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm", "13122201f15f8c412c294dc485760c6b6c41d10d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201f1c38b2c9b914dee943f4727548e173cTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201f1c38b2c-9b91-4dee-943f-4727548e173c.hrm", "13122201f1c38b2c9b914dee943f4727548e173c")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201f1c38b2c-9b91-4dee-943f-4727548e173c.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201fd83a9c4c99d4f01a33334451a867e8aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201fd83a9c4-c99d-4f01-a333-34451a867e8a.hrm", "13122201fd83a9c4c99d4f01a33334451a867e8a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201fd83a9c4-c99d-4f01-a333-34451a867e8a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122201ff2a359f04cb438dbc8a4ece01077bd5Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122201ff2a359f-04cb-438d-bc8a-4ece01077bd5.hrm", "13122201ff2a359f04cb438dbc8a4ece01077bd5")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122201ff2a359f-04cb-438d-bc8a-4ece01077bd5.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122202Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122202.hrm", "13122202")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122202.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1312220249904a3c1c644abf815547a909149609Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1312220249904a3c-1c64-4abf-8155-47a909149609.hrm", "1312220249904a3c1c644abf815547a909149609")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1312220249904a3c-1c64-4abf-8155-47a909149609.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122202ebd310460b804467a6dad0cf987eb142Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122202ebd31046-0b80-4467-a6da-d0cf987eb142.hrm", "13122202ebd310460b804467a6dad0cf987eb142")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122202ebd31046-0b80-4467-a6da-d0cf987eb142.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122202f00a8f3044274a4388a36bc1f7881831Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122202f00a8f30-4427-4a43-88a3-6bc1f7881831.hrm", "13122202f00a8f3044274a4388a36bc1f7881831")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122202f00a8f30-4427-4a43-88a3-6bc1f7881831.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122202fd83a9c4c99d4f01a33334451a867e8aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122202fd83a9c4-c99d-4f01-a333-34451a867e8a.hrm", "13122202fd83a9c4c99d4f01a33334451a867e8a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122202fd83a9c4-c99d-4f01-a333-34451a867e8a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122203Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122203.hrm", "13122203")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122203.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122203fd83a9c4c99d4f01a33334451a867e8aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122203fd83a9c4-c99d-4f01-a333-34451a867e8a.hrm", "13122203fd83a9c4c99d4f01a33334451a867e8a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122203fd83a9c4-c99d-4f01-a333-34451a867e8a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122204Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122204.hrm", "13122204")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122204.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122301.hrm", "13122301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1312230181510cce98414d82ac8ec2920cad181bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1312230181510cce-9841-4d82-ac8e-c2920cad181b.hrm", "1312230181510cce98414d82ac8ec2920cad181b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1312230181510cce-9841-4d82-ac8e-c2920cad181b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122301b8efa298988145da9218daf8685282ecTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122301b8efa298-9881-45da-9218-daf8685282ec.hrm", "13122301b8efa298988145da9218daf8685282ec")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122301b8efa298-9881-45da-9218-daf8685282ec.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122301bf65b3327f6d4caf9dae5a35f61d1be3Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122301bf65b332-7f6d-4caf-9dae-5a35f61d1be3.hrm", "13122301bf65b3327f6d4caf9dae5a35f61d1be3")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122301bf65b332-7f6d-4caf-9dae-5a35f61d1be3.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122301f15f8c412c294dc485760c6b6c41d10dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122301f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm", "13122301f15f8c412c294dc485760c6b6c41d10d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122301f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122302.hrm", "13122302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122303Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122303.hrm", "13122303")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122303.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122401Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122401.hrm", "13122401")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122401.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1312240130497bec99594d4ba8b3e453cedf5ec3Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1312240130497bec-9959-4d4b-a8b3-e453cedf5ec3.hrm", "1312240130497bec99594d4ba8b3e453cedf5ec3")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1312240130497bec-9959-4d4b-a8b3-e453cedf5ec3.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1312240181510cce98414d82ac8ec2920cad181bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1312240181510cce-9841-4d82-ac8e-c2920cad181b.hrm", "1312240181510cce98414d82ac8ec2920cad181b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1312240181510cce-9841-4d82-ac8e-c2920cad181b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122401b8efa298988145da9218daf8685282ecTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122401b8efa298-9881-45da-9218-daf8685282ec.hrm", "13122401b8efa298988145da9218daf8685282ec")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122401b8efa298-9881-45da-9218-daf8685282ec.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122401f15f8c412c294dc485760c6b6c41d10dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122401f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm", "13122401f15f8c412c294dc485760c6b6c41d10d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122401f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122402.hrm", "13122402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122501Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122501.hrm", "13122501")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122501.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122501c81b71b0b517421297f647f2e8490d46Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122501c81b71b0-b517-4212-97f6-47f2e8490d46.hrm", "13122501c81b71b0b517421297f647f2e8490d46")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122501c81b71b0-b517-4212-97f6-47f2e8490d46.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122502Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122502.hrm", "13122502")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122502.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122601Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122601.hrm", "13122601")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122601.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122601aa0a933fa1bd456d8667dc3d9b73f3a7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122601aa0a933f-a1bd-456d-8667-dc3d9b73f3a7.hrm", "13122601aa0a933fa1bd456d8667dc3d9b73f3a7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122601aa0a933f-a1bd-456d-8667-dc3d9b73f3a7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122601b269ae0731454261b42855557e3d09c3Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122601b269ae07-3145-4261-b428-55557e3d09c3.hrm", "13122601b269ae0731454261b42855557e3d09c3")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122601b269ae07-3145-4261-b428-55557e3d09c3.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122602Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122602.hrm", "13122602")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122602.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122701Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122701.hrm", "13122701")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122701.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122702Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122702.hrm", "13122702")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122702.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122702aa0a933fa1bd456d8667dc3d9b73f3a7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122702aa0a933f-a1bd-456d-8667-dc3d9b73f3a7.hrm", "13122702aa0a933fa1bd456d8667dc3d9b73f3a7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122702aa0a933f-a1bd-456d-8667-dc3d9b73f3a7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122703Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122703.hrm", "13122703")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122703.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122801Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122801.hrm", "13122801")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122801.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1312280181510cce98414d82ac8ec2920cad181bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1312280181510cce-9841-4d82-ac8e-c2920cad181b.hrm", "1312280181510cce98414d82ac8ec2920cad181b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1312280181510cce-9841-4d82-ac8e-c2920cad181b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122801b8efa298988145da9218daf8685282ecTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122801b8efa298-9881-45da-9218-daf8685282ec.hrm", "13122801b8efa298988145da9218daf8685282ec")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122801b8efa298-9881-45da-9218-daf8685282ec.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122801c9810c01e01243438dc65cb1a4e0d9c3Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122801c9810c01-e012-4343-8dc6-5cb1a4e0d9c3.hrm", "13122801c9810c01e01243438dc65cb1a4e0d9c3")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122801c9810c01-e012-4343-8dc6-5cb1a4e0d9c3.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122801f15f8c412c294dc485760c6b6c41d10dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122801f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm", "13122801f15f8c412c294dc485760c6b6c41d10d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122801f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122801fd83a9c4c99d4f01a33334451a867e8aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122801fd83a9c4-c99d-4f01-a333-34451a867e8a.hrm", "13122801fd83a9c4c99d4f01a33334451a867e8a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122801fd83a9c4-c99d-4f01-a333-34451a867e8a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122802Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122802.hrm", "13122802")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122802.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122901.hrm", "13122901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1312290181510cce98414d82ac8ec2920cad181bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1312290181510cce-9841-4d82-ac8e-c2920cad181b.hrm", "1312290181510cce98414d82ac8ec2920cad181b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1312290181510cce-9841-4d82-ac8e-c2920cad181b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122901b8efa298988145da9218daf8685282ecTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122901b8efa298-9881-45da-9218-daf8685282ec.hrm", "13122901b8efa298988145da9218daf8685282ec")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122901b8efa298-9881-45da-9218-daf8685282ec.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122901c4a57a656fa94db0af25ee6b189cd705Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122901c4a57a65-6fa9-4db0-af25-ee6b189cd705.hrm", "13122901c4a57a656fa94db0af25ee6b189cd705")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122901c4a57a65-6fa9-4db0-af25-ee6b189cd705.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122901cf960b7f08934585a10e0fcd26579a82Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122901cf960b7f-0893-4585-a10e-0fcd26579a82.hrm", "13122901cf960b7f08934585a10e0fcd26579a82")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122901cf960b7f-0893-4585-a10e-0fcd26579a82.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122901dca9fcd585784a7cbd68f97dbaba3e09Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122901dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm", "13122901dca9fcd585784a7cbd68f97dbaba3e09")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122901dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122901f15f8c412c294dc485760c6b6c41d10dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122901f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm", "13122901f15f8c412c294dc485760c6b6c41d10d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122901f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122901f9fed3dc5aa34bf2852f508d1e6923cbTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122901f9fed3dc-5aa3-4bf2-852f-508d1e6923cb.hrm", "13122901f9fed3dc5aa34bf2852f508d1e6923cb")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122901f9fed3dc-5aa3-4bf2-852f-508d1e6923cb.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122902.hrm", "13122902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122902dca9fcd585784a7cbd68f97dbaba3e09Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122902dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm", "13122902dca9fcd585784a7cbd68f97dbaba3e09")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122902dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122903Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122903.hrm", "13122903")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122903.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122903dca9fcd585784a7cbd68f97dbaba3e09Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122903dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm", "13122903dca9fcd585784a7cbd68f97dbaba3e09")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122903dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122904dca9fcd585784a7cbd68f97dbaba3e09Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122904dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm", "13122904dca9fcd585784a7cbd68f97dbaba3e09")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122904dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13122905dca9fcd585784a7cbd68f97dbaba3e09Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13122905dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm", "13122905dca9fcd585784a7cbd68f97dbaba3e09")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13122905dca9fcd5-8578-4a7c-bd68-f97dbaba3e09.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123001Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123001.hrm", "13123001")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123001.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123001c81b71b0b517421297f647f2e8490d46Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123001c81b71b0-b517-4212-97f6-47f2e8490d46.hrm", "13123001c81b71b0b517421297f647f2e8490d46")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123001c81b71b0-b517-4212-97f6-47f2e8490d46.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123001f1c38b2c9b914dee943f4727548e173cTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123001f1c38b2c-9b91-4dee-943f-4727548e173c.hrm", "13123001f1c38b2c9b914dee943f4727548e173c")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123001f1c38b2c-9b91-4dee-943f-4727548e173c.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123002Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123002.hrm", "13123002")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123002.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123003Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123003.hrm", "13123003")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123003.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123042d075cc07d94b31874527ee0e3484f8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123042d075cc-07d9-4b31-8745-27ee0e3484f8.hrm", "13123042d075cc07d94b31874527ee0e3484f8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123042d075cc-07d9-4b31-8745-27ee0e3484f8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123101Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123101.hrm", "13123101")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123101.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1312310181510cce98414d82ac8ec2920cad181bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1312310181510cce-9841-4d82-ac8e-c2920cad181b.hrm", "1312310181510cce98414d82ac8ec2920cad181b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1312310181510cce-9841-4d82-ac8e-c2920cad181b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123101b8efa298988145da9218daf8685282ecTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123101b8efa298-9881-45da-9218-daf8685282ec.hrm", "13123101b8efa298988145da9218daf8685282ec")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123101b8efa298-9881-45da-9218-daf8685282ec.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123101db514bc0ece745d58c207e4976c0b446Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123101db514bc0-ece7-45d5-8c20-7e4976c0b446.hrm", "13123101db514bc0ece745d58c207e4976c0b446")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123101db514bc0-ece7-45d5-8c20-7e4976c0b446.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm13123101f15f8c412c294dc485760c6b6c41d10dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\13123101f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm", "13123101f15f8c412c294dc485760c6b6c41d10d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\13123101f15f8c41-2c29-4dc4-8576-0c6b6c41d10d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140114Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14.01.14.hrm", "140114")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14.01.14.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140103016859726cc30d45dcabd462c19e298198Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140103016859726c-c30d-45dc-abd4-62c19e298198.hrm", "140103016859726cc30d45dcabd462c19e298198")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140103016859726c-c30d-45dc-abd4-62c19e298198.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401040156365c9625c7400f8f300ef862a65befTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401040156365c96-25c7-400f-8f30-0ef862a65bef.hrm", "1401040156365c9625c7400f8f300ef862a65bef")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401040156365c96-25c7-400f-8f30-0ef862a65bef.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401040181510cce98414d82ac8ec2920cad181bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401040181510cce-9841-4d82-ac8e-c2920cad181b.hrm", "1401040181510cce98414d82ac8ec2920cad181b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401040181510cce-9841-4d82-ac8e-c2920cad181b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401050156365c9625c7400f8f300ef862a65befTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401050156365c96-25c7-400f-8f30-0ef862a65bef.hrm", "1401050156365c9625c7400f8f300ef862a65bef")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401050156365c96-25c7-400f-8f30-0ef862a65bef.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401050181510cce98414d82ac8ec2920cad181bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401050181510cce-9841-4d82-ac8e-c2920cad181b.hrm", "1401050181510cce98414d82ac8ec2920cad181b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401050181510cce-9841-4d82-ac8e-c2920cad181b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14011201179949c942f1400db95326ac9b3913a5Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14011201179949c9-42f1-400d-b953-26ac9b3913a5.hrm", "14011201179949c942f1400db95326ac9b3913a5")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14011201179949c9-42f1-400d-b953-26ac9b3913a5.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140115014887660b1c234beeb1ca2118bdd76716Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140115014887660b-1c23-4bee-b1ca-2118bdd76716.hrm", "140115014887660b1c234beeb1ca2118bdd76716")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140115014887660b-1c23-4bee-b1ca-2118bdd76716.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401150199727db8256f496a883e2b4cea51bfa4Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401150199727db8-256f-496a-883e-2b4cea51bfa4.hrm", "1401150199727db8256f496a883e2b4cea51bfa4")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401150199727db8-256f-496a-883e-2b4cea51bfa4.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401170175646c60c5ba4970962ce21b88bab9daTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401170175646c60-c5ba-4970-962c-e21b88bab9da.hrm", "1401170175646c60c5ba4970962ce21b88bab9da")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401170175646c60-c5ba-4970-962c-e21b88bab9da.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140120018433278def704a4b9db748e8cfb4a4dcTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140120018433278d-ef70-4a4b-9db7-48e8cfb4a4dc.hrm", "140120018433278def704a4b9db748e8cfb4a4dc")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140120018433278d-ef70-4a4b-9db7-48e8cfb4a4dc.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401230111180a75b5024bf0b4ae632dd0b0e98dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401230111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm", "1401230111180a75b5024bf0b4ae632dd0b0e98d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401230111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401230173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401230173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1401230173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401230173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401250102889d78bf9443109826239f7099aef4Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401250102889d78-bf94-4310-9826-239f7099aef4.hrm", "1401250102889d78bf9443109826239f7099aef4")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401250102889d78-bf94-4310-9826-239f7099aef4.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401260137085da1e24a4f11b32f813b45e61bf4Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401260137085da1-e24a-4f11-b32f-813b45e61bf4.hrm", "1401260137085da1e24a4f11b32f813b45e61bf4")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401260137085da1-e24a-4f11-b32f-813b45e61bf4.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140127018433278def704a4b9db748e8cfb4a4dcTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140127018433278d-ef70-4a4b-9db7-48e8cfb4a4dc.hrm", "140127018433278def704a4b9db748e8cfb4a4dc")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140127018433278d-ef70-4a4b-9db7-48e8cfb4a4dc.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401270184891c482ce24a8499f9607fd1a11806Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401270184891c48-2ce2-4a84-99f9-607fd1a11806.hrm", "1401270184891c482ce24a8499f9607fd1a11806")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401270184891c48-2ce2-4a84-99f9-607fd1a11806.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401280137085da1e24a4f11b32f813b45e61bf4Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401280137085da1-e24a-4f11-b32f-813b45e61bf4.hrm", "1401280137085da1e24a4f11b32f813b45e61bf4")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401280137085da1-e24a-4f11-b32f-813b45e61bf4.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401290111180a75b5024bf0b4ae632dd0b0e98dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401290111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm", "1401290111180a75b5024bf0b4ae632dd0b0e98d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401290111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401290173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401290173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1401290173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401290173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401300111180a75b5024bf0b4ae632dd0b0e98dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401300111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm", "1401300111180a75b5024bf0b4ae632dd0b0e98d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401300111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401300173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401300173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1401300173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401300173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14013101224827f1b4194887be08b5d5d867d929Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14013101224827f1-b419-4887-be08-b5d5d867d929.hrm", "14013101224827f1b4194887be08b5d5d867d929")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14013101224827f1-b419-4887-be08-b5d5d867d929.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401310173645fd4f5274acaa2934660ce1ba4e0Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401310173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm", "1401310173645fd4f5274acaa2934660ce1ba4e0")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401310173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1401310173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1401310173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1401310173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1401310173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140201MatsNilssonScore122014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140201_Mats Nilsson_Score_1-2-2014.hrm", "140201MatsNilssonScore122014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140201_Mats Nilsson_Score_1-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140204PMALETORTFABIENCCRTOCC04022014cafa28200c2c2c34079afe33f2d3469df16Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140204_PMA-LETORT FABIEN(CCR - TOCC) 04-02-2014.cafa28200c2-c2c3-4079-afe3-3f2d3469df16.hrm", "140204PMALETORTFABIENCCRTOCC04022014cafa28200c2c2c34079afe33f2d3469df16")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140204_PMA-LETORT FABIEN(CCR - TOCC) 04-02-2014.cafa28200c2-c2c3-4079-afe3-3f2d3469df16.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402050111180a75b5024bf0b4ae632dd0b0e98dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402050111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm", "1402050111180a75b5024bf0b4ae632dd0b0e98d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402050111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140205011990352c5ec44b55878f59921f49317aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140205011990352c-5ec4-4b55-878f-59921f49317a.hrm", "140205011990352c5ec44b55878f59921f49317a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140205011990352c-5ec4-4b55-878f-59921f49317a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402050173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402050173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1402050173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402050173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402060111180a75b5024bf0b4ae632dd0b0e98dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402060111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm", "1402060111180a75b5024bf0b4ae632dd0b0e98d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402060111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402060173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402060173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1402060173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402060173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208.hrm", "140208")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14020801224827f1b4194887be08b5d5d867d929Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14020801224827f1-b419-4887-be08-b5d5d867d929.hrm", "14020801224827f1b4194887be08b5d5d867d929")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14020801224827f1-b419-4887-be08-b5d5d867d929.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402080173645fd4f5274acaa2934660ce1ba4e0Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402080173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm", "1402080173645fd4f5274acaa2934660ce1ba4e0")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402080173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402080173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402080173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1402080173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402080173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208ae1948b1ba4e4b3c89165f14bd01c54aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm", "140208ae1948b1ba4e4b3c89165f14bd01c54a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208cd5e1c5dbba949d38b21feb11864c1efTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208cd5e1c5d-bba9-49d3-8b21-feb11864c1ef.hrm", "140208cd5e1c5dbba949d38b21feb11864c1ef")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208cd5e1c5d-bba9-49d3-8b21-feb11864c1ef.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208d56f53f730d94eb4b9e0447aefcafb54Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208d56f53f7-30d9-4eb4-b9e0-447aefcafb54.hrm", "140208d56f53f730d94eb4b9e0447aefcafb54")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208d56f53f7-30d9-4eb4-b9e0-447aefcafb54.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208d5a461d2fcf84ce3b11b51e4f26bc341Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm", "140208d5a461d2fcf84ce3b11b51e4f26bc341")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208db476dab0a20405baa90ff56ee265044Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208db476dab-0a20-405b-aa90-ff56ee265044.hrm", "140208db476dab0a20405baa90ff56ee265044")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208db476dab-0a20-405b-aa90-ff56ee265044.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208e0af7eb24cfb472eacf87013fe0d8a0dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm", "140208e0af7eb24cfb472eacf87013fe0d8a0d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208e37480eacd79429585785f8632cf1894Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208e37480ea-cd79-4295-8578-5f8632cf1894.hrm", "140208e37480eacd79429585785f8632cf1894")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208e37480ea-cd79-4295-8578-5f8632cf1894.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140208f256e40b60194adbb03270ecc513fec7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140208f256e40b-6019-4adb-b032-70ecc513fec7.hrm", "140208f256e40b60194adbb03270ecc513fec7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140208f256e40b-6019-4adb-b032-70ecc513fec7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14020901224827f1b4194887be08b5d5d867d929Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14020901224827f1-b419-4887-be08-b5d5d867d929.hrm", "14020901224827f1b4194887be08b5d5d867d929")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14020901224827f1-b419-4887-be08-b5d5d867d929.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402090173645fd4f5274acaa2934660ce1ba4e0Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402090173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm", "1402090173645fd4f5274acaa2934660ce1ba4e0")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402090173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402090173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402090173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1402090173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402090173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14021001224827f1b4194887be08b5d5d867d929Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14021001224827f1-b419-4887-be08-b5d5d867d929.hrm", "14021001224827f1b4194887be08b5d5d867d929")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14021001224827f1-b419-4887-be08-b5d5d867d929.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402100173645fd4f5274acaa2934660ce1ba4e0Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402100173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm", "1402100173645fd4f5274acaa2934660ce1ba4e0")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402100173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402100173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402100173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1402100173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402100173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140212Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140212.hrm", "140212")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140212.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14021201286075db353644ddbaa08aa478c15d27Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14021201286075db-3536-44dd-baa0-8aa478c15d27.hrm", "14021201286075db353644ddbaa08aa478c15d27")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14021201286075db-3536-44dd-baa0-8aa478c15d27.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140212ae1948b1ba4e4b3c89165f14bd01c54aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140212ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm", "140212ae1948b1ba4e4b3c89165f14bd01c54a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140212ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140212cd5e1c5dbba949d38b21feb11864c1efTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140212cd5e1c5d-bba9-49d3-8b21-feb11864c1ef.hrm", "140212cd5e1c5dbba949d38b21feb11864c1ef")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140212cd5e1c5d-bba9-49d3-8b21-feb11864c1ef.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140212d56f53f730d94eb4b9e0447aefcafb54Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140212d56f53f7-30d9-4eb4-b9e0-447aefcafb54.hrm", "140212d56f53f730d94eb4b9e0447aefcafb54")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140212d56f53f7-30d9-4eb4-b9e0-447aefcafb54.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140212d5a461d2fcf84ce3b11b51e4f26bc341Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140212d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm", "140212d5a461d2fcf84ce3b11b51e4f26bc341")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140212d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140212e0af7eb24cfb472eacf87013fe0d8a0dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140212e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm", "140212e0af7eb24cfb472eacf87013fe0d8a0d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140212e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140212e37480eacd79429585785f8632cf1894Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140212e37480ea-cd79-4295-8578-5f8632cf1894.hrm", "140212e37480eacd79429585785f8632cf1894")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140212e37480ea-cd79-4295-8578-5f8632cf1894.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140212f256e40b60194adbb03270ecc513fec7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140212f256e40b-6019-4adb-b032-70ecc513fec7.hrm", "140212f256e40b60194adbb03270ecc513fec7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140212f256e40b-6019-4adb-b032-70ecc513fec7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140215Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140215.hrm", "140215")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140215.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140215ae1948b1ba4e4b3c89165f14bd01c54aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140215ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm", "140215ae1948b1ba4e4b3c89165f14bd01c54a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140215ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140215cd5e1c5dbba949d38b21feb11864c1efTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140215cd5e1c5d-bba9-49d3-8b21-feb11864c1ef.hrm", "140215cd5e1c5dbba949d38b21feb11864c1ef")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140215cd5e1c5d-bba9-49d3-8b21-feb11864c1ef.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140215d56f53f730d94eb4b9e0447aefcafb54Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140215d56f53f7-30d9-4eb4-b9e0-447aefcafb54.hrm", "140215d56f53f730d94eb4b9e0447aefcafb54")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140215d56f53f7-30d9-4eb4-b9e0-447aefcafb54.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140215d5a461d2fcf84ce3b11b51e4f26bc341Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140215d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm", "140215d5a461d2fcf84ce3b11b51e4f26bc341")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140215d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140215e0af7eb24cfb472eacf87013fe0d8a0dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140215e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm", "140215e0af7eb24cfb472eacf87013fe0d8a0d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140215e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140215f256e40b60194adbb03270ecc513fec7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140215f256e40b-6019-4adb-b032-70ecc513fec7.hrm", "140215f256e40b60194adbb03270ecc513fec7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140215f256e40b-6019-4adb-b032-70ecc513fec7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14021601224827f1b4194887be08b5d5d867d929Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14021601224827f1-b419-4887-be08-b5d5d867d929.hrm", "14021601224827f1b4194887be08b5d5d867d929")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14021601224827f1-b419-4887-be08-b5d5d867d929.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402160169324a47150543009c95e815276ab7e6Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402160169324a47-1505-4300-9c95-e815276ab7e6.hrm", "1402160169324a47150543009c95e815276ab7e6")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402160169324a47-1505-4300-9c95-e815276ab7e6.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402160173645fd4f5274acaa2934660ce1ba4e0Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402160173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm", "1402160173645fd4f5274acaa2934660ce1ba4e0")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402160173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402160173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402160173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1402160173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402160173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402170111180a75b5024bf0b4ae632dd0b0e98dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402170111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm", "1402170111180a75b5024bf0b4ae632dd0b0e98d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402170111180a75-b502-4bf0-b4ae-632dd0b0e98d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14021701224827f1b4194887be08b5d5d867d929Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14021701224827f1-b419-4887-be08-b5d5d867d929.hrm", "14021701224827f1b4194887be08b5d5d867d929")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14021701224827f1-b419-4887-be08-b5d5d867d929.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402170173645fd4f5274acaa2934660ce1ba4e0Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402170173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm", "1402170173645fd4f5274acaa2934660ce1ba4e0")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402170173645fd4-f527-4aca-a293-4660ce1ba4e0.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402170173996f3627a24a8aac31904f4dd85ae8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402170173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm", "1402170173996f3627a24a8aac31904f4dd85ae8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402170173996f36-27a2-4a8a-ac31-904f4dd85ae8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402190169324a47150543009c95e815276ab7e6Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402190169324a47-1505-4300-9c95-e815276ab7e6.hrm", "1402190169324a47150543009c95e815276ab7e6")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402190169324a47-1505-4300-9c95-e815276ab7e6.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14022001222494eef2e64a61b7848c56d124a9f6Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14022001222494ee-f2e6-4a61-b784-8c56d124a9f6.hrm", "14022001222494eef2e64a61b7848c56d124a9f6")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14022001222494ee-f2e6-4a61-b784-8c56d124a9f6.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140222Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140222.hrm", "140222")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140222.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140222ae1948b1ba4e4b3c89165f14bd01c54aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140222ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm", "140222ae1948b1ba4e4b3c89165f14bd01c54a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140222ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140222d56f53f730d94eb4b9e0447aefcafb54Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140222d56f53f7-30d9-4eb4-b9e0-447aefcafb54.hrm", "140222d56f53f730d94eb4b9e0447aefcafb54")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140222d56f53f7-30d9-4eb4-b9e0-447aefcafb54.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140222d5a461d2fcf84ce3b11b51e4f26bc341Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140222d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm", "140222d5a461d2fcf84ce3b11b51e4f26bc341")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140222d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140222e0af7eb24cfb472eacf87013fe0d8a0dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140222e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm", "140222e0af7eb24cfb472eacf87013fe0d8a0d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140222e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140222e37480eacd79429585785f8632cf1894Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140222e37480ea-cd79-4295-8578-5f8632cf1894.hrm", "140222e37480eacd79429585785f8632cf1894")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140222e37480ea-cd79-4295-8578-5f8632cf1894.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1402230169324a47150543009c95e815276ab7e6Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1402230169324a47-1505-4300-9c95-e815276ab7e6.hrm", "1402230169324a47150543009c95e815276ab7e6")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1402230169324a47-1505-4300-9c95-e815276ab7e6.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140226Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140226.hrm", "140226")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140226.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140226ae1948b1ba4e4b3c89165f14bd01c54aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140226ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm", "140226ae1948b1ba4e4b3c89165f14bd01c54a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140226ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140226d5a461d2fcf84ce3b11b51e4f26bc341Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140226d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm", "140226d5a461d2fcf84ce3b11b51e4f26bc341")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140226d5a461d2-fcf8-4ce3-b11b-51e4f26bc341.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140226e0af7eb24cfb472eacf87013fe0d8a0dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140226e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm", "140226e0af7eb24cfb472eacf87013fe0d8a0d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140226e0af7eb2-4cfb-472e-acf8-7013fe0d8a0d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140226e37480eacd79429585785f8632cf1894Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140226e37480ea-cd79-4295-8578-5f8632cf1894.hrm", "140226e37480eacd79429585785f8632cf1894")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140226e37480ea-cd79-4295-8578-5f8632cf1894.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1403010140050c604f32452cbcdd1fd1d6e04b48Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1403010140050c60-4f32-452c-bcdd-1fd1d6e04b48.hrm", "1403010140050c604f32452cbcdd1fd1d6e04b48")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1403010140050c60-4f32-452c-bcdd-1fd1d6e04b48.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1403010199240e2c11b64830ab8c72dfe5d2ad85Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1403010199240e2c-11b6-4830-ab8c-72dfe5d2ad85.hrm", "1403010199240e2c11b64830ab8c72dfe5d2ad85")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1403010199240e2c-11b6-4830-ab8c-72dfe5d2ad85.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140301ae1948b1ba4e4b3c89165f14bd01c54aTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140301ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm", "140301ae1948b1ba4e4b3c89165f14bd01c54a")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140301ae1948b1-ba4e-4b3c-8916-5f14bd01c54a.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm140301c6ffeec7c3134e60aa58f57bbe1c81dbTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\140301c6ffeec7-c313-4e60-aa58-f57bbe1c81db.hrm", "140301c6ffeec7c3134e60aa58f57bbe1c81db")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\140301c6ffeec7-c313-4e60-aa58-f57bbe1c81db.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1403020140050c604f32452cbcdd1fd1d6e04b48Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1403020140050c60-4f32-452c-bcdd-1fd1d6e04b48.hrm", "1403020140050c604f32452cbcdd1fd1d6e04b48")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1403020140050c60-4f32-452c-bcdd-1fd1d6e04b48.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1403020178758b684bd545f99f672a604f71b958Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1403020178758b68-4bd5-45f9-9f67-2a604f71b958.hrm", "1403020178758b684bd545f99f672a604f71b958")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1403020178758b68-4bd5-45f9-9f67-2a604f71b958.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm1403020199240e2c11b64830ab8c72dfe5d2ad85Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\1403020199240e2c-11b6-4830-ab8c-72dfe5d2ad85.hrm", "1403020199240e2c11b64830ab8c72dfe5d2ad85")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\1403020199240e2c-11b6-4830-ab8c-72dfe5d2ad85.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm14031501272410bc79144336a9861493e9fce879Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\14031501272410bc-7914-4336-a986-1493e9fce879.hrm", "14031501272410bc79144336a9861493e9fce879")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\14031501272410bc-7914-4336-a986-1493e9fce879.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm15032014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\15.03.2014.hrm", "15032014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\15.03.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm16022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\16.02.2014.hrm", "16022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\16.02.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm171213Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\17.12.13.hrm", "171213")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\17.12.13.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm18022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\18.02.2014.hrm", "18022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\18.02.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20kmLasVegasBlanceChrisScore29122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20 km Las Vegas Blance_Chris_Score_29-12-2013.hrm", "20kmLasVegasBlanceChrisScore29122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20 km Las Vegas Blance_Chris_Score_29-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20kmLasVegasBlanceChrisScore3112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20 km Las Vegas Blance_Chris_Score_31-1-2014.hrm", "20kmLasVegasBlanceChrisScore3112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20 km Las Vegas Blance_Chris_Score_31-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20.02.2014.hrm", "20022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20.02.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20130401a4da3c9d68a8d4c6ea89647cd34480f28Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013-04-01a4da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm", "20130401a4da3c9d68a8d4c6ea89647cd34480f28")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013-04-01a4da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20130401b4da3c9d68a8d4c6ea89647cd34480f28Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013-04-01b4da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm", "20130401b4da3c9d68a8d4c6ea89647cd34480f28")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013-04-01b4da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm201304104da3c9d68a8d4c6ea89647cd34480f28Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013-04-104da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm", "201304104da3c9d68a8d4c6ea89647cd34480f28")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013-04-104da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20137Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013-7.hrm", "20137")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013-7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131205TechLETORTFABIENCCRTOCC05122013caf1f3647fb73ff4268b208dd586eb889c7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131205_Tech-LETORT FABIEN(CCR - TOCC) 05-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm", "20131205TechLETORTFABIENCCRTOCC05122013caf1f3647fb73ff4268b208dd586eb889c7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131205_Tech-LETORT FABIEN(CCR - TOCC) 05-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131205TechLETORTFABIENCCRTOCC05122013caf8bca3e82a7c244eda124fbd1df1943bbTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131205_Tech-LETORT FABIEN(CCR - TOCC) 05-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm", "20131205TechLETORTFABIENCCRTOCC05122013caf8bca3e82a7c244eda124fbd1df1943bb")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131205_Tech-LETORT FABIEN(CCR - TOCC) 05-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131210TVLETORTFABIENCCRTOCC10122013caf1f3647fb73ff4268b208dd586eb889c7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131210_TV-LETORT FABIEN(CCR - TOCC) 10-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm", "20131210TVLETORTFABIENCCRTOCC10122013caf1f3647fb73ff4268b208dd586eb889c7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131210_TV-LETORT FABIEN(CCR - TOCC) 10-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131210TVLETORTFABIENCCRTOCC10122013caf8bca3e82a7c244eda124fbd1df1943bbTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131210_TV-LETORT FABIEN(CCR - TOCC) 10-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm", "20131210TVLETORTFABIENCCRTOCC10122013caf8bca3e82a7c244eda124fbd1df1943bb")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131210_TV-LETORT FABIEN(CCR - TOCC) 10-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131216FVLETORTFABIENCCRTOCC18122013caf1f3647fb73ff4268b208dd586eb889c7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131216_FV-LETORT FABIEN(CCR - TOCC) 18-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm", "20131216FVLETORTFABIENCCRTOCC18122013caf1f3647fb73ff4268b208dd586eb889c7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131216_FV-LETORT FABIEN(CCR - TOCC) 18-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131216FVLETORTFABIENCCRTOCC18122013caf8bca3e82a7c244eda124fbd1df1943bbTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131216_FV-LETORT FABIEN(CCR - TOCC) 18-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm", "20131216FVLETORTFABIENCCRTOCC18122013caf8bca3e82a7c244eda124fbd1df1943bb")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131216_FV-LETORT FABIEN(CCR - TOCC) 18-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131217TeVeLETORTFABIENCCRTOCC17122013caf1f3647fb73ff4268b208dd586eb889c7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131217_TeVe-LETORT FABIEN(CCR - TOCC) 17-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm", "20131217TeVeLETORTFABIENCCRTOCC17122013caf1f3647fb73ff4268b208dd586eb889c7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131217_TeVe-LETORT FABIEN(CCR - TOCC) 17-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131217TeVeLETORTFABIENCCRTOCC17122013caf8bca3e82a7c244eda124fbd1df1943bbTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131217_TeVe-LETORT FABIEN(CCR - TOCC) 17-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm", "20131217TeVeLETORTFABIENCCRTOCC17122013caf8bca3e82a7c244eda124fbd1df1943bb")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131217_TeVe-LETORT FABIEN(CCR - TOCC) 17-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131218MonteBaldoTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131218 Monte Baldo.hrm", "20131218MonteBaldo")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131218 Monte Baldo.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131219Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131219.hrm", "20131219")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131219.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131220BondoneTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131220 Bondone.hrm", "20131220Bondone")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131220 Bondone.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131220int10204x35MarcoScore20122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131220int10_20-4x(3'+5')_Marco_Score_20-12-2013.hrm", "20131220int10204x35MarcoScore20122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131220int10_20-4x(3'+5')_Marco_Score_20-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm2013122201ea0ce2acec7c4717b6934d119a45b7b9Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013122201ea0ce2ac-ec7c-4717-b693-4d119a45b7b9.hrm", "2013122201ea0ce2acec7c4717b6934d119a45b7b9")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013122201ea0ce2ac-ec7c-4717-b693-4d119a45b7b9.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm2013122202db6d324c7a1444fa9acb3be32cafa19bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013122202db6d324c-7a14-44fa-9acb-3be32cafa19b.hrm", "2013122202db6d324c7a1444fa9acb3be32cafa19b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013122202db6d324c-7a14-44fa-9acb-3be32cafa19b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm2013122249f0730f4ae54923a3a3282894141875Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013122249f0730f-4ae5-4923-a3a3-282894141875.hrm", "2013122249f0730f4ae54923a3a3282894141875")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013122249f0730f-4ae5-4923-a3a3-282894141875.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm2013122277f1465988784dd5999f91912361da86Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013122277f14659-8878-4dd5-999f-91912361da86.hrm", "2013122277f1465988784dd5999f91912361da86")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013122277f14659-8878-4dd5-999f-91912361da86.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131224BramontTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131224 Bramont.hrm", "20131224Bramont")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131224 Bramont.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131226VillardReculasTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131226 Villard Reculas.hrm", "20131226VillardReculas")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131226 Villard Reculas.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131228GiovoTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131228 Giovo.hrm", "20131228Giovo")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131228 Giovo.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131229SellarondaTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20131229 Sella ronda.hrm", "20131229Sellaronda")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20131229 Sella ronda.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131203TeVe1LETORTFABIENCCRTOCC03122013caf1f3647fb73ff4268b208dd586eb889c7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013_12_03_TeVe1-LETORT FABIEN(CCR - TOCC) 03-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm", "20131203TeVe1LETORTFABIENCCRTOCC03122013caf1f3647fb73ff4268b208dd586eb889c7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013_12_03_TeVe1-LETORT FABIEN(CCR - TOCC) 03-12-2013.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20131203TeVe1LETORTFABIENCCRTOCC03122013caf8bca3e82a7c244eda124fbd1df1943bbTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2013_12_03_TeVe1-LETORT FABIEN(CCR - TOCC) 03-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm", "20131203TeVe1LETORTFABIENCCRTOCC03122013caf8bca3e82a7c244eda124fbd1df1943bb")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2013_12_03_TeVe1-LETORT FABIEN(CCR - TOCC) 03-12-2013.caf8bca3e82-a7c2-44ed-a124-fbd1df1943bb.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140121Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2014-01-21.hrm", "20140121")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2014-01-21.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140121ce0e0883830d49cf826ded0631779627Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2014-01-21ce0e0883-830d-49cf-826d-ed0631779627.hrm", "20140121ce0e0883830d49cf826ded0631779627")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2014-01-21ce0e0883-830d-49cf-826d-ed0631779627.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm201401213x8tempoNeutrolioScore2112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2014-01-21_3x8tempo_Neutrolio_Score_21-1-2014.hrm", "201401213x8tempoNeutrolioScore2112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2014-01-21_3x8tempo_Neutrolio_Score_21-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm201401213x8tempoNeutrolioScore21120144da3c9d68a8d4c6ea89647cd34480f28Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2014-01-21_3x8tempo_Neutrolio_Score_21-1-20144da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm", "201401213x8tempoNeutrolioScore21120144da3c9d68a8d4c6ea89647cd34480f28")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2014-01-21_3x8tempo_Neutrolio_Score_21-1-20144da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140101ForcVelLETORTFABIENCCRTOCC01012014caf1f3647fb73ff4268b208dd586eb889c7Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140101_ForcVel-LETORT FABIEN(CCR - TOCC) 01-01-2014.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm", "20140101ForcVelLETORTFABIENCCRTOCC01012014caf1f3647fb73ff4268b208dd586eb889c7")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140101_ForcVel-LETORT FABIEN(CCR - TOCC) 01-01-2014.caf1f3647fb-73ff-4268-b208-dd586eb889c7.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140101TechVelLETORTFABIENCCRTOCC01012014cafad6f6859414143cd90c6200ecbb398efTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140101_TechVel-LETORT FABIEN(CCR - TOCC) 01-01-2014.cafad6f6859-4141-43cd-90c6-200ecbb398ef.hrm", "20140101TechVelLETORTFABIENCCRTOCC01012014cafad6f6859414143cd90c6200ecbb398ef")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140101_TechVel-LETORT FABIEN(CCR - TOCC) 01-01-2014.cafad6f6859-4141-43cd-90c6-200ecbb398ef.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140103MtWhitneyTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140103 Mt Whitney.hrm", "20140103MtWhitney")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140103 Mt Whitney.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140103e2dfb476bc2542108aa5d4c8b98c8a97Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140103e2dfb476-bc25-4210-8aa5-d4c8b98c8a97.hrm", "20140103e2dfb476bc2542108aa5d4c8b98c8a97")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140103e2dfb476-bc25-4210-8aa5-d4c8b98c8a97.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140105GardameerTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140105 Gardameer.hrm", "20140105Gardameer")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140105 Gardameer.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140105a00a9819783847b6aecd3c04ec53ca0eTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140105a00a9819-7838-47b6-aecd-3c04ec53ca0e.hrm", "20140105a00a9819783847b6aecd3c04ec53ca0e")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140105a00a9819-7838-47b6-aecd-3c04ec53ca0e.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140106FreeRideRichardSimpsonScore612014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140106 Free Ride_Richard Simpson_Score_6-1-2014.hrm", "20140106FreeRideRichardSimpsonScore612014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140106 Free Ride_Richard Simpson_Score_6-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140110145457Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140110_145457_.hrm", "20140110145457")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140110_145457_.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140116MtWhitneyTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140116 Mt Whitney.hrm", "20140116MtWhitney")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140116 Mt Whitney.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140116baseTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140116_base.hrm", "20140116base")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140116_base.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140118VillardReculasTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140118 Villard Reculas.hrm", "20140118VillardReculas")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140118 Villard Reculas.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140119CampolongoTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140119 Campolongo.hrm", "20140119Campolongo")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140119 Campolongo.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140121baseTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140121_base.hrm", "20140121base")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140121_base.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140125RichardSimpsonScore2512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140125_Richard Simpson_Score_25-1-2014.hrm", "20140125RichardSimpsonScore2512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140125_Richard Simpson_Score_25-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140126baseTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140126_base.hrm", "20140126base")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140126_base.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140127baseTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140127_base.hrm", "20140127base")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140127_base.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140128NeutrolioScore2812014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140128_Neutrolio_Score_28-1-2014.hrm", "20140128NeutrolioScore2812014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140128_Neutrolio_Score_28-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140128RichardSimpsonScore2812014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140128_Richard Simpson_Score_28-1-2014.hrm", "20140128RichardSimpsonScore2812014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140128_Richard Simpson_Score_28-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140129baseTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140129_base.hrm", "20140129base")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140129_base.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140129NeutrolioScore2912014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140129_Neutrolio_Score_29-1-2014.hrm", "20140129NeutrolioScore2912014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140129_Neutrolio_Score_29-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140131vomaxTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140131_vomax.hrm", "20140131vomax")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140131_vomax.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140203baseTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140203_base.hrm", "20140203base")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140203_base.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140205ftpTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140205_ftp.hrm", "20140205ftp")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140205_ftp.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140206BalinoTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140206 Balino.hrm", "20140206Balino")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140206 Balino.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140208BalinoTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140208 Balino.hrm", "20140208Balino")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140208 Balino.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140209BondoneTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140209 Bondone.hrm", "20140209Bondone")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140209 Bondone.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140211WhitneyTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140211 Whitney.hrm", "20140211Whitney")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140211 Whitney.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140215Lombardije7e3ecc6db58d45c0a227ef9d896ce72eTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140215 Lombardije7e3ecc6d-b58d-45c0-a227-ef9d896ce72e.hrm", "20140215Lombardije7e3ecc6db58d45c0a227ef9d896ce72e")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140215 Lombardije7e3ecc6d-b58d-45c0-a227-ef9d896ce72e.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140215Lombardije9182868069fc4e6a85dc25dc117ad2c5Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140215 Lombardije91828680-69fc-4e6a-85dc-25dc117ad2c5.hrm", "20140215Lombardije9182868069fc4e6a85dc25dc117ad2c5")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140215 Lombardije91828680-69fc-4e6a-85dc-25dc117ad2c5.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140215Lombardijed68dbb92077f4759a04e7e21e4bfeaf3Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20140215 Lombardijed68dbb92-077f-4759-a04e-7e21e4bfeaf3.hrm", "20140215Lombardijed68dbb92077f4759a04e7e21e4bfeaf3")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20140215 Lombardijed68dbb92-077f-4759-a04e-7e21e4bfeaf3.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140106095924Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2014_01_06_09_59_24.hrm", "20140106095924")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2014_01_06_09_59_24.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140108093429Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2014_01_08_09_34_29.hrm", "20140108093429")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2014_01_08_09_34_29.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20140109100121Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\2014_01_09_10_01_21.hrm", "20140109100121")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\2014_01_09_10_01_21.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20KLimpezaRecupLuisSilvaScore2512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20K Limpeza_Recup._Luis Silva_Score_25-1-2014.hrm", "20KLimpezaRecupLuisSilvaScore2512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20K Limpeza_Recup._Luis Silva_Score_25-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm20mintestDavidBaggeTacx27122013cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\20min test-David Bagge(Tacx) 27-12-2013.caf.hrm", "20mintestDavidBaggeTacx27122013caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\20min test-David Bagge(Tacx) 27-12-2013.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm21012014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\21.01.2014.hrm", "21012014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\21.01.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm230114Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\23.01.14.hrm", "230114")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\23.01.14.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm24KmHCAlbertoBArenasScore812014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\24 Km HC_Alberto B Arenas_Score_8-1-2014.hrm", "24KmHCAlbertoBArenasScore812014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\24 Km HC_Alberto B Arenas_Score_8-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm24kmsParqueEcologicoAlbertoBArenasScore2112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\24 kms Parque Ecologico_Alberto B Arenas_Score_21-1-2014.hrm", "24kmsParqueEcologicoAlbertoBArenasScore2112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\24 kms Parque Ecologico_Alberto B Arenas_Score_21-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm24kmsParqueEcologicoAlbertoBArenasScore2112014248db3fe29d345ae87ac9980f45c9574Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\24 kms Parque Ecologico_Alberto B Arenas_Score_21-1-2014248db3fe-29d3-45ae-87ac-9980f45c9574.hrm", "24kmsParqueEcologicoAlbertoBArenasScore2112014248db3fe29d345ae87ac9980f45c9574")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\24 kms Parque Ecologico_Alberto B Arenas_Score_21-1-2014248db3fe-29d3-45ae-87ac-9980f45c9574.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm250114Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\25.01.14.hrm", "250114")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\25.01.14.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm25022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\25.02.2014.hrm", "25022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\25.02.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm27022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\27.02.2014.hrm", "27022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\27.02.2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm280114Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\28.01.14.hrm", "280114")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\28.01.14.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm30minZ3DavidBaggeTacx09012014cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\30 min Z3-David Bagge(Tacx) 09-01-2014.caf.hrm", "30minZ3DavidBaggeTacx09012014caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\30 min Z3-David Bagge(Tacx) 09-01-2014.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm300114Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\30.01.14.hrm", "300114")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\30.01.14.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm30km4x5RMP5RecLuisSilvaScore622014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\30km 4x5' RMP 5'Rec_Luis Silva_Score_6-2-2014.hrm", "30km4x5RMP5RecLuisSilvaScore622014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\30km 4x5' RMP 5'Rec_Luis Silva_Score_6-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm30kmbaseSørenChristiansenScore1612014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\30kmbase_Søren Christiansen_Score_16-1-2014.hrm", "30kmbaseSørenChristiansenScore1612014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\30kmbase_Søren Christiansen_Score_16-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm35K4x5mRMPLuisSilvaScore2212014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\35K - 4x5mRMP_Luis Silva_Score_22-1-2014.hrm", "35K4x5mRMPLuisSilvaScore2212014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\35K - 4x5mRMP_Luis Silva_Score_22-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm35K1h20LuisSilvaScore2012014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\35K 1h20_Luis Silva_Score_20-1-2014.hrm", "35K1h20LuisSilvaScore2012014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\35K 1h20_Luis Silva_Score_20-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm4x12ChielKokScore1412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4 x 12'_Chiel Kok_Score_14-1-2014.hrm", "4x12ChielKokScore1412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4 x 12'_Chiel Kok_Score_14-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm4x12ChielKokScore24122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4 x 12'_Chiel Kok_Score_24-12-2013.hrm", "4x12ChielKokScore24122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4 x 12'_Chiel Kok_Score_24-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm46810864HansHofgaardTacx07012014cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4-6-8-10-8-6-4-Hans Hofgaard(Tacx) 07-01-2014.caf.hrm", "46810864HansHofgaardTacx07012014caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4-6-8-10-8-6-4-Hans Hofgaard(Tacx) 07-01-2014.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm4x5JohnClouseClouseScore112201305e709e1b423443f850b0586fd898516Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4x5_JohnClouse Clouse_Score_1-12-201305e709e1-b423-443f-850b-0586fd898516.hrm", "4x5JohnClouseClouseScore112201305e709e1b423443f850b0586fd898516")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4x5_JohnClouse Clouse_Score_1-12-201305e709e1-b423-443f-850b-0586fd898516.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm4x5JohnClouseClouseScore1122013c162f945b0164f909fd0ebb6a05f1b5bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4x5_JohnClouse Clouse_Score_1-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm", "4x5JohnClouseClouseScore1122013c162f945b0164f909fd0ebb6a05f1b5b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4x5_JohnClouse Clouse_Score_1-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm4x5JohnClouseClouseScore1122013fc5e8a6aed014a09867762d6251c0d7cTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4x5_JohnClouse Clouse_Score_1-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm", "4x5JohnClouseClouseScore1122013fc5e8a6aed014a09867762d6251c0d7c")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4x5_JohnClouse Clouse_Score_1-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm4x5JohnClouseClouseScore1612201305e709e1b423443f850b0586fd898516Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4x5_JohnClouse Clouse_Score_16-12-201305e709e1-b423-443f-850b-0586fd898516.hrm", "4x5JohnClouseClouseScore1612201305e709e1b423443f850b0586fd898516")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4x5_JohnClouse Clouse_Score_16-12-201305e709e1-b423-443f-850b-0586fd898516.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm4x5JohnClouseClouseScore16122013c162f945b0164f909fd0ebb6a05f1b5bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4x5_JohnClouse Clouse_Score_16-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm", "4x5JohnClouseClouseScore16122013c162f945b0164f909fd0ebb6a05f1b5b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4x5_JohnClouse Clouse_Score_16-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm4x5JohnClouseClouseScore16122013fc5e8a6aed014a09867762d6251c0d7cTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\4x5_JohnClouse Clouse_Score_16-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm", "4x5JohnClouseClouseScore16122013fc5e8a6aed014a09867762d6251c0d7c")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\4x5_JohnClouse Clouse_Score_16-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm50KmLuisSilvaScore1812014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\50Km_Luis Silva_Score_18-1-2014.hrm", "50KmLuisSilvaScore1812014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\50Km_Luis Silva_Score_18-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm60MinEndurance180WAvgJohnClouseClouseScore1812201305e709e1b423443f850b0586fd898516Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\60 Min Endurance - 180W Avg_JohnClouse Clouse_Score_18-12-201305e709e1-b423-443f-850b-0586fd898516.hrm", "60MinEndurance180WAvgJohnClouseClouseScore1812201305e709e1b423443f850b0586fd898516")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\60 Min Endurance - 180W Avg_JohnClouse Clouse_Score_18-12-201305e709e1-b423-443f-850b-0586fd898516.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm60MinEndurance180WAvgJohnClouseClouseScore18122013c162f945b0164f909fd0ebb6a05f1b5bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\60 Min Endurance - 180W Avg_JohnClouse Clouse_Score_18-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm", "60MinEndurance180WAvgJohnClouseClouseScore18122013c162f945b0164f909fd0ebb6a05f1b5b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\60 Min Endurance - 180W Avg_JohnClouse Clouse_Score_18-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm60MinEndurance180WAvgJohnClouseClouseScore18122013fc5e8a6aed014a09867762d6251c0d7cTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\60 Min Endurance - 180W Avg_JohnClouse Clouse_Score_18-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm", "60MinEndurance180WAvgJohnClouseClouseScore18122013fc5e8a6aed014a09867762d6251c0d7c")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\60 Min Endurance - 180W Avg_JohnClouse Clouse_Score_18-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm60MinEndurance198WAvgJohnClouseClouseScore1812201305e709e1b423443f850b0586fd898516Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\60 Min Endurance - 198W Avg_JohnClouse Clouse_Score_18-12-201305e709e1-b423-443f-850b-0586fd898516.hrm", "60MinEndurance198WAvgJohnClouseClouseScore1812201305e709e1b423443f850b0586fd898516")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\60 Min Endurance - 198W Avg_JohnClouse Clouse_Score_18-12-201305e709e1-b423-443f-850b-0586fd898516.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm60MinEndurance198WAvgJohnClouseClouseScore18122013c162f945b0164f909fd0ebb6a05f1b5bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\60 Min Endurance - 198W Avg_JohnClouse Clouse_Score_18-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm", "60MinEndurance198WAvgJohnClouseClouseScore18122013c162f945b0164f909fd0ebb6a05f1b5b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\60 Min Endurance - 198W Avg_JohnClouse Clouse_Score_18-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm60MinEndurance198WAvgJohnClouseClouseScore18122013fc5e8a6aed014a09867762d6251c0d7cTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\60 Min Endurance - 198W Avg_JohnClouse Clouse_Score_18-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm", "60MinEndurance198WAvgJohnClouseClouseScore18122013fc5e8a6aed014a09867762d6251c0d7c")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\60 Min Endurance - 198W Avg_JohnClouse Clouse_Score_18-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm8x1m4mssCarlTacx04012014cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\8x1m(4m ss)-Carl(Tacx) 04-01-2014.caf.hrm", "8x1m4mssCarlTacx04012014caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\8x1m(4m ss)-Carl(Tacx) 04-01-2014.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmabcParGSjostromScore612014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\abc_Par G Sjostrom_Score_6-1-2014.hrm", "abcParGSjostromScore612014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\abc_Par G Sjostrom_Score_6-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAC2x8JohnClouseClouseScore1712201305e709e1b423443f850b0586fd898516Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\AC 2 x 8_JohnClouse Clouse_Score_17-12-201305e709e1-b423-443f-850b-0586fd898516.hrm", "AC2x8JohnClouseClouseScore1712201305e709e1b423443f850b0586fd898516")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\AC 2 x 8_JohnClouse Clouse_Score_17-12-201305e709e1-b423-443f-850b-0586fd898516.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAC2x8JohnClouseClouseScore17122013c162f945b0164f909fd0ebb6a05f1b5bTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\AC 2 x 8_JohnClouse Clouse_Score_17-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm", "AC2x8JohnClouseClouseScore17122013c162f945b0164f909fd0ebb6a05f1b5b")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\AC 2 x 8_JohnClouse Clouse_Score_17-12-2013c162f945-b016-4f90-9fd0-ebb6a05f1b5b.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAC2x8JohnClouseClouseScore17122013fc5e8a6aed014a09867762d6251c0d7cTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\AC 2 x 8_JohnClouse Clouse_Score_17-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm", "AC2x8JohnClouseClouseScore17122013fc5e8a6aed014a09867762d6251c0d7c")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\AC 2 x 8_JohnClouse Clouse_Score_17-12-2013fc5e8a6a-ed01-4a09-8677-62d6251c0d7c.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrmagr338kmSanderScore1022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\agr 33,8 km_Sander_Score_10-2-2014.hrm", "agr338kmSanderScore1022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\agr 33,8 km_Sander_Score_10-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpedHuezSanderScore24122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpe_dHuez_Sander_Score_24-12-2013.hrm", "AlpedHuezSanderScore24122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpe_dHuez_Sander_Score_24-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic20101uur30jan14AddyRevetScore322014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - 1uur 30jan14_Addy Revet_Score_3-2-2014.hrm", "AlpineClassic20101uur30jan14AddyRevetScore322014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - 1uur 30jan14_Addy Revet_Score_3-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic20101uur30jan14AddyRevetScore3012014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - 1uur 30jan14_Addy Revet_Score_30-1-2014.hrm", "AlpineClassic20101uur30jan14AddyRevetScore3012014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - 1uur 30jan14_Addy Revet_Score_30-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic201059kmlaatste10AddyRevetScore2012014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - 5.9km laatste10 _Addy Revet_Score_20-1-2014.hrm", "AlpineClassic201059kmlaatste10AddyRevetScore2012014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - 5.9km laatste10 _Addy Revet_Score_20-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic201059kmlaatste10AddyRevetScore2712014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - 5.9km laatste10 _Addy Revet_Score_27-1-2014.hrm", "AlpineClassic201059kmlaatste10AddyRevetScore2712014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - 5.9km laatste10 _Addy Revet_Score_27-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic2010Alp1uurAddyRevetScore2512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - Alp 1uur_Addy Revet_Score_25-1-2014.hrm", "AlpineClassic2010Alp1uurAddyRevetScore2512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - Alp 1uur_Addy Revet_Score_25-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic2010Alplaatste5AddyRevetScore1922014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - Alp laatste 5_Addy Revet_Score_19-2-2014.hrm", "AlpineClassic2010Alplaatste5AddyRevetScore1922014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - Alp laatste 5_Addy Revet_Score_19-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic2010Alplaatste5AddyRevetScore2412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - Alp laatste 5_Addy Revet_Score_24-1-2014.hrm", "AlpineClassic2010Alplaatste5AddyRevetScore2412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - Alp laatste 5_Addy Revet_Score_24-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic2010GalibierogLautaretDescentAddyRevetScore412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - Galibier & Lautaret Descent_Addy Revet_Score_4-1-2014.hrm", "AlpineClassic2010GalibierogLautaretDescentAddyRevetScore412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - Galibier & Lautaret Descent_Addy Revet_Score_4-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic2010uuralp10febAddyRevetScore1022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010 - uur alp 10feb_Addy Revet_Score_10-2-2014.hrm", "AlpineClassic2010uuralp10febAddyRevetScore1022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010 - uur alp 10feb_Addy Revet_Score_10-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic2010ChristianBergAndersenScore1512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010_Christian Berg Andersen_Score_15-1-2014.hrm", "AlpineClassic2010ChristianBergAndersenScore1512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010_Christian Berg Andersen_Score_15-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic2010ChristianBergAndersenScore22122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010_Christian Berg Andersen_Score_22-12-2013.hrm", "AlpineClassic2010ChristianBergAndersenScore22122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010_Christian Berg Andersen_Score_22-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClassic2010ChristianBergAndersenScore412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Alpine Classic 2010_Christian Berg Andersen_Score_4-1-2014.hrm", "AlpineClassic2010ChristianBergAndersenScore412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Alpine Classic 2010_Christian Berg Andersen_Score_4-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAlpineClas10Antoineemmen07022014cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\AlpineClas10-Antoine(emmen) 07-02-2014.caf.HRM", "AlpineClas10Antoineemmen07022014caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\AlpineClas10-Antoine(emmen) 07-02-2014.caf.HRM");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAmstelGold2010AmstelGold3ekwartWiekdeWinterScore1912014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Amstel Gold 2010 - Amstel Gold 3e kwart_Wiek de Winter_Score_19-1-2014.hrm", "AmstelGold2010AmstelGold3ekwartWiekdeWinterScore1912014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Amstel Gold 2010 - Amstel Gold 3e kwart_Wiek de Winter_Score_19-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAmstelGold2010Part44JensMøllerMunkøeScore8122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Amstel Gold 2010 - Part 4_4_Jens Møller-Munkøe_Score_8-12-2013.hrm", "AmstelGold2010Part44JensMøllerMunkøeScore8122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Amstel Gold 2010 - Part 4_4_Jens Møller-Munkøe_Score_8-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmArgusCycleTour2010SouthAfricaCapeArgusLast50KsTrickyDRobinsonScore2812014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus - Last 50Ks_Tricky D Robinson_Score_28-1-2014.hrm", "ArgusCycleTour2010SouthAfricaCapeArgusLast50KsTrickyDRobinsonScore2812014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus - Last 50Ks_Tricky D Robinson_Score_28-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmArgusCycleTour2010SouthAfricaCapeArgusNext16ClicksTrickyDRobinsonScore622014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus - Next 16Clicks_Tricky D Robinson_Score_6-2-2014.hrm", "ArgusCycleTour2010SouthAfricaCapeArgusNext16ClicksTrickyDRobinsonScore622014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus - Next 16Clicks_Tricky D Robinson_Score_6-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmArgusCycleTour2010SouthAfricaCapeArgus1st55KTrickyDRobinsonScore522014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus 1st 55K_Tricky D Robinson_Score_5-2-2014.hrm", "ArgusCycleTour2010SouthAfricaCapeArgus1st55KTrickyDRobinsonScore522014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus 1st 55K_Tricky D Robinson_Score_5-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmArgusCycleTour2010SouthAfricaCapeArgus2nd30KsTrickyDRobinsonScore2612014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus 2nd 30Ks_Tricky D Robinson_Score_26-1-2014.hrm", "ArgusCycleTour2010SouthAfricaCapeArgus2nd30KsTrickyDRobinsonScore2612014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus 2nd 30Ks_Tricky D Robinson_Score_26-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmArgusCycleTour2010SouthAfricaCapeArgusTour1st30KsTrickyDRobinsonScore2612014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus Tour - 1st 30Ks_Tricky D Robinson_Score_26-1-2014.hrm", "ArgusCycleTour2010SouthAfricaCapeArgusTour1st30KsTrickyDRobinsonScore2612014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Argus Cycle Tour 2010 – South Africa - Cape Argus Tour - 1st 30Ks_Tricky D Robinson_Score_26-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmArgusCycleTour2010SouthAfricaMistyCliffsCapeTownRichardBrokhaugScore432014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Argus Cycle Tour 2010 – South Africa - Misty Cliffs - Cape Town_Richard Brokhaug_Score_4-3-2014.hrm", "ArgusCycleTour2010SouthAfricaMistyCliffsCapeTownRichardBrokhaugScore432014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Argus Cycle Tour 2010 – South Africa - Misty Cliffs - Cape Town_Richard Brokhaug_Score_4-3-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmArizonaCycleTourOakCreekCanyonRemkoScore132014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Arizona Cycle Tour - Oak Creek Canyon_Remko_Score_1-3-2014.hrm", "ArizonaCycleTourOakCreekCanyonRemkoScore132014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Arizona Cycle Tour - Oak Creek Canyon_Remko_Score_1-3-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmArnoa06c2f66a99a410bb3419b873cf59d31Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Arnoa06c2f66-a99a-410b-b341-9b873cf59d31.hrm", "Arnoa06c2f66a99a410bb3419b873cf59d31")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Arnoa06c2f66-a99a-410b-b341-9b873cf59d31.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmARW120130621Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\AR_W1_2013_06_21.hrm", "ARW120130621")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\AR_W1_2013_06_21.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmARW1201306214da3c9d68a8d4c6ea89647cd34480f28Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\AR_W1_2013_06_214da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm", "ARW1201306214da3c9d68a8d4c6ea89647cd34480f28")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\AR_W1_2013_06_214da3c9d6-8a8d-4c6e-a896-47cd34480f28.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAusdauer10JanKamiethScore2312014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Ausdauer 1.0_Jan Kamieth_Score_23-1-2014.hrm", "Ausdauer10JanKamiethScore2312014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Ausdauer 1.0_Jan Kamieth_Score_23-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmAusdauer10JanKamiethScore2512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Ausdauer 1.0_Jan Kamieth_Score_25-1-2014.hrm", "Ausdauer10JanKamiethScore2512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Ausdauer 1.0_Jan Kamieth_Score_25-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrmaydat2colsSanderScore712014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\aydat 2 cols_Sander_Score_7-1-2014.hrm", "aydat2colsSanderScore712014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\aydat 2 cols_Sander_Score_7-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBadIntervalTrainingmalcolmsmartScore612014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Bad Interval Training_malcolm smart_Score_6-1-2014.hrm", "BadIntervalTrainingmalcolmsmartScore612014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Bad Interval Training_malcolm smart_Score_6-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmbadChrisScore122014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\bad_Chris_Score_1-2-2014.hrm", "badChrisScore122014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\bad_Chris_Score_1-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBaldoI37bb155c31f54ee89f2b5aa8b9e40e2dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Baldo I37bb155c-31f5-4ee8-9f2b-5aa8b9e40e2d.hrm", "BaldoI37bb155c31f54ee89f2b5aa8b9e40e2d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Baldo I37bb155c-31f5-4ee8-9f2b-5aa8b9e40e2d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBaldoIa691681288834784a5b4e86ddd25e0cfTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Baldo Ia6916812-8883-4784-a5b4-e86ddd25e0cf.hrm", "BaldoIa691681288834784a5b4e86ddd25e0cf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Baldo Ia6916812-8883-4784-a5b4-e86ddd25e0cf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBaldoII37bb155c31f54ee89f2b5aa8b9e40e2dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Baldo II37bb155c-31f5-4ee8-9f2b-5aa8b9e40e2d.hrm", "BaldoII37bb155c31f54ee89f2b5aa8b9e40e2d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Baldo II37bb155c-31f5-4ee8-9f2b-5aa8b9e40e2d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBaldoIIa691681288834784a5b4e86ddd25e0cfTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Baldo IIa6916812-8883-4784-a5b4-e86ddd25e0cf.hrm", "BaldoIIa691681288834784a5b4e86ddd25e0cf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Baldo IIa6916812-8883-4784-a5b4-e86ddd25e0cf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBalino37bb155c31f54ee89f2b5aa8b9e40e2dTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Balino37bb155c-31f5-4ee8-9f2b-5aa8b9e40e2d.hrm", "Balino37bb155c31f54ee89f2b5aa8b9e40e2d")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Balino37bb155c-31f5-4ee8-9f2b-5aa8b9e40e2d.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBalino80ecb1abd5f14b0fb3af53fc4f63aab8Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Balino80ecb1ab-d5f1-4b0f-b3af-53fc4f63aab8.hrm", "Balino80ecb1abd5f14b0fb3af53fc4f63aab8")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Balino80ecb1ab-d5f1-4b0f-b3af-53fc4f63aab8.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmbarcshtChrisScore2322014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\barcsht_Chris_Score_23-2-2014.hrm", "barcshtChrisScore2322014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\barcsht_Chris_Score_23-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBondone3585d497a5134d9ab077b6f62fb9cd68Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Bondone3585d497-a513-4d9a-b077-b6f62fb9cd68.hrm", "Bondone3585d497a5134d9ab077b6f62fb9cd68")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Bondone3585d497-a513-4d9a-b077-b6f62fb9cd68.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRA14CasparvanStrijpScore1222014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRA 14_Caspar van  Strijp_Score_12-2-2014.hrm", "BRA14CasparvanStrijpScore1222014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRA 14_Caspar van  Strijp_Score_12-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRA1590minutterRichardBrokhaugScore1722014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRA 15 90 minutter_Richard Brokhaug_Score_17-2-2014.hrm", "BRA1590minutterRichardBrokhaugScore1722014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRA 15 90 minutter_Richard Brokhaug_Score_17-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRA1590minutterRichardBrokhaugScore31122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRA 15 90 minutter_Richard Brokhaug_Score_31-12-2013.hrm", "BRA1590minutterRichardBrokhaugScore31122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRA 15 90 minutter_Richard Brokhaug_Score_31-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRA15tilblock1454minutterRichardBrokhaugScore29122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRA 15 til block 14 54 minutter_Richard Brokhaug_Score_29-12-2013.hrm", "BRA15tilblock1454minutterRichardBrokhaugScore29122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRA 15 til block 14 54 minutter_Richard Brokhaug_Score_29-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRA16JanKamiethScore1612014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRA 16_Jan Kamieth_Score_16-1-2014.hrm", "BRA16JanKamiethScore1612014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRA 16_Jan Kamieth_Score_16-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRH15LouisPhilippeLeBlancScore222014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRH - 15_Louis-Philippe LeBlanc_Score_2-2-2014.hrm", "BRH15LouisPhilippeLeBlancScore222014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRH - 15_Louis-Philippe LeBlanc_Score_2-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRH16malcolmsmartScore712014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRH - 16_malcolm smart_Score_7-1-2014.hrm", "BRH16malcolmsmartScore712014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRH - 16_malcolm smart_Score_7-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRH17LouisPhilippeLeBlancScore412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRH - 17_Louis-Philippe LeBlanc_Score_4-1-2014.hrm", "BRH17LouisPhilippeLeBlancScore412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRH - 17_Louis-Philippe LeBlanc_Score_4-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRH17LuisSilvaScore1212014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRH - 17_Luis Silva_Score_12-1-2014.hrm", "BRH17LuisSilvaScore1212014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRH - 17_Luis Silva_Score_12-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRH19LouisPhilippeLeBlancScore1012014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRH - 19_Louis-Philippe LeBlanc_Score_10-1-2014.hrm", "BRH19LouisPhilippeLeBlancScore1012014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRH - 19_Louis-Philippe LeBlanc_Score_10-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRH20LouisPhilippeLeBlancScore25122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRH - 20_Louis-Philippe LeBlanc_Score_25-12-2013.hrm", "BRH20LouisPhilippeLeBlancScore25122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRH - 20_Louis-Philippe LeBlanc_Score_25-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRH20RichardBrokhaugScore1122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRH - 20_Richard Brokhaug_Score_1-12-2013.hrm", "BRH20RichardBrokhaugScore1122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRH - 20_Richard Brokhaug_Score_1-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRH15plantage13mLouisPhilippeLeBlancScore512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRH-15 plantage 13m_Louis-Philippe LeBlanc_Score_5-1-2014.hrm", "BRH15plantage13mLouisPhilippeLeBlancScore512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRH-15 plantage 13m_Louis-Philippe LeBlanc_Score_5-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI15LouisPhilippeLeBlancScore812014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 15_Louis-Philippe LeBlanc_Score_8-1-2014.hrm", "BRI15LouisPhilippeLeBlancScore812014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 15_Louis-Philippe LeBlanc_Score_8-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI16JanKamiethScore2112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 16_Jan Kamieth_Score_21-1-2014.hrm", "BRI16JanKamiethScore2112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 16_Jan Kamieth_Score_21-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI16LouisPhilippeLeBlancScore1512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 16_Louis-Philippe LeBlanc_Score_15-1-2014.hrm", "BRI16LouisPhilippeLeBlancScore1512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 16_Louis-Philippe LeBlanc_Score_15-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI16LouisPhilippeLeBlancScore24122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 16_Louis-Philippe LeBlanc_Score_24-12-2013.hrm", "BRI16LouisPhilippeLeBlancScore24122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 16_Louis-Philippe LeBlanc_Score_24-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI17JanKamiethScore122014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 17_Jan Kamieth_Score_1-2-2014.hrm", "BRI17JanKamiethScore122014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 17_Jan Kamieth_Score_1-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI17JanKamiethScore1312014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 17_Jan Kamieth_Score_13-1-2014.hrm", "BRI17JanKamiethScore1312014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 17_Jan Kamieth_Score_13-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI17JanKamiethScore20122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 17_Jan Kamieth_Score_20-12-2013.hrm", "BRI17JanKamiethScore20122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 17_Jan Kamieth_Score_20-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI17RichardBrokhaugScore312014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 17_Richard Brokhaug_Score_3-1-2014.hrm", "BRI17RichardBrokhaugScore312014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 17_Richard Brokhaug_Score_3-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRI18CasparvanStrijpScore322014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRI - 18_Caspar van  Strijp_Score_3-2-2014.hrm", "BRI18CasparvanStrijpScore322014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRI - 18_Caspar van  Strijp_Score_3-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRP16JanKamiethScore2212014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRP 16_Jan Kamieth_Score_22-1-2014.hrm", "BRP16JanKamiethScore2212014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRP 16_Jan Kamieth_Score_22-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRP16RichardBrokhaugScore1412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRP 16_Richard Brokhaug_Score_14-1-2014.hrm", "BRP16RichardBrokhaugScore1412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRP 16_Richard Brokhaug_Score_14-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBRTT16RichardBrokhaugScore1822014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\BRTT 16_Richard Brokhaug_Score_18-2-2014.hrm", "BRTT16RichardBrokhaugScore1822014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\BRTT 16_Richard Brokhaug_Score_18-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmbshoChrisScore722014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\bsho_Chris_Score_7-2-2014.hrm", "bshoChrisScore722014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\bsho_Chris_Score_7-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrmbteipen23012014exportTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\bteipen_23.01.2014_export.hrm", "bteipen23012014export")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\bteipen_23.01.2014_export.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBFlanders2007HannahSmithTacx06042013cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\B_Flanders2007-Hannah Smith(Tacx) 06-04-2013.caf.hrm", "BFlanders2007HannahSmithTacx06042013caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\B_Flanders2007-Hannah Smith(Tacx) 06-04-2013.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmBFlanders2007HannahSmithTacx12042013cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\B_Flanders2007-Hannah Smith(Tacx) 12-04-2013.caf.hrm", "BFlanders2007HannahSmithTacx12042013caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\B_Flanders2007-Hannah Smith(Tacx) 12-04-2013.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCaliforniaPacificCoastHighwayUSARemkoScore2322014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\California - Pacific Coast Highway - USA_Remko_Score_23-2-2014.hrm", "CaliforniaPacificCoastHighwayUSARemkoScore2322014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\California - Pacific Coast Highway - USA_Remko_Score_23-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCaliforniaWildflowerUSAmikiScore2312014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\California - Wildflower USA_miki_Score_23-1-2014.hrm", "CaliforniaWildflowerUSAmikiScore2312014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\California - Wildflower USA_miki_Score_23-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCaliforniaWildflowerUSAmikiScore2812014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\California - Wildflower USA_miki_Score_28-1-2014.hrm", "CaliforniaWildflowerUSAmikiScore2812014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\California - Wildflower USA_miki_Score_28-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCaliforniaWildflowerUSAmikiScore412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\California - Wildflower USA_miki_Score_4-1-2014.hrm", "CaliforniaWildflowerUSAmikiScore412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\California - Wildflower USA_miki_Score_4-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCaliforniaWildflowerUSAmikiScore512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\California - Wildflower USA_miki_Score_5-1-2014.hrm", "CaliforniaWildflowerUSAmikiScore512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\California - Wildflower USA_miki_Score_5-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCallistoRouteChrisScore21122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Callisto Route_Chris_Score_21-12-2013.hrm", "CallistoRouteChrisScore21122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Callisto Route_Chris_Score_21-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrmce144DavidBaggeTacx31122013cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\ce1 44-David Bagge(Tacx) 31-12-2013.caf.hrm", "ce144DavidBaggeTacx31122013caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\ce1 44-David Bagge(Tacx) 31-12-2013.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCE230DavidBaggeTacx28012014cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\CE2 30-David Bagge(Tacx) 28-01-2014.caf.hrm", "CE230DavidBaggeTacx28012014caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\CE2 30-David Bagge(Tacx) 28-01-2014.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCentaurusRouteChrisScore222014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Centaurus Route_Chris_Score_2-2-2014.hrm", "CentaurusRouteChrisScore222014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Centaurus Route_Chris_Score_2-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCentaurusRouteChrisScore2112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Centaurus Route_Chris_Score_21-1-2014.hrm", "CentaurusRouteChrisScore2112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Centaurus Route_Chris_Score_21-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCityTripBarcelonaRemkoScore1022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\City Trip - Barcelona_Remko_Score_10-2-2014.hrm", "CityTripBarcelonaRemkoScore1022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\City Trip - Barcelona_Remko_Score_10-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCityTripBarcelonaRemkoScore1912014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\City Trip - Barcelona_Remko_Score_19-1-2014.hrm", "CityTripBarcelonaRemkoScore1912014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\City Trip - Barcelona_Remko_Score_19-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCityTripBarcelonaRemkoScore532014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\City Trip - Barcelona_Remko_Score_5-3-2014.hrm", "CityTripBarcelonaRemkoScore532014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\City Trip - Barcelona_Remko_Score_5-3-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCooldown5minEspenTacx14122013cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Cool down 5 min-Espen(Tacx) 14-12-2013.caf.hrm", "Cooldown5minEspenTacx14122013caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Cool down 5 min-Espen(Tacx) 14-12-2013.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmCooldown5minEspenTacx30122013cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Cool down 5 min-Espen(Tacx) 30-12-2013.caf.hrm", "Cooldown5minEspenTacx30122013caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Cool down 5 min-Espen(Tacx) 30-12-2013.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmcrissxrampCarlTacx27122013cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\criss x + ramp-Carl(Tacx) 27-12-2013.caf.hrm", "crissxrampCarlTacx27122013caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\criss x + ramp-Carl(Tacx) 27-12-2013.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmD1Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\D1.hrm", "D1")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\D1.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrmd2d3blokkenTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\d2d3blokken.hrm", "d2d3blokken")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\d2d3blokken.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrmd3blokkenTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\d3blokken.hrm", "d3blokken")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\d3blokken.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDanubeNationalParkGermanyDanubeNationalParktildekksprakkRichardBrokhaugScore222014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Danube National Park - Germany - Danube National Park - til dekk sprakk_Richard Brokhaug_Score_2-2-2014.hrm", "DanubeNationalParkGermanyDanubeNationalParktildekksprakkRichardBrokhaugScore222014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Danube National Park - Germany - Danube National Park - til dekk sprakk_Richard Brokhaug_Score_2-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDanubeNationalParkGermanyRemkoScore29122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Danube National Park - Germany_Remko_Score_29-12-2013.hrm", "DanubeNationalParkGermanyRemkoScore29122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Danube National Park - Germany_Remko_Score_29-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDanubeNationalParkGermanyRichardBrokhaugScore1912014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Danube National Park - Germany_Richard Brokhaug_Score_19-1-2014.hrm", "DanubeNationalParkGermanyRichardBrokhaugScore1912014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Danube National Park - Germany_Richard Brokhaug_Score_19-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDenGyldnePedalIdarTorskangerpollScore512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Den Gyldne Pedal_Idar Torskangerpoll_Score_5-1-2014.hrm", "DenGyldnePedalIdarTorskangerpollScore512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Den Gyldne Pedal_Idar Torskangerpoll_Score_5-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDERothTriAph3XROBALTeam15122013cafTest() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\DE_Roth-Tri-Aph3X(ROBAL Team) 15-12-2013.caf.hrm", "DERothTriAph3XROBALTeam15122013caf")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\DE_Roth-Tri-Aph3X(ROBAL Team) 15-12-2013.caf.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDoradoRouteChrisScore1112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Dorado Route_Chris_Score_11-1-2014.hrm", "DoradoRouteChrisScore1112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Dorado Route_Chris_Score_11-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDoradoRouteChrisScore1922014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Dorado Route_Chris_Score_19-2-2014.hrm", "DoradoRouteChrisScore1922014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Dorado Route_Chris_Score_19-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDoradoRouteChrisScore2412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Dorado Route_Chris_Score_24-1-2014.hrm", "DoradoRouteChrisScore2412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Dorado Route_Chris_Score_24-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDoradoRouteChrisScore27122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Dorado Route_Chris_Score_27-12-2013.hrm", "DoradoRouteChrisScore27122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Dorado Route_Chris_Score_27-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadLesCalanchediPianaCorsicaPart12petrossampatakosScore132014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download -  Les Calanche di Piana - Corsica - Part 1 _ 2_petros sampatakos_Score_1-3-2014.hrm", "DownloadLesCalanchediPianaCorsicaPart12petrossampatakosScore132014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download -  Les Calanche di Piana - Corsica - Part 1 _ 2_petros sampatakos_Score_1-3-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadLesCalanchediPianaCorsicaDanFalconarScore2012014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download -  Les Calanche di Piana - Corsica_Dan Falconar_Score_20-1-2014.hrm", "DownloadLesCalanchediPianaCorsicaDanFalconarScore2012014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download -  Les Calanche di Piana - Corsica_Dan Falconar_Score_20-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadLesCalanchediPianaCorsicaDanFalconarScore412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download -  Les Calanche di Piana - Corsica_Dan Falconar_Score_4-1-2014.hrm", "DownloadLesCalanchediPianaCorsicaDanFalconarScore412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download -  Les Calanche di Piana - Corsica_Dan Falconar_Score_4-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadCapdeFormentorMajorcaSpainpetrossampatakosScore922014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - Cap de Formentor - Majorca Spain_petros sampatakos_Score_9-2-2014.hrm", "DownloadCapdeFormentorMajorcaSpainpetrossampatakosScore922014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - Cap de Formentor - Majorca Spain_petros sampatakos_Score_9-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadColdeBavellaCorsicaDanFalconarScore24122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - Col de Bavella - Corsica_Dan Falconar_Score_24-12-2013.hrm", "DownloadColdeBavellaCorsicaDanFalconarScore24122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - Col de Bavella - Corsica_Dan Falconar_Score_24-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadColdeBavellaCorsicaDanFalconarScore27122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - Col de Bavella - Corsica_Dan Falconar_Score_27-12-2013.hrm", "DownloadColdeBavellaCorsicaDanFalconarScore27122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - Col de Bavella - Corsica_Dan Falconar_Score_27-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadColdeBavellaCorsicaDanFalconarScore31122013Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - Col de Bavella - Corsica_Dan Falconar_Score_31-12-2013.hrm", "DownloadColdeBavellaCorsicaDanFalconarScore31122013")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - Col de Bavella - Corsica_Dan Falconar_Score_31-12-2013.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadGorgesduCiansFrenchAlpsDanFalconarScore1112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - Gorges du Cians - French Alps_Dan Falconar_Score_11-1-2014.hrm", "DownloadGorgesduCiansFrenchAlpsDanFalconarScore1112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - Gorges du Cians - French Alps_Dan Falconar_Score_11-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadGorgesduCiansFrenchAlpsDanFalconarScore212014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - Gorges du Cians - French Alps_Dan Falconar_Score_2-1-2014.hrm", "DownloadGorgesduCiansFrenchAlpsDanFalconarScore212014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - Gorges du Cians - French Alps_Dan Falconar_Score_2-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadRoutedesGrandsCrusBurgundyFranceRobertPedersenScore1912014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - Route des Grands Crus - Burgundy France_Robert Pedersen_Score_19-1-2014.hrm", "DownloadRoutedesGrandsCrusBurgundyFranceRobertPedersenScore1912014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - Route des Grands Crus - Burgundy France_Robert Pedersen_Score_19-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadTheAubeValley2012FranceRobertPedersenScore222014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - The Aube Valley 2012 - France_Robert Pedersen_Score_2-2-2014.hrm", "DownloadTheAubeValley2012FranceRobertPedersenScore222014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - The Aube Valley 2012 - France_Robert Pedersen_Score_2-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadTheAubeValley2012FranceRobertPedersenScore2012014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - The Aube Valley 2012 - France_Robert Pedersen_Score_20-1-2014.hrm", "DownloadTheAubeValley2012FranceRobertPedersenScore2012014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - The Aube Valley 2012 - France_Robert Pedersen_Score_20-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDownloadTheAubeValley2012FranceRobertPedersenScore3112014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Download - The Aube Valley 2012 - France_Robert Pedersen_Score_31-1-2014.hrm", "DownloadTheAubeValley2012FranceRobertPedersenScore3112014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Download - The Aube Valley 2012 - France_Robert Pedersen_Score_31-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDrakoCourseChrisScore1022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Drako Course_Chris_Score_10-2-2014.hrm", "DrakoCourseChrisScore1022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Drako Course_Chris_Score_10-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDrakoCourseChrisScore2022014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Drako Course_Chris_Score_20-2-2014.hrm", "DrakoCourseChrisScore2022014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Drako Course_Chris_Score_20-2-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDrakoCourseChrisScore412014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Drako Course_Chris_Score_4-1-2014.hrm", "DrakoCourseChrisScore412014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Drako Course_Chris_Score_4-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmDrakoCourseSanderScore1512014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Drako Course_Sander_Score_15-1-2014.hrm", "DrakoCourseSanderScore1512014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Drako Course_Sander_Score_15-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void HrmElbaTourItaly022412PaulScore612014Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\Elba Tour - Italy - 022412_Paul_Score_6-1-2014.hrm", "ElbaTourItaly022412PaulScore612014")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\Elba Tour - Italy - 022412_Paul_Score_6-1-2014.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
			result.ErrorMessages.Count.ShouldEqual(0);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                //firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
    }
}

