﻿using System;
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
                firstLap.CadenceSpecified.ShouldBeFalse();
                Math.Round(firstLap.TotalTimeSeconds, 1).ShouldEqual(0);
                const byte avgHeartrate2 = 147, maxHeartrate2 = 163;
                var secondLap = trainingDoc.Activities.Activity[0].Lap[1];
                secondLap.AverageHeartRateBpm.Value.ShouldEqual(avgHeartrate2);
                secondLap.MaximumHeartRateBpm.Value.ShouldEqual(maxHeartrate2);
                secondLap.StartTime.ToShortDateString().ShouldEqual(new DateTime(2012, 10, 16, 22, 06, 08).ToShortDateString());
                secondLap.StartTime.ToShortTimeString().ShouldEqual(new DateTime(2012, 10, 16, 22, 06, 08).ToShortTimeString());
                secondLap.CadenceSpecified.ShouldBeFalse();
                secondLap.Track.First().AltitudeMetersSpecified.ShouldBeTrue();
            }
        }
    }
}
