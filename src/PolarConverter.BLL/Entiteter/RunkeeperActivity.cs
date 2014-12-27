namespace PolarConverter.BLL.Entiteter
{

    public class RunkeeperActivity
    {
        public string type { get; set; }
        public string secondary_type { get; set; }
        public string equipment { get; set; }
        public string start_time { get; set; }
        public double total_distance { get; set; }
        public int average_heart_rate { get; set; }
        public HeartRate[] heart_rate { get; set; }
        public double total_calories { get; set; }
        public double duration { get; set; }
        public string notes { get; set; }
        public Path[] path { get; set; }
        public bool post_to_facebook { get; set; }
        public bool post_to_twitter { get; set; }

    }

    public class HeartRate
    {
        public double timestamp { get; set; }
        public int heart_rate { get; set; }
    }

    public class Path
    {
        public int timestamp { get; set; }
        public int altitude { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public string type { get; set; }
    }

}
