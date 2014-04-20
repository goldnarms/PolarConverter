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
        public void Hrm12052201Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052201.hrm", "12052201")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052201.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052202Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052202.hrm", "12052202")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052202.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052203Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052203.hrm", "12052203")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052203.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052301.hrm", "12052301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052302.hrm", "12052302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052401Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052401.hrm", "12052401")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052401.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052402.hrm", "12052402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052403Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052403.hrm", "12052403")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052403.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052404Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052404.hrm", "12052404")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052404.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052405Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052405.hrm", "12052405")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052405.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052406Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052406.hrm", "12052406")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052406.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052407Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052407.hrm", "12052407")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052407.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052501Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052501.hrm", "12052501")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052501.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052502Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052502.hrm", "12052502")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052502.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052503Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052503.hrm", "12052503")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052503.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052504Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052504.hrm", "12052504")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052504.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052701Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052701.hrm", "12052701")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052701.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052702Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052702.hrm", "12052702")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052702.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052703Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052703.hrm", "12052703")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052703.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052704Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052704.hrm", "12052704")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052704.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052801Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052801.hrm", "12052801")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052801.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052802Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052802.hrm", "12052802")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052802.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052803Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052803.hrm", "12052803")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052803.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052804Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052804.hrm", "12052804")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052804.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052805Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052805.hrm", "12052805")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052805.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052806Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052806.hrm", "12052806")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052806.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052901.hrm", "12052901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052902.hrm", "12052902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052903Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052903.hrm", "12052903")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052903.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12052904Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12052904.hrm", "12052904")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12052904.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053001Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053001.hrm", "12053001")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053001.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053002Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053002.hrm", "12053002")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053002.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053003Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053003.hrm", "12053003")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053003.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053004Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053004.hrm", "12053004")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053004.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053005Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053005.hrm", "12053005")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053005.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053101Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053101.hrm", "12053101")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053101.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053102Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053102.hrm", "12053102")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053102.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053103Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053103.hrm", "12053103")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053103.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053104Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053104.hrm", "12053104")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053104.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053105Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053105.hrm", "12053105")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053105.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12053106Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12053106.hrm", "12053106")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12053106.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060101Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060101.hrm", "12060101")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060101.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060102Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060102.hrm", "12060102")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060102.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060103Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060103.hrm", "12060103")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060103.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060104Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060104.hrm", "12060104")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060104.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060105Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060105.hrm", "12060105")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060105.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060106Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060106.hrm", "12060106")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060106.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060107Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060107.hrm", "12060107")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060107.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060301.hrm", "12060301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060302.hrm", "12060302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060401Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060401.hrm", "12060401")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060401.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060402.hrm", "12060402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060901.hrm", "12060901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12060902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12060902.hrm", "12060902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12060902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061001Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061001.hrm", "12061001")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061001.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061002Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061002.hrm", "12061002")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061002.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061101Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061101.hrm", "12061101")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061101.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061102Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061102.hrm", "12061102")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061102.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061103Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061103.hrm", "12061103")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061103.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061104Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061104.hrm", "12061104")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061104.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061105Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061105.hrm", "12061105")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061105.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061201Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061201.hrm", "12061201")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061201.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061202Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061202.hrm", "12061202")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061202.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061203Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061203.hrm", "12061203")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061203.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061204Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061204.hrm", "12061204")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061204.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061301.hrm", "12061301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061302.hrm", "12061302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061401Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061401.hrm", "12061401")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061401.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061402.hrm", "12061402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061403Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061403.hrm", "12061403")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061403.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061404Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061404.hrm", "12061404")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061404.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061501Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061501.hrm", "12061501")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061501.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061502Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061502.hrm", "12061502")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061502.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061503Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061503.hrm", "12061503")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061503.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061504Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061504.hrm", "12061504")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061504.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061801Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061801.hrm", "12061801")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061801.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061802Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061802.hrm", "12061802")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061802.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061803Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061803.hrm", "12061803")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061803.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061804Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061804.hrm", "12061804")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061804.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061901.hrm", "12061901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061902.hrm", "12061902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061903Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061903.hrm", "12061903")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061903.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061904Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061904.hrm", "12061904")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061904.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12061905Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12061905.hrm", "12061905")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12061905.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062001Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062001.hrm", "12062001")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062001.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062002Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062002.hrm", "12062002")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062002.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062003Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062003.hrm", "12062003")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062003.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062004Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062004.hrm", "12062004")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062004.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062101Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062101.hrm", "12062101")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062101.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062102Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062102.hrm", "12062102")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062102.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062103Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062103.hrm", "12062103")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062103.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062104Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062104.hrm", "12062104")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062104.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062201Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062201.hrm", "12062201")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062201.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062202Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062202.hrm", "12062202")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062202.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062203Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062203.hrm", "12062203")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062203.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062204Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062204.hrm", "12062204")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062204.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062205Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062205.hrm", "12062205")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062205.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062206Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062206.hrm", "12062206")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062206.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062207Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062207.hrm", "12062207")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062207.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062301.hrm", "12062301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062302.hrm", "12062302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062402.hrm", "12062402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062403Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062403.hrm", "12062403")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062403.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062404Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062404.hrm", "12062404")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062404.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062405Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062405.hrm", "12062405")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062405.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062501Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062501.hrm", "12062501")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062501.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062502Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062502.hrm", "12062502")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062502.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062503Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062503.hrm", "12062503")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062503.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062504Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062504.hrm", "12062504")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062504.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062505Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062505.hrm", "12062505")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062505.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062601Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062601.hrm", "12062601")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062601.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062602Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062602.hrm", "12062602")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062602.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062603Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062603.hrm", "12062603")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062603.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062604Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062604.hrm", "12062604")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062604.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062605Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062605.hrm", "12062605")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062605.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062606Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062606.hrm", "12062606")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062606.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062607Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062607.hrm", "12062607")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062607.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062701Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062701.hrm", "12062701")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062701.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062702Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062702.hrm", "12062702")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062702.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062703Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062703.hrm", "12062703")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062703.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062704Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062704.hrm", "12062704")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062704.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062705Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062705.hrm", "12062705")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062705.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062801Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062801.hrm", "12062801")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062801.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062802Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062802.hrm", "12062802")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062802.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062803Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062803.hrm", "12062803")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062803.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062804Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062804.hrm", "12062804")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062804.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062805Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062805.hrm", "12062805")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062805.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062806Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062806.hrm", "12062806")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062806.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062807Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062807.hrm", "12062807")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062807.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062808Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062808.hrm", "12062808")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062808.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062809Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062809.hrm", "12062809")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062809.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062901.hrm", "12062901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12062902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12062902.hrm", "12062902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12062902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070201Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070201.hrm", "12070201")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070201.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070202Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070202.hrm", "12070202")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070202.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070203Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070203.hrm", "12070203")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070203.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070204Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070204.hrm", "12070204")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070204.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070205Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070205.hrm", "12070205")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070205.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070206Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070206.hrm", "12070206")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070206.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070207Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070207.hrm", "12070207")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070207.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070208Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070208.hrm", "12070208")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070208.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070301.hrm", "12070301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070302.hrm", "12070302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070303Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070303.hrm", "12070303")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070303.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070304Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070304.hrm", "12070304")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070304.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070305Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070305.hrm", "12070305")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070305.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070306Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070306.hrm", "12070306")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070306.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070307Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070307.hrm", "12070307")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070307.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070308Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070308.hrm", "12070308")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070308.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070309Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070309.hrm", "12070309")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070309.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070310Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070310.hrm", "12070310")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070310.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070311Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070311.hrm", "12070311")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070311.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070312Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070312.hrm", "12070312")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070312.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070401Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070401.hrm", "12070401")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070401.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070402.hrm", "12070402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070403Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070403.hrm", "12070403")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070403.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070404Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070404.hrm", "12070404")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070404.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070405Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070405.hrm", "12070405")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070405.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070406Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070406.hrm", "12070406")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070406.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070501Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070501.hrm", "12070501")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070501.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070502Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070502.hrm", "12070502")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070502.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070503Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070503.hrm", "12070503")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070503.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070504Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070504.hrm", "12070504")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070504.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070505Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070505.hrm", "12070505")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070505.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070506Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070506.hrm", "12070506")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070506.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070507Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070507.hrm", "12070507")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070507.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070508Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070508.hrm", "12070508")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070508.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070509Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070509.hrm", "12070509")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070509.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070510Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070510.hrm", "12070510")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070510.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070511Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070511.hrm", "12070511")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070511.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070512Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070512.hrm", "12070512")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070512.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070601Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070601.hrm", "12070601")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070601.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070602Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070602.hrm", "12070602")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070602.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070603Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070603.hrm", "12070603")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070603.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070604Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070604.hrm", "12070604")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070604.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070605Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070605.hrm", "12070605")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070605.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070606Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070606.hrm", "12070606")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070606.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070701Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070701.hrm", "12070701")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070701.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070702Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070702.hrm", "12070702")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070702.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070801Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070801.hrm", "12070801")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070801.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070802Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070802.hrm", "12070802")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070802.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070803Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070803.hrm", "12070803")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070803.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070804Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070804.hrm", "12070804")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070804.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070901.hrm", "12070901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12070902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12070902.hrm", "12070902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12070902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071001Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071001.hrm", "12071001")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071001.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071002Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071002.hrm", "12071002")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071002.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071003Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071003.hrm", "12071003")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071003.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071004Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071004.hrm", "12071004")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071004.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071005Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071005.hrm", "12071005")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071005.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071006Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071006.hrm", "12071006")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071006.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071007Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071007.hrm", "12071007")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071007.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071008Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071008.hrm", "12071008")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071008.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071101Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071101.hrm", "12071101")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071101.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071102Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071102.hrm", "12071102")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071102.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071103Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071103.hrm", "12071103")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071103.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071104Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071104.hrm", "12071104")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071104.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071105Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071105.hrm", "12071105")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071105.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071106Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071106.hrm", "12071106")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071106.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071107Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071107.hrm", "12071107")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071107.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071108Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071108.hrm", "12071108")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071108.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071201Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071201.hrm", "12071201")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071201.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071202Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071202.hrm", "12071202")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071202.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071301.hrm", "12071301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071302.hrm", "12071302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071303Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071303.hrm", "12071303")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071303.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071304Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071304.hrm", "12071304")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071304.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071305Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071305.hrm", "12071305")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071305.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071306Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071306.hrm", "12071306")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071306.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071401Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071401.hrm", "12071401")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071401.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071402.hrm", "12071402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071403Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071403.hrm", "12071403")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071403.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071404Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071404.hrm", "12071404")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071404.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071405Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071405.hrm", "12071405")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071405.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071406Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071406.hrm", "12071406")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071406.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071407Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071407.hrm", "12071407")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071407.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071408Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071408.hrm", "12071408")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071408.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071409Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071409.hrm", "12071409")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071409.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071410Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071410.hrm", "12071410")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071410.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071501Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071501.hrm", "12071501")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071501.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071502Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071502.hrm", "12071502")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071502.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071503Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071503.hrm", "12071503")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071503.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm120715041Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071504 (1).hrm", "120715041")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071504 (1).hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071504Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071504.hrm", "12071504")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071504.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071505Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071505.hrm", "12071505")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071505.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071506Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071506.hrm", "12071506")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071506.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071701Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071701.hrm", "12071701")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071701.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071702Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071702.hrm", "12071702")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071702.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071703Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071703.hrm", "12071703")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071703.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071704Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071704.hrm", "12071704")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071704.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071705Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071705.hrm", "12071705")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071705.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071706Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071706.hrm", "12071706")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071706.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071707Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071707.hrm", "12071707")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071707.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071708Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071708.hrm", "12071708")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071708.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071709Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071709.hrm", "12071709")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071709.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071710Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071710.hrm", "12071710")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071710.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071801Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071801.hrm", "12071801")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071801.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071802Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071802.hrm", "12071802")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071802.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071803Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071803.hrm", "12071803")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071803.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071804Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071804.hrm", "12071804")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071804.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071805Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071805.hrm", "12071805")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071805.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071806Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071806.hrm", "12071806")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071806.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071901.hrm", "12071901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071902.hrm", "12071902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071903Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071903.hrm", "12071903")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071903.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071904Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071904.hrm", "12071904")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071904.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071905Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071905.hrm", "12071905")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071905.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071906Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071906.hrm", "12071906")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071906.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071907Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071907.hrm", "12071907")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071907.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12071908Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12071908.hrm", "12071908")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12071908.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072001Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072001.hrm", "12072001")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072001.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072002Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072002.hrm", "12072002")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072002.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072003Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072003.hrm", "12072003")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072003.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072004Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072004.hrm", "12072004")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072004.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072005Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072005.hrm", "12072005")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072005.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072006Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072006.hrm", "12072006")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072006.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072101Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072101.hrm", "12072101")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072101.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072102Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072102.hrm", "12072102")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072102.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072103Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072103.hrm", "12072103")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072103.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072104Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072104.hrm", "12072104")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072104.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072105Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072105.hrm", "12072105")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072105.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072106Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072106.hrm", "12072106")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072106.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072201Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072201.hrm", "12072201")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072201.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072202Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072202.hrm", "12072202")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072202.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072301.hrm", "12072301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072302.hrm", "12072302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072303Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072303.hrm", "12072303")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072303.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072304Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072304.hrm", "12072304")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072304.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072305Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072305.hrm", "12072305")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072305.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072306Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072306.hrm", "12072306")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072306.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072307Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072307.hrm", "12072307")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072307.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072308Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072308.hrm", "12072308")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072308.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072309Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072309.hrm", "12072309")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072309.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072310Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072310.hrm", "12072310")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072310.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072401Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072401.hrm", "12072401")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072401.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072402.hrm", "12072402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072501Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072501.hrm", "12072501")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072501.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072502Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072502.hrm", "12072502")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072502.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072503Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072503.hrm", "12072503")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072503.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072504Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072504.hrm", "12072504")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072504.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072601Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072601.hrm", "12072601")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072601.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072602Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072602.hrm", "12072602")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072602.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072901.hrm", "12072901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072902.hrm", "12072902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072903Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072903.hrm", "12072903")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072903.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072904Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072904.hrm", "12072904")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072904.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072905Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072905.hrm", "12072905")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072905.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12072906Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12072906.hrm", "12072906")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12072906.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12073001Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12073001.hrm", "12073001")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12073001.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12073002Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12073002.hrm", "12073002")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12073002.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12073003Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12073003.hrm", "12073003")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12073003.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12073004Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12073004.hrm", "12073004")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12073004.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12073005Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12073005.hrm", "12073005")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12073005.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12073006Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12073006.hrm", "12073006")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12073006.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080101Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080101.hrm", "12080101")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080101.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080102Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080102.hrm", "12080102")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080102.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080103Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080103.hrm", "12080103")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080103.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080104Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080104.hrm", "12080104")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080104.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080105Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080105.hrm", "12080105")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080105.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080106Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080106.hrm", "12080106")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080106.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080301.hrm", "12080301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080302.hrm", "12080302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080601Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080601.hrm", "12080601")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080601.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080602Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080602.hrm", "12080602")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080602.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080701Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080701.hrm", "12080701")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080701.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080702Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080702.hrm", "12080702")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080702.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080901Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080901.hrm", "12080901")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080901.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12080902Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12080902.hrm", "12080902")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12080902.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12081001Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12081001.hrm", "12081001")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12081001.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12081002Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12081002.hrm", "12081002")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12081002.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12081301Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12081301.hrm", "12081301")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12081301.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12081302Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12081302.hrm", "12081302")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12081302.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12081401Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12081401.hrm", "12081401")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12081401.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
	

        [TestMethod]
        public void Hrm12081402Test() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"PolarFiler\12081402.hrm", "12081402")
            };
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(@"C:\Google Drive\Prosjekt\Polar\PolarFiler\12081402.hrm");
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                //trainingDoc.Activities.Activity[0].Lap.Sum(l => l.TotalTimeSeconds).ShouldEqual(duration);
                var firstLap = trainingDoc.Activities.Activity[0].Lap[0];
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                firstLap.Track[0].AltitudeMetersSpecified.ShouldEqual(hasAltitude);
                firstLap.Track[0].CadenceSpecified.ShouldEqual(hasCadence);
                firstLap.StartTime.ShouldEqual(startTime);
            }

        }
    }
}

