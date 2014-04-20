using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Helpers;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class TestFile : BaseTest
    {
        private static readonly string FileRoot = ConfigurationManager.AppSettings["rootPath"];
        [TestMethod]
        public void TestFiles() 
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Duration\12101601_2.hrm", "12101601_2")
            };

            //string[] filePaths = Directory.GetFiles(@"c:\MyDir\", "*.bmp",
            //                             SearchOption.AllDirectories);
            //foreach (var filePath in filePaths)
            //{
            //    var fileName = filePath.Substring(filePath.LastIndexOf("\\"), filePath.Length - filePath.LastIndexOf("\\") - 4).Trim().Replace("(", ");
            //}
            this.SetPolarFiles(polarFiles);
            var fileContent = File.ReadAllText(string.Format(FileRoot + "{0}", @"Duration\12101601_2.hrm"));
            var hasAltitude = StringHelper.HentVerdi("SMode=", 1, fileContent, 2) == "1";
            var hasCadence = StringHelper.HentVerdi("SMode=", 1, fileContent, 1) == "1";
            var date = StringHelper.HentVerdi("Date=", 8, fileContent);
            var time = StringHelper.HentVerdi("StartTime=", 10, fileContent);
            var startTime = string.Format("{0} {1}", date, time).KonverterTilDato().AddHours(ViewModel.TimeZoneOffset);
            var duration = StringHelper.HentVerdi("Length=", 10, fileContent).ToTimeSpan().TotalSeconds;
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
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
