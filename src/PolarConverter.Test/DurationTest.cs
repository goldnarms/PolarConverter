using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class DurationTest
    {
        private const string RotSti = @"D:\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\ajohanse\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\GoldnArms\Google Drive\Prosjekt\Polar\";

        [TestMethod]
        public void ForLangDuration()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Duration\12101601_2.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                BrukerModel = new BrukerModel { AntallDropboxItems = 1, TimeZoneCorrection = "(GMT +1:00) Europe/Berlin", Sport = "Biking" },
                Modus = modus,
                ModusVerdi = modusVerdi,
                HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                HarSpeed = modus == "SMode" && modusVerdi.Substring(0, 1) == "1",
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            polarData.VaskHrData();
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(603);
            polarData.Runder.Count.ShouldEqual(1);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(158);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(133);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 10, 16, 16, 57, 44));
            polarData.Runder[0].AntallSekunder.ShouldEqual(3014);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "trening.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ForKortDuration()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Duration\12112501.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                BrukerModel = new BrukerModel { AntallDropboxItems = 1, TimeZoneCorrection = "(GMT +1:00) Europe/Berlin", Sport = "Biking" },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"Duration\12112501.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
                Modus = modus,
                ModusVerdi = modusVerdi,
                HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                HarSpeed = modus == "SMode" && modusVerdi.Substring(0, 1) == "1",
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            polarData.VaskHrData();
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(9132);
            polarData.Runder.Count.ShouldEqual(43);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(138);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(124);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 11, 25, 13, 19, 42));
            polarData.Runder[0].AntallSekunder.ShouldEqual(159.3);
            Math.Round(polarData.Runder.Sum(runde => runde.AntallSekunder), 1).ShouldEqual(9151.3);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "trening.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ForKortDuration2()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Duration\12120801.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                BrukerModel = new BrukerModel { AntallDropboxItems = 1, TimeZoneCorrection = "(GMT +1:00) Europe/Berlin", Sport = "Biking" },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"Duration\12120801.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
                Modus = modus,
                ModusVerdi = modusVerdi,
                HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                HarSpeed = modus == "SMode" && modusVerdi.Substring(0, 1) == "1",
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            polarData.VaskHrData();
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeTrue();
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(12227);
            polarData.Runder.Count.ShouldEqual(8);
            polarData.GpxDataString.Count.ShouldEqual(12225);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(153);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(138);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 12, 8, 5, 14, 30));
            polarData.Runder[0].AntallSekunder.ShouldEqual(4129.4);
            polarData.Runder[7].MaksHjertefrekvens.ShouldEqual(154);
            polarData.Runder[7].SnittHjerteFrekvens.ShouldEqual(145);
            polarData.Runder[7].StartTime.ShouldEqual(new DateTime(2012, 12, 8, 11, 22, 20));
            polarData.Runder[7].AntallSekunder.ShouldEqual(2383.1);
            Math.Round(polarData.Runder.Sum(runde => runde.AntallSekunder), 0).ShouldEqual(24458);
            var skrevetData = FilHandler.DataSomSkalSkrives(polarData).ToString();
            //skrevetData.Substring(skrevetData.IndexOf("<Time>"), 20).ShouldContain("05:14:30");
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "trening.tcx")).ShouldNotBeNull();
        }
    }
}
