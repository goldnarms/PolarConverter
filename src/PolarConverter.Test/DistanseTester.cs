﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class DistanseTester
    {
        private const string RotSti = @"D:\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\ajohanse\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\GoldnArms\Google Drive\Prosjekt\Polar\";

        [TestMethod]
        public void DistanseForLang()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"Distanse\12093001.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                UserInfo = new UserInfo() { TimeZoneOffset = 1 },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"Distanse\12093001.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
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
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(149);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(105);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 9, 30, 14, 32, 27));
            polarData.Runder[0].AntallSekunder.ShouldEqual(4502);
            Math.Round(polarData.Runder[0].Distanse, 1).ShouldEqual(6850.6);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(4502);
            polarData.Runder[0].Kalorier.ShouldNotEqual(0);
            polarData.Runder.Count.ShouldEqual(1);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }
    }
}
