using System;
using System.Collections.Generic;
using System.Linq;
using PolarConverter.BLL.Hjelpeklasser;

namespace PolarConverter.BLL.Entiteter
{
    public class Runde
    {
        public List<HRData> HeartRateData { get; set; }
        public List<string> AltitudeData { get; set; }
        public List<string> SpeedData { get; set; }
        public List<GPSData> GpsData { get; set; }
        public string HrmData { get; set; }
        public double MaksHjertefrekvens { get; set; }
        public string Intensitet { get { return "Active"; } }
        public string TriggerMetode { get { return "Manual"; } }
        public double SnittHjerteFrekvens { get; set; }
        public DateTime StartTime { get; set; }
        public double SnittHastighet { get { return (Distanse / 1000) / (AntallSekunder / 3600); } }
        public double AntallSekunder { get; set; }
        public double Distanse { get; set; }
        public List<string> CadenseData { get; set; }
        public byte MinHjertefrekvens { get; set; }
        public List<double> AntallMeterData { get; set; }
        public double MaksHastighet { get; set; }
        public List<string> PowerData { get; set; }
        public double VO2MaxAbsolutt { get; set; }
        public double MaxHr { get; set; }
        public int Kalorier { get; set; }
        private double _vekt;

        public double Vekt
        {
            get
            {
                var vektFraFil = 0d;
                if (HrmData != null)
                {
                    if(HrmData.Contains("Weight="))
                        vektFraFil = Convert.ToDouble(StringHelper.HentVerdi("Weight=", 5, HrmData).Trim());
                }
                return vektFraFil < 1 ? _vekt : vektFraFil;
            }
            set { _vekt = value; }
        }



        public double SnittCadense
        {
            get
            {
                if (CadenseData != null && CadenseData.Count > 0)
                {
                    var doubleData = CadenseData.Select(Convert.ToDouble).ToList(); 
                    return doubleData.Average(dd => dd);
                } 
                
                return 0;
            }
        }
    }
}
