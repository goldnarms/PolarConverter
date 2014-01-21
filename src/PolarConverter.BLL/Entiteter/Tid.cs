using System;

namespace PolarConverter.BLL.Entiteter
{
    public class Tid
    {

        public Tid(DateTime tidspunkt)
        {
            Tidspunkt = tidspunkt;
        }
        public DateTime Tidspunkt { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}T{3}:{4}:{5}Z", Tidspunkt.Year, Tidspunkt.Month.ToString("00"), Tidspunkt.Day.ToString("00"), Tidspunkt.Hour.ToString("00"), Tidspunkt.Minute.ToString("00"), Tidspunkt.Second.ToString(("00")));
        }
    }
}
