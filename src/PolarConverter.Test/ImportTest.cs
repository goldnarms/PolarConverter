using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace PolarConverter.Test
{
    using BLL;
    using BLL.Entiteter;
    using BLL.Hjelpeklasser;

    [TestClass]
    public class ImportTest
    {

        private const string RotSti = @"D:\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\ajohanse\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\GoldnArms\Google Drive\Prosjekt\Polar\";

        [TestMethod]
        public void ImportFromFilMedFlereRunder()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"FlereRunder\12060301.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"FlereRunder\12060301.gpx"), 120),
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
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(600);
            polarData.GpxDataString.Count.ShouldEqual(598);
            polarData.Runder.Count.ShouldEqual(5);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(159);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(144);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 6, 3, 14, 50, 33));
            polarData.Runder[0].AntallSekunder.ShouldEqual(661.4);
            polarData.Runder[1].MaksHjertefrekvens.ShouldEqual(180);
            polarData.Runder[1].SnittHjerteFrekvens.ShouldEqual(166);
            polarData.Runder[1].StartTime.ShouldEqual(new DateTime(2012, 6, 3, 15, 1, 34));
            polarData.Runder[1].AntallSekunder.ShouldEqual(529.8);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "trening.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilGmtAmerika()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Vanlig\12072201.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"Vanlig\12072201.gpx"), 120),
                BrukerModel = new BrukerModel { AntallDropboxItems = 1, TimeZoneCorrection = "(GMT -5:00) America/New York", Sport = "Biking" },
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
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(1602);
            polarData.GpxDataString.Count.ShouldEqual(1600);
            polarData.Runder[0].GpsData[0].Tid.Tidspunkt.ShouldEqual(new DateTime(2012, 7, 22, 17, 55, 17));
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "trening.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilMedGpsUtenDatoINavn()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"GpsNavnUtenDato\rondjeRotte.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"GpsNavnUtenDato\rondjeRotte.gpx"), 120),
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
            polarData.HrData.Count.ShouldEqual(658);
            polarData.GpxDataString.Count.ShouldEqual(932);
            polarData.Runder.Count.ShouldEqual(1);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(167);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(133);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 7, 20, 12, 46, 45));
            polarData.Runder[0].AntallSekunder.ShouldEqual(3287.9);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "trening.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilUtenGpx()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"KunHrm\12070601.hrm"));
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
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(129);
            polarData.Runder[1].MaksHjertefrekvens.ShouldEqual(127);
            polarData.Runder[2].MaksHjertefrekvens.ShouldEqual(115);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(119);
            polarData.Runder[1].SnittHjerteFrekvens.ShouldEqual(119);
            polarData.Runder[2].SnittHjerteFrekvens.ShouldEqual(114);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 7, 6, 17, 38, 27));
            polarData.Runder[1].StartTime.ShouldEqual(new DateTime(2012, 7, 6, 17, 46, 30));
            polarData.Runder[0].AntallSekunder.ShouldEqual(483.8);
            polarData.Runder[1].AntallSekunder.ShouldEqual(89.3);
            polarData.Runder[2].AntallSekunder.ShouldEqual(6.5);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(116);
            polarData.Runder.Count.ShouldEqual(3);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrm.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilUtenGpx2()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"KunHrm\12081502.hrm"));
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
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeFalse();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(127);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(112);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 8, 15, 19, 7, 18));
            polarData.Runder[0].AntallSekunder.ShouldEqual(1410.7);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(282);
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrm.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilUtenGpx3()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"KunHrm\12081501.hrm"));
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
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeFalse();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(127);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(108);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 8, 15, 18, 14, 35));
            polarData.Runder[0].AntallSekunder.ShouldEqual(1617.4);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(324);
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrm.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilUtenGpxMedSpeed()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"KunHrm\12070602.hrm"));
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
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(143);
            polarData.Runder[1].MaksHjertefrekvens.ShouldEqual(130);
            polarData.Runder[2].MaksHjertefrekvens.ShouldEqual(130);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(128);
            polarData.Runder[1].SnittHjerteFrekvens.ShouldEqual(130);
            polarData.Runder[2].SnittHjerteFrekvens.ShouldEqual(130);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 7, 6, 17, 48, 26));
            polarData.Runder[1].StartTime.ShouldEqual(new DateTime(2012, 7, 6, 17, 56, 30));
            polarData.Runder[2].StartTime.ShouldEqual(new DateTime(2012, 7, 6, 17, 56, 32));
            polarData.Runder[0].AntallSekunder.ShouldEqual(484.6);
            polarData.Runder[1].AntallSekunder.ShouldEqual(2.4);
            polarData.Runder[2].AntallSekunder.ShouldEqual(2.1);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(99);
            polarData.Runder.Count.ShouldEqual(4);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportSomFeiler()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"stiilnomapinstrava\12073001.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                BrukerModel = new BrukerModel { AntallDropboxItems = 1, TimeZoneCorrection = "(GMT +1:00) Europe/Berlin", Sport = "Biking" },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"stiilnomapinstrava\12073001.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
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
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(169);
            polarData.Runder[1].MaksHjertefrekvens.ShouldEqual(115);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(138);
            polarData.Runder[1].SnittHjerteFrekvens.ShouldEqual(115);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 7, 30, 17, 36, 25));
            polarData.Runder[1].StartTime.ShouldEqual(new DateTime(2012, 7, 30, 18, 44, 22));
            polarData.Runder[0].AntallSekunder.ShouldEqual(4077.5);
            polarData.Runder[1].AntallSekunder.ShouldEqual(1);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(816);
            polarData.Runder[0].Kalorier.ShouldNotEqual(0);
            polarData.Runder.Count.ShouldEqual(2);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportSomManglerGPSData()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Vanlig\12081101.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                BrukerModel = new BrukerModel { AntallDropboxItems = 1, TimeZoneCorrection = "(GMT +1:00) Europe/Berlin", Sport = "Biking" },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"Vanlig\12081101.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
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
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(165);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(139);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 8, 11, 5, 45, 14));
            polarData.Runder[0].AntallSekunder.ShouldEqual(11666);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(2334);
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ForkortetFil()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Filer\12082401.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                BrukerModel = new BrukerModel { AntallDropboxItems = 1, TimeZoneCorrection = "(GMT +1:00) Europe/Berlin", Sport = "Biking" },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"Filer\12082401.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
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
            polarData.HrData.Count.ShouldEqual(541);
            polarData.Runder.Count.ShouldEqual(7);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void OldieFil()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Oldies\1998\98011201.hrm"));
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
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeFalse();
            polarData.HrData.Count.ShouldEqual(377);
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void OldieFil2()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Oldies\1998\98011801.hrm"));
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
                HarSpeed = (modus == "SMode" && modusVerdi.Substring(0, 1) == "1") || (modus == "Mode" && modusVerdi.Substring(0, 1) == "3"),
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            polarData.VaskHrData();
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.HrData.Count.ShouldEqual(1870);
            polarData.Runder.Count.ShouldEqual(4);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void OldieFil3()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Oldies\1998\98011802.hrm"));
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
                HarSpeed = (modus == "SMode" && modusVerdi.Substring(0, 1) == "1") || (modus == "Mode" && modusVerdi.Substring(1, 1) == "1"),
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            polarData.VaskHrData();
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeFalse();
            polarData.HrData.Count.ShouldEqual(1617);
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void OldieFil4()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Oldies\1998\98012101.hrm"));
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
                HarSpeed = (modus == "SMode" && modusVerdi.Substring(0, 1) == "1") || (modus == "Mode" && modusVerdi.Substring(1, 1) == "1"),
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            polarData.VaskHrData();
            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeFalse();
            polarData.HrData.Count.ShouldEqual(139);
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilFraXml()
        {
            var brukerModel = new BrukerModel
            {
                AntallDropboxItems = 1,
                BrukerGuid = "fek",
                DropboxItems = new List<DropboxItem>
                {
                    new DropboxItem
                        {
                            Filnavn =
                                string.Format(RotSti + "{0}",
                                            @"XmlFil\Goldnarms_21.07.2012_export.xml"),
                            Notat = "Xml",
                            Sport = "Biking",
                            Valgt = true
                        }
                },
                TimeZoneCorrection = "(GMT +1:00) Europe/Berlin"
            };

            var xmlTekst = FilHandler.LesFraFil(brukerModel.DropboxItems[0].Filnavn);
            var polarData = new PolarData
            {
                BrukerModel = brukerModel,
                HarCadence = xmlTekst.Contains("<type>CADENCE</type>"),
                HarAltitude = xmlTekst.Contains("<type>ALTITUDE</type>"),
                HarSpeed = xmlTekst.Contains("<type>SPEED</type>"),
                HarPower = xmlTekst.Contains("<type>POWER</type>"),
                XmlTekst = xmlTekst,
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("<recording-rate>", 3, xmlTekst).Replace('<', ' ').Replace('/', ' ').Trim()),
                RundeTider = KonverteringsHelper.VaskXmlTider(xmlTekst)
            };

            polarData.VaskXmlHrData(xmlTekst);
            polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);

            polarData.HarAltitude.ShouldBeTrue();
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.XmlTekst.Length.ShouldNotEqual(0);
            polarData.HrData.Count.ShouldEqual(343);
            polarData.Runder.Count.ShouldEqual(1);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(167);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldBeInRange(126, 127);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 7, 14, 17, 7, 32));
            polarData.Runder[0].AntallSekunder.ShouldEqual(1712.7);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void FeiVedImportFromFilFraXml()
        {
            var brukerModel = new BrukerModel
            {
                AntallDropboxItems = 1,
                BrukerGuid = "fek",
                DropboxItems = new List<DropboxItem>
                {
                    new DropboxItem
                        {
                            Filnavn =
                                string.Format(RotSti + "{0}",
                                            @"XmlFil\Mattias242_2012-07-30_export.xml"),
                            Notat = "Xml",
                            Sport = "Biking",
                            Valgt = true
                        }
                },
                TimeZoneCorrection = "(GMT +1:00) Europe/Berlin"
            };

            var xmlTekst = FilHandler.LesFraFil(brukerModel.DropboxItems[0].Filnavn);
            var polarData = new PolarData
            {
                BrukerModel = brukerModel,
                HarCadence = xmlTekst.Contains("<cadence>"),
                HarAltitude = xmlTekst.Contains("<altitude>"),
                HarSpeed = xmlTekst.Contains("<speed>"),
                HarPower = xmlTekst.Contains("<power>"),
                XmlTekst = xmlTekst,
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("<recording-rate>", 3, xmlTekst).Replace('<', ' ').Replace('/', ' ').Trim()),
                RundeTider = KonverteringsHelper.VaskXmlTider(xmlTekst)
            };

            polarData.VaskXmlHrData(xmlTekst);
            polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.HarPower.ShouldBeFalse();
            polarData.XmlTekst.Length.ShouldNotEqual(0);
            polarData.HrData.ShouldBeNull();
            polarData.Runder.Count.ShouldEqual(2);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(163);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 6, 26, 16, 0, 0));
            polarData.Runder[0].AntallSekunder.ShouldEqual(3026.7);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void FeiVedImportFromFilFraXml2()
        {
            var brukerModel = new BrukerModel
            {
                AntallDropboxItems = 1,
                BrukerGuid = "fek",
                DropboxItems = new List<DropboxItem>
                {
                    new DropboxItem
                        {
                            Filnavn =
                                string.Format(RotSti + "{0}",
                                            @"XmlFil\Mattias242_2012-07-31_export.xml"),
                            Notat = "Xml",
                            Sport = "Biking",
                            Valgt = true
                        }
                },
                TimeZoneCorrection = "(GMT +1:00) Europe/Berlin"
            };

            var xmlTekst = FilHandler.LesFraFil(brukerModel.DropboxItems[0].Filnavn);
            var polarData = new PolarData
            {
                BrukerModel = brukerModel,
                HarCadence = xmlTekst.Contains("<cadence>"),
                HarAltitude = xmlTekst.Contains("<altitude>"),
                HarSpeed = xmlTekst.Contains("<speed>"),
                HarPower = xmlTekst.Contains("<power>"),
                XmlTekst = xmlTekst,
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("<recording-rate>", 3, xmlTekst).Replace('<', ' ').Replace('/', ' ').Trim()),
                RundeTider = KonverteringsHelper.VaskXmlTider(xmlTekst)
            };

            polarData.VaskXmlHrData(xmlTekst);
            polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.HarPower.ShouldBeFalse();
            polarData.XmlTekst.Length.ShouldNotEqual(0);
            polarData.HrData.ShouldBeNull();
            polarData.Runder.Count.ShouldEqual(24);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(156);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 7, 25, 5, 15, 15));
            polarData.Runder[0].AntallSekunder.ShouldEqual(394.1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void FeiVedImportFromFilFraXml3()
        {
            var brukerModel = new BrukerModel
            {
                AntallDropboxItems = 1,
                BrukerGuid = "fek",
                DropboxItems = new List<DropboxItem>
                {
                    new DropboxItem
                        {
                            Filnavn =
                                string.Format(RotSti + "{0}",
                                            @"XmlFil\ttfje_14.08.2012_export.xml"),
                            Notat = "Xml",
                            Sport = "Biking",
                            Valgt = true
                        }
                },
                TimeZoneCorrection = "(GMT +1:00) Europe/Berlin"
            };

            var xmlTekst = FilHandler.LesFraFil(brukerModel.DropboxItems[0].Filnavn);
            var polarData = new PolarData
            {
                BrukerModel = brukerModel,
                HarCadence = xmlTekst.Contains("<cadence>"),
                HarAltitude = xmlTekst.Contains("<altitude>"),
                HarSpeed = xmlTekst.Contains("<speed>"),
                HarPower = xmlTekst.Contains("<power>"),
                XmlTekst = xmlTekst,
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("<recording-rate>", 3, xmlTekst).Replace('<', ' ').Replace('/', ' ').Trim()),
                RundeTider = KonverteringsHelper.VaskXmlTider(xmlTekst)
            };

            polarData.VaskXmlHrData(xmlTekst);
            polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);

            polarData.HarAltitude.ShouldBeTrue();
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.HarPower.ShouldBeFalse();
            polarData.XmlTekst.Length.ShouldNotEqual(0);
            polarData.HrData.ShouldNotBeNull();
            polarData.Runder.Count.ShouldEqual(3);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(164);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 8, 13, 17, 23, 7));
            polarData.Runder[0].AntallSekunder.ShouldEqual(374);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereExercises()
        {
            var brukerModel = new BrukerModel
            {
                AntallDropboxItems = 1,
                BrukerGuid = "fek",
                DropboxItems = new List<DropboxItem>
                {
                    new DropboxItem
                        {
                            Filnavn =
                                string.Format(RotSti + "{0}",
                                            @"XmlFil\inspiring_21.07.2012_export.xml"),
                            Notat = "Xml",
                            Sport = "Biking",
                            Valgt = true
                        }
                },
                TimeZoneCorrection = "(GMT +1:00) Europe/Berlin"
            };

            var xmlTekst = FilHandler.LesFraFil(brukerModel.DropboxItems[0].Filnavn);
            var polarData = new PolarData
            {
                BrukerModel = brukerModel,
                HarCadence = xmlTekst.Contains("<cadence>"),
                HarAltitude = xmlTekst.Contains("<altitude>"),
                HarSpeed = xmlTekst.Contains("<speed>"),
                HarPower = xmlTekst.Contains("<power>"),
                XmlTekst = xmlTekst,
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("<recording-rate>", 3, xmlTekst).Replace('<', ' ').Replace('/', ' ').Trim()),
                RundeTider = KonverteringsHelper.VaskXmlTider(xmlTekst)
            };

            polarData.VaskXmlHrData(xmlTekst);
            polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.HarPower.ShouldBeFalse();
            polarData.XmlTekst.Length.ShouldNotEqual(0);
            polarData.HrData.ShouldBeNull();
            polarData.Runder.Count.ShouldEqual(3);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(128);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 6, 25, 17, 17, 40));
            polarData.Runder[0].AntallSekunder.ShouldEqual(706.6);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereExercises2()
        {
            var brukerModel = new BrukerModel
            {
                AntallDropboxItems = 1,
                BrukerGuid = "fek",
                DropboxItems = new List<DropboxItem>
                {
                    new DropboxItem
                        {
                            Filnavn =
                                string.Format(RotSti + "{0}",
                                            @"XmlFil\120820.xml"),
                            Notat = "Xml",
                            Sport = "Biking",
                            Valgt = true
                        }
                },
                TimeZoneCorrection = "(GMT +1:00) Europe/Berlin"
            };

            var xmlTekst = FilHandler.LesFraFil(brukerModel.DropboxItems[0].Filnavn);
            var exercises = xmlTekst.Split(new[] { "</exercise>" }, StringSplitOptions.RemoveEmptyEntries).Where(ex => ex.Contains("<exercise>"));
            var i = 1;
            foreach (var exercise in exercises.Where(ex => ex.Contains("<result>")))
            {
                var polarData = new PolarData
                                    {
                                        BrukerModel = brukerModel,
                                        HarCadence = exercise.Contains("<cadence>"),
                                        HarAltitude = exercise.Contains("<altitude>"),
                                        HarSpeed = exercise.Contains("<speed>"),
                                        HarPower = exercise.Contains("<power>"),
                                        XmlTekst = exercise,
                                        Intervall =
                                            Convert.ToInt32(
                                                StringHelper.HentVerdi("<recording-rate>", 3, exercise).
                                                    Replace('<', ' ').Replace('/', ' ').Trim()),
                                        RundeTider = KonverteringsHelper.VaskXmlTider(exercise)
                                    };

                polarData.VaskXmlHrData(exercise);
                polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);
                FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).
                    ShouldNotBeNull();
            }
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereExercises3()
        {
            var brukerModel = new BrukerModel
            {
                AntallDropboxItems = 1,
                BrukerGuid = "fek",
                DropboxItems = new List<DropboxItem>
                {
                    new DropboxItem
                        {
                            Filnavn =
                                string.Format(RotSti + "{0}",
                                            @"XmlFil\Joerund_01.09.2012_export.xml"),
                            Notat = "Xml",
                            Sport = "Biking",
                            Valgt = true
                        }
                },
                TimeZoneCorrection = "(GMT +1:00) Europe/Berlin"
            };

            var xmlTekst = FilHandler.LesFraFil(brukerModel.DropboxItems[0].Filnavn);
            var exercises = xmlTekst.Split(new[] { "</exercise>" }, StringSplitOptions.RemoveEmptyEntries).Where(ex => ex.Contains("<exercise>"));
            var i = 1;
            foreach (var exercise in exercises.Where(ex => ex.Contains("<result>")))
            {
                var polarData = new PolarData
                {
                    BrukerModel = brukerModel,
                    HarCadence = exercise.Contains("<cadence>"),
                    HarAltitude = exercise.Contains("<altitude>"),
                    HarSpeed = exercise.Contains("<speed>"),
                    HarPower = exercise.Contains("<power>"),
                    XmlTekst = exercise,
                    Intervall =
                        Convert.ToInt32(
                            StringHelper.HentVerdi("<recording-rate>", 3, exercise).
                                Replace('<', ' ').Replace('/', ' ').Trim()),
                    RundeTider = KonverteringsHelper.VaskXmlTider(exercise)
                };

                polarData.VaskXmlHrData(exercise);
                polarData.Runder = KonverteringsHelper.GenererXmlRunder(polarData);
                FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).
                    ShouldNotBeNull();
            }
        }
    }
}
