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
    public class DataTypeTest: BaseTest
    {
        [TestMethod]
        public void CaloriesShouldBeInt()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(FileRoot + "{0}", @"Vanlig\12081101.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
            {
                HrmData = hrmData,
                UploadViewModel = new UploadViewModel { TimeZoneOffset = 1 },
                GpxDataString = KonverteringsHelper.VaskGpxString(string.Format(FileRoot + "{0}", @"Vanlig\12081101.gpx"), IntHelper.HentTidsKorreksjon("(GMT +1:00) Europe/Berlin")),
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
            polarData.Runder[0].Kalorier.ShouldBeType(typeof(int));
            FilHandler.SkrivTilFil(polarData, string.Format(FileRoot + "{0}", "treningKunHrmSpeed.tcx")).ShouldNotBeNull();
        }
    }
}
