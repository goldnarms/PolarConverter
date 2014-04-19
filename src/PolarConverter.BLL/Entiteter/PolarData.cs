using System;
using System.Collections.Generic;
using System.Linq;
using PolarConverter.BLL.Helpers;
using PolarConverter.BLL.Interfaces;

namespace PolarConverter.BLL.Entiteter
{
    public class PolarData
    {
        public string HrmData { get; set; }
        public string XmlTekst { get; set; }
        public string Modus { get; set; }
        public string ModusVerdi { get; set; }
        public bool HarAltitude { get; set; }
        public bool HarCadence { get; set; }
        public bool ImperiskeEnheter { get; set; }
        public bool HarSpeed { get; set; }
        public bool HarPower { get; set; }
        public string Versjon { get; set; }
        public int Device { get; set; }
        public UploadViewModel UploadViewModel { get; set; }
        public static Dictionary<int, string> Devices = new Dictionary<int, string>
                                                            {
                                                                { 0, "Unknown" },
                                                                { 1, "Polar Sport Tester / Vantage XL" }, 
                                                                { 2, "Polar Vantage NV (VNV)" }, 
                                                                { 3, "Polar Accurex Plus" }, 
                                                                { 4, " Polar XTrainer Plus " }, 
                                                                { 6, "Polar S520" }, 
                                                                { 7, "Polar Coach" }, 
                                                                { 8, "Polar S210" }, 
                                                                { 9, "Polar S410" }, 
                                                                { 10, "Polar S510" }, 
                                                                { 11, "Polar S610 / S610i" }, 
                                                                { 12, "Polar S710 / S710i / S720i" }, 
                                                                { 13, "Polar S810 / S810i" }, 
                                                                { 15, "Polar E600" }, 
                                                                { 20, "Polar AXN500" }, 
                                                                { 21, "Polar AXN700" }, 
                                                                { 22, "Polar S625X / S725X" }, 
                                                                { 23, "Polar S725" }, 
                                                                { 33, "Polar CS400" }, 
                                                                { 34, "Polar CS600X" }, 
                                                                { 35, "Polar CS600" }, 
                                                                { 36, "Polar RS400" }, 
                                                                { 37, "Polar RS800" }, 
                                                                { 38, "Polar RS800X" }
                                                            };
        public int Intervall { get; set; }
        public string XmlDoc { get { return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>"; } }
        public string Header { get { return "<TrainingCenterDatabase xmlns=\"http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2 http://www.garmin.com/xmlschemas/TrainingCenterDatabasev2.xsd\">"; } }
        public List<HRData> HrData { get; set; }
        public List<string> AltitudeData { get; set; }
        public List<string> SpeedData { get; set; }
        public List<string> CadenseData { get; set; }
        public List<string> PowerData { get; set; }
        public List<double> AntallMeter { get; set; }
        public List<GPSData> GpxDataString { get; set; }
        public List<Runde> Runder { get; set; }
        public List<string> RundeTider { get; set; }
        public bool ErXml { get; set; }
        public DateTime StartTime { get; set; }
        public string Sport { get; set; }
        public string Note { get; set; }
        public IGpx GpxData { get; set; }
        public double V02max { get; set; }
        public DateTime StartDate { get; set; }
        public double Weight { get; set; }


        public void VaskXmlHrData(string innlestData)
        {
            HrData = innlestData.Contains("<type>HEARTRATE</type>") ? StringHelper.HentValues(innlestData, "<type>HEARTRATE</type>").Select(verdi => new HRData { HjerteFrekvens = Convert.ToByte(verdi) }).ToList() : null;
            AltitudeData = innlestData.Contains("<type>ALTITUDE</type>") ? StringHelper.HentValues(innlestData, "<type>ALTITUDE</type>") : null;
            SpeedData = innlestData.Contains("<type>SPEED</type>") ? StringHelper.HentValues(innlestData, "<type>SPEED</type>") : null;
            PowerData = innlestData.Contains("<type>POWER</type>") ? StringHelper.HentValues(innlestData, "<type>POWER</type>") : null;
            CadenseData = innlestData.Contains("<type>CADENCE</type>") ? StringHelper.HentValues(innlestData, "<type>CADENCE</type>") : null;
            if (SpeedData != null)
            {
                AntallMeter = new List<double>();
                foreach (var speed in SpeedData)
                {
                    double fart;
                    if(!double.TryParse(speed, out fart))
                    {
                        double.TryParse(speed.Replace('.', ','), out fart);
                    }

                    AntallMeter.Add(AntallMeter.Count > 0 ? AntallMeter.Last() + (fart / 0.06 / 60 * Intervall) : (fart / 0.06 / 60 * Intervall));
                }
            }
        }
    }
}
