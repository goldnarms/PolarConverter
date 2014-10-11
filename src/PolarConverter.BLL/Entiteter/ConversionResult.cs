using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarConverter.BLL.Entiteter
{
    public class ConversionResult
    {
        public string FileName { get; set; }
        public string Reference { get; set; }
        public List<string> ErrorMessages { get; set; }
        public Dictionary<string, string> TcxReferences { get; set; }
    }
}
