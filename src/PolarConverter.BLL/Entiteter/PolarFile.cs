using System.Runtime;

namespace PolarConverter.BLL.Entiteter
{
    public class PolarFile
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public string FileType { get; set; }
        public string Sport { get; set; }
        public GpxFile GpxFile { get; set; }
    }

    public class GpxFile
    {
        public string Name { get; set; }
        public string Reference { get; set; }

    }
}