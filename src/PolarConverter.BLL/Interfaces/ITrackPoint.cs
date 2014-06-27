using System;

namespace PolarConverter.BLL.Interfaces
{
    internal interface ITrackPoint
    {
        decimal lat { get; set; }
        decimal lon { get; set; }
        bool eleSpecified { get; set; }
        decimal ele { get; set; }
        bool timeSpecified { get; set; }
        DateTime time { get; set; }
    }
}