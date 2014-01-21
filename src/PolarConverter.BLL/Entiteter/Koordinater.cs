namespace PolarConverter.BLL.Entiteter
{
    public class Koordinater
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public Koordinater(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
