using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;
using PolarConverter.BLL.Services;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class KalorierTester
    {
        private const string RotSti = @"D:\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\ajohanse\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\GoldnArms\Google Drive\Prosjekt\Polar\";
        [TestMethod]
        public void TommeKalorier()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"TommeKalorier\12101601.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                UserInfo = new UserInfo() { TimeZoneOffset = 1 },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(RotSti + "{0}", @"TommeKalorier\12101601.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
                Modus = modus,
                ModusVerdi = modusVerdi,
                HarCadence = modus == "SMode" ? (modusVerdi.Substring(1, 1) == "1") : modusVerdi.Substring(0, 1) == "0",
                HarAltitude = modus == "SMode" ? (modusVerdi.Substring(2, 1) == "1") : modusVerdi.Substring(0, 1) == "1",
                ImperiskeEnheter = modus == "SMode" ? (modusVerdi.Substring(7, 1) == "1") : modusVerdi.Substring(2, 1) == "1",
                HarSpeed = modus == "SMode" && modusVerdi.Substring(0, 1) == "1",
                HarPower = modus == "SMode" && modusVerdi.Substring(3, 1) == "1",
                Intervall = Convert.ToInt32(StringHelper.HentVerdi("Interval=", 3, hrmData).Trim())
            };

            var conversionService = new ConversionService();
            conversionService.VaskHrData(ref polarData);

            polarData.RundeTider = KonverteringsHelper.VaskIntTimes(polarData.HrmData);
            polarData.Runder = KonverteringsHelper.GenererRunder(polarData);

            polarData.HarAltitude.ShouldBeTrue();
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.HrmData.Length.ShouldNotEqual(0);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(0);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(0);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 10, 16, 18, 06, 08));
            polarData.Runder[0].AntallSekunder.ShouldEqual(0);
            polarData.Runder[1].MaksHjertefrekvens.ShouldEqual(164);
            polarData.Runder[1].SnittHjerteFrekvens.ShouldEqual(148);
            polarData.Runder[1].StartTime.ShouldEqual(new DateTime(2012, 10, 16, 18, 06, 08));
            polarData.Runder[1].AntallSekunder.ShouldEqual(423.5);
            polarData.Runder[1].Kalorier.ShouldEqual(89);
            Math.Round(polarData.Runder[1].Distanse, 1).ShouldEqual(996.9);
            polarData.Versjon.ShouldEqual("106");
            polarData.Modus.ShouldEqual("SMode");
            polarData.HrData.Count.ShouldEqual(583);
            polarData.Runder[2].Kalorier.ShouldNotEqual(0);
            polarData.Runder.Count.ShouldEqual(9);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }
    }
}
