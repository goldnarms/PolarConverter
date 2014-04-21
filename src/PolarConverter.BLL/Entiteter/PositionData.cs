using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarConverter.BLL.Entiteter
{
    public class PositionData
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public DateTime? Time { get; set; }
        public decimal? Altitude { get; set; }
    }
}
