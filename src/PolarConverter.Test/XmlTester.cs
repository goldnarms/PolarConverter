using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Hjelpeklasser;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class XmlTester
    {
        //private const string RotSti = @"D:\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\ajohanse\Google Drive\Prosjekt\Polar\";
        //private const string RotSti = @"C:\Users\GoldnArms\Google Drive\Prosjekt\Polar\";
        private const string RotSti = @"C:\Users\Arnstein\Google Drive\PolarFiler\";

        [TestMethod]
        public void ReadTypeFromXml()
        {
            var sport = "";
            var settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            using (var xmlReader = XmlReader.Create(string.Format(RotSti + "{0}",
                                            @"Done\Goldnarms_09.07.2012_export(1).xml"), settings))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "type")
                    {
                        sport = xmlReader.ReadInnerXml();
                        break;
                    }
                }
            }
            sport.ShouldEqual("CYCLING");
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
                                            @"XmlFil\børge_18.10.2012_export.xml"),
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
                UserInfo = new UserInfo() { TimeZoneOffset = 1 },
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

            polarData.HarAltitude.ShouldBeFalse();
            polarData.HarCadence.ShouldBeFalse();
            polarData.HarSpeed.ShouldBeFalse();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.XmlTekst.Length.ShouldNotEqual(0);
            polarData.Runder.Count.ShouldEqual(9);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(177);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(162);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 10, 1, 17, 58, 22));
            polarData.Runder[0].AntallSekunder.ShouldEqual(281.5);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void ImportFromFilFraXmlFlereRunderMedAutolaps()
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
                                            @"XmlFil\escalade_29.11.2012_export.xml"),
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
                UserInfo = new UserInfo() { TimeZoneOffset = 1 },
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
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.XmlTekst.Length.ShouldNotEqual(0);
            polarData.Runder.Count.ShouldEqual(2);
            polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(179);
            polarData.Runder[0].MaksHastighet.ShouldEqual(52.25);
            polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(154.60207100591717);
            polarData.Runder[0].Distanse.ShouldEqual(26740);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 11, 29, 3, 36, 52));
            polarData.Runder[0].AntallSekunder.ShouldEqual(3380.0);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).ShouldNotBeNull();
        }

        [TestMethod]
        public void FeilerVedImport()
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
                                            @"XmlFil\escalade_12.12.2012_export.xml"),
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
                UserInfo = new UserInfo() { TimeZoneOffset = 1 },
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
            polarData.HarCadence.ShouldBeTrue();
            polarData.HarSpeed.ShouldBeTrue();
            polarData.ImperiskeEnheter.ShouldBeFalse();
            polarData.XmlTekst.Length.ShouldNotEqual(0);
            polarData.Runder.Count.ShouldEqual(5);
            //polarData.Runder[0].MaksHjertefrekvens.ShouldEqual(178);
            //polarData.Runder[0].MaksHastighet.ShouldEqual(52.25);
            //polarData.Runder[0].SnittHjerteFrekvens.ShouldEqual(162);
            polarData.Runder[0].Distanse.ShouldEqual(22124);
            polarData.Runder[0].StartTime.ShouldEqual(new DateTime(2012, 12, 8, 15, 02, 04));
            polarData.Runder[0].AntallSekunder.ShouldEqual(42);
            FilHandler.SkrivTilFil(polarData, string.Format(RotSti + "{0}", "treningXml.tcx")).ShouldNotBeNull();
        }
    }
}
