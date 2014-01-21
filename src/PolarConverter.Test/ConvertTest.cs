using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace PolarConverter.Test
{
    using BLL.Entiteter;
    using BLL.Hjelpeklasser;

    [TestClass]
    public class ConvertTest
    {
        [TestMethod]
        public void TidToString()
        {
            var tid = new Tid(new DateTime(2012, 5, 12, 12, 13, 14));
            tid.ToString().ShouldEqual("2012-05-12T12:13:14Z");
        }

        [TestMethod]
        public void DatoToPolarString()
        {
            const string dato = "20120624";
            dato.KonvertertTilDato().ShouldEqual(new DateTime(2012, 6, 24));
        }

        [TestMethod]
        public void GmtTilMinutter()
        {
            const string gmt1 = "(GMT -12:00) Eniwetok, Kwajalein";
            const string gmt2 = "(GMT) Western Europe Time, London, Lisbon, Casablanca";
            const string gmt3 = "(GMT +4:30) Kabul";
            const string gmt4 = "(GMT -5:00 America/New York";
            IntHelper.HentTidsKorreksjon(gmt1).ShouldEqual(660);
            IntHelper.HentTidsKorreksjon(gmt2).ShouldEqual(-60);
            IntHelper.HentTidsKorreksjon(gmt3).ShouldEqual(-330);
            IntHelper.HentTidsKorreksjon(gmt4).ShouldEqual(240);
        }

        [TestMethod]
        public void KonverterTilDouble()
        {
            const string testdata = "10.413293333";
            testdata.ToPolarDouble().ShouldBeType(typeof(double));
        }
    }
}
