using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Services;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class KalorierTester: BaseTest
    {
        [TestMethod]
        public void TommeKalorier()
        {
            var polarFiles = new[]
            {
                TestHelper.GeneratePolarFile(@"TommeKalorier\12101601.hrm", "12101601", @"TommeKalorier\12101601.gpx", gpxVersion:"1.0")
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
                const byte avgHeartrate = 0, maxHeartrate = 0;
                firstLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate);
                firstLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate);
                firstLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 10, 16, 22, 06, 08).ToShortDateString());
                firstLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 10, 16, 22, 06, 08).ToShortTimeString());
                firstLap.CadenceSpecified.ShouldBeTrue();
                firstLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();
                firstLap.Calories.ShouldBeGreaterThan(Zero);
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(484.6);
                const byte avgHeartrate2 = 130, maxHeartrate2 = 130;
                var secondLap = trainingDoc.Activities.Activity[0].Lap[1];
                secondLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate2);
                secondLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate2);
                secondLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 10, 16, 22, 06, 08).ToShortDateString());
                secondLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 10, 16, 22, 06, 08).ToShortTimeString());
                secondLap.CadenceSpecified.ShouldBeTrue();
                secondLap.Track.First().AltitudeMetersSpecified.ShouldBeFalse();

                TestHelper.AssertCadAltAvgMaxStarttime(firstLap, 0, 0, new DateTime(2012, 10, 16, 18, 06, 08), false, true).ShouldBeTrue();
                var secondLap = trainingDoc.Activities.Activity[0].Lap[1];
                TestHelper.AssertCadAltAvgMaxStarttime(secondLap, 147, 163, new DateTime(2012, 10, 16, 18, 06, 08),
                    false, true).ShouldBeTrue();
                ushort cal = 77;
                secondLap.Calories.ShouldEqual(cal);
                secondLap.TotalTimeSeconds.ShouldEqual(423.5);
            }
        }
    }
}
