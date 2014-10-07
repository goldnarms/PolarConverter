namespace PolarConverter.BLL.Entiteter
{
    public class UploadViewModel
    {
        public string Uid { get; set; }
        public double Weight { get; set; }
        public string WeightMode { get; set; }
        public double TimeZoneOffset { get; set; }
        public double V02Max { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool ForceGarmin { get; set; }
        public PolarFile[] PolarFiles { get; set; }
        public string Notes { get; set; }
    }
}