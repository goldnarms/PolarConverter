namespace PolarConverter.BLL.Entiteter
{
    public class UploadViewModel
    {
        public double Weight { get; set; }
        public string WeightMode { get; set; }
        public double TimeZoneOffset { get; set; }
        public bool ForceGarmin { get; set; }
        public PolarFile[] PolarFiles { get; set; }
    }
}