using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class DataTypeTest
    {
        private const string RotSti = @"D:\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\ajohanse\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\GoldnArms\Google Drive\Prosjekt\Polar\";

        [TestMethod]
        public void CaloriesShouldBeInt()
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
            polarData.Runder[0].Kalorier.ShouldBeType(typeof(int));
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }
    }
}
