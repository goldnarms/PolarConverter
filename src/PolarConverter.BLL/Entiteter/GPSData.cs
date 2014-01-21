namespace PolarConverter.BLL.Entiteter
{
    public class GPSData
    {
        public Tid Tid { get; set; }

        public Koordinater Koordinater { get; set; }

        public GPSData() {
            
        }
        public GPSData(Tid tid, Koordinater koordinater)
        {
            Tid = tid;
            Koordinater = koordinater;
        }
    }
}
