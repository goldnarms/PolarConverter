namespace PolarConverter.JSWeb.Models
{
    public class PolarFile: File
    {
        public FileType Type { get; set; }
        public Sport Sport { get; set; }
        public bool Checked { get; set; }
        public GpxFile GpxFile { get; set; }
    }
}