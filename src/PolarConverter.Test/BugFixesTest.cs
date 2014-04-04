using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Services;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class BugFixesTest : BaseTest
    {
        [TestMethod]
        public void EmptyFolder()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(FileRoot + "{0}", @"EmptyFiles\11101501.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                UploadViewModel = new UploadViewModel { TimeZoneOffset = 1 },
                Modus = modus,
                ModusVerdi = modusVerdi,
                HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                HarSpeed = modus == "SMode" && modusVerdi.Substring(0, 1) == "1",
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };
            DataMapper.VaskHrData(ref polarData);
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeTrue();
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(202);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(123);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2011, 10, 15, 03, 48, 37));
            polarData.Runder[0].AntallSekunder.ShouldEqual(8133.2);
            Math.Round(polarData.Runder[0].Distanse, 1).ShouldEqual(73285.1);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(1627);
            polarData.Runder[0].Kalorier.ShouldNotEqual(0);
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(FileRoot + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void Bugs01()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(FileRoot + "{0}", @"EmptyFiles\13021901.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                UploadViewModel = new UploadViewModel { TimeZoneOffset = 1 },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(FileRoot + "{0}", @"EmptyFiles\13021901.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
                Modus = modus,
                ModusVerdi = modusVerdi,
                HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                HarSpeed = modus == "SMode" && modusVerdi.Substring(0, 1) == "1",
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            DataMapper.VaskHrData(ref polarData);

            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeTrue();
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(159);
            polarData.Runder[1].MaksHjertefrekvens.ShouldEqual(160);
            polarData.Runder[2].MaksHjertefrekvens.ShouldEqual(160);
            polarData.Runder[3].MaksHjertefrekvens.ShouldEqual(164);
            polarData.Runder[4].MaksHjertefrekvens.ShouldEqual(167);
            polarData.Runder[5].MaksHjertefrekvens.ShouldEqual(167);
            polarData.Runder[6].MaksHjertefrekvens.ShouldEqual(157);
            polarData.Runder[7].MaksHjertefrekvens.ShouldEqual(170);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(147);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2013, 2, 19, 5, 19, 48));
            polarData.Runder[0].AntallSekunder.ShouldEqual(581.1);
            Math.Round(polarData.Runder[0].Distanse, 1).ShouldEqual(5018.3);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(337);
            polarData.Runder[0].Kalorier.ShouldNotEqual(0);
            polarData.Runder.Count.ShouldEqual(15);
            FilHandler.SkrivTilFil(polarData, string.Format(FileRoot + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }
    }
}
