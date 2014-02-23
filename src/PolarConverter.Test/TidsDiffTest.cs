using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class TidsDiffTest
    {
        private const string RotSti = @"D:\Google Drive\Prosjekt\Polar\Tidsdiff\";
        //private const string RotSti = @"C:\Users\ajohanse\Google Drive\Prosjekt\Polar\Tidsdiff\";
        //private const string RotSti = @"C:\Users\GoldnArms\Google Drive\Prosjekt\Polar\Tidsdiff\";

        [TestMethod]
        public void TidForFort()
        {
            var hrmData = FilHandler.LesFraFil(string.Format(RotSti + "{0}", @"distansetoolong.hrm"));
            var modus = hrmData.Contains("SMode") ? "SMode" : "Mode";
            var modusVerdi = StringHelper.HentVerdi("Mode=", 9, hrmData);
            var polarData = new PolarData
                                {
                                    HrmData = hrmData,
                                    UserInfo = new UserInfo() { TimeZoneOffset = 1 },
                                    Modus = modus,
                                    ModusVerdi = modusVerdi,
                                    HarCadence =
                                        modus == "SMode"
                                            ? (modusVerdi.Substring(1, 1) == "1")
                                            : modusVerdi.Substring(0, 1) == "0",
                                    HarAltitude =
                                        modus == "SMode"
                                            ? (modusVerdi.Substring(2, 1) == "1")
                                            : modusVerdi.Substring(0, 1) == "1",
                                    ImperiskeEnheter =
                                        modus == "SMode"
                                            ? (modusVerdi.Substring(7, 1) == "1")
                                            : modusVerdi.Substring(2, 1) == "1",
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
            polarData.HrData.Count.ShouldEqual(6360);
            polarData.Runder.Count.ShouldEqual(1);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(149);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(113);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2013, 3, 10, 12, 1, 29));
            polarData.Runder[0].AntallSekunder.ShouldEqual(6359.2);
            polarData.Runder[0].Distanse.ToPolarDouble().ShouldEqual("57811");
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "trening.tcx")).ShouldNotBeNull();
        }
    }
}
