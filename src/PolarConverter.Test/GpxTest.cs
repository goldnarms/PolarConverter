using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Entiteter;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class GpxTest : BaseTest
    {
        [TestMethod]
        public void EnsureGpxCoordinates()
        {
            ViewModel.TimeZoneOffset = 1;
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"Gpx\14072801.hrm", "14072801", @"Gpx\14072801.gpx", gpxVersion: "1.0")
            };
            this.SetPolarFiles(polarFiles);
            var result = ConversionService.Convert(ViewModel);
            ZipFileReference = result.Reference;
            var fileReferences = StorageHelper.Unzip(result.Reference);
            fileReferences.Count().ShouldEqual(1);
            foreach (var reference in fileReferences)
            {
                var trainingDoc = StorageHelper.ReadXmlDocument(reference, typeof(TrainingCenterDatabase_t)) as TrainingCenterDatabase_t;
                var lap01 = trainingDoc.Activities.Activity[0].Lap[0];
                lap01.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 12, 44));
                lap01.Track[0].Position.LatitudeDegrees.ShouldEqual(45.133450000);
                lap01.Track[0].Position.LongitudeDegrees.ShouldEqual(1.178340000);
                var lap02 = trainingDoc.Activities.Activity[0].Lap[1];
                lap02.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 17, 44, 100));
                lap02.Track[0].Position.LatitudeDegrees.ShouldEqual(45.134180000);
                lap02.Track[0].Position.LongitudeDegrees.ShouldEqual(1.186673333);
                var lap03 = trainingDoc.Activities.Activity[0].Lap[2];
                lap03.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 17, 45, 100));
                lap03.Track[0].Position.LatitudeDegrees.ShouldEqual(45.134183333);
                lap03.Track[0].Position.LongitudeDegrees.ShouldEqual(1.186715000);
                var lap04 = trainingDoc.Activities.Activity[0].Lap[3];
                lap04.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 22, 41, 300));
                lap04.Track[0].Position.LatitudeDegrees.ShouldEqual(45.134486667);
                lap04.Track[0].Position.LongitudeDegrees.ShouldEqual(1.197663333);
                var lap05 = trainingDoc.Activities.Activity[0].Lap[4];
                lap05.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 27, 38, 200));
                lap05.Track[0].Position.LatitudeDegrees.ShouldEqual(45.129550000);
                lap05.Track[0].Position.LongitudeDegrees.ShouldEqual(1.207691667);
                var lap06 = trainingDoc.Activities.Activity[0].Lap[5];
                lap06.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 27, 45, 500));
                lap06.Track[0].Position.LatitudeDegrees.ShouldEqual(45.129473333);
                lap06.Track[0].Position.LongitudeDegrees.ShouldEqual(1.207973333);
                var lap07 = trainingDoc.Activities.Activity[0].Lap[6];
                lap07.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 32, 14));
                lap07.Track[0].Position.LatitudeDegrees.ShouldEqual(45.126201667);
                lap07.Track[0].Position.LongitudeDegrees.ShouldEqual(1.219215000);
                var lap08 = trainingDoc.Activities.Activity[0].Lap[7];
                lap08.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 37, 3, 700));
                lap08.Track[0].Position.LatitudeDegrees.ShouldEqual(45.126843333);
                lap08.Track[0].Position.LongitudeDegrees.ShouldEqual(1.217358333);
                var lap09 = trainingDoc.Activities.Activity[0].Lap[8];
                lap09.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 6, 37, 45, 400));
                lap09.Track[0].Position.LatitudeDegrees.ShouldEqual(45.127420000);
                lap09.Track[0].Position.LongitudeDegrees.ShouldEqual(1.215740000);
                var lap26 = trainingDoc.Activities.Activity[0].Lap[25];
                lap26.StartTime.ShouldEqual(new DateTime(2014, 7, 28, 7, 9, 25, 400));
                lap26.Track[0].Position.LatitudeDegrees.ShouldEqual(45.133636667);
                lap26.Track[0].Position.LongitudeDegrees.ShouldEqual(1.178370000);

            }
        }

    }
}
