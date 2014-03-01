using System;
using System.Collections.Generic;

namespace PolarConverter.BLL.Entiteter
{
    public class XmlPolarData
    {
        public UserInfo UserInfo { get; set; }
        public string Sport { get; set; }
        public double? AvgCadence { get; set; }
        public double? AvgAltitude { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Duration { get; set; }
        public int RecordingRate { get; set; }
        public double? AvgPower { get; set; }
        public double[] Cadence { get; set; }
        public double[] Power { get; set; }
        public double[] Speed { get; set; }
        public int[] HeartRate { get; set; }
        public double[] Altitude { get; set; }
        public List<GPSData> GpxDataString { get; set; }
        public List<TimeSpan> LapTimes { get; set; }
        public List<Runde> Laps { get; set; }
        public string Note { get; set; }
    }
}