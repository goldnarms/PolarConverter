using System;

namespace PolarConverter.BLL.Helpers
{
    public static class IntHelper
    {
        public static int HentTidsKorreksjon(double gmt)
        {
            return 0;
            var minutes = gmt*60;
            return Convert.ToInt32(minutes);
        }

        public static int HentTidsKorreksjon(string gmt)
        {
            int timer = 0, minutter = 0;
            if(gmt[8] == ':')
            {
                timer = Convert.ToInt32(gmt.Substring(6, 2));
                minutter = Convert.ToInt32(gmt.Substring(9, 2));
            }
            else if(gmt[7] == ':')
            {
                timer = Convert.ToInt32(gmt.Substring(6, 1));
                minutter = Convert.ToInt32(gmt.Substring(8, 2));
            }
            var totaleMinutter = timer * 60 + minutter;
            if (gmt[5] == '-')
                totaleMinutter = totaleMinutter * -1;
            totaleMinutter = totaleMinutter *-1;
            totaleMinutter = totaleMinutter - 60;
            return totaleMinutter;
        }
    }
}
