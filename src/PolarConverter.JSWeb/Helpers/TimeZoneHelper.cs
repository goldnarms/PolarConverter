using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolarConverter.JSWeb.Helpers
{
    public static class TimeZoneHelper
    {
        public static IEnumerable<TimeZone> GetTimeZones()
        {
            return new List<TimeZone>() {
                new TimeZone { Offset = -12, Text = "(GMT -12:00) Etc/GMT" },
                new TimeZone { Offset = -11, Text = "(GMT -11:00) Pacific/Pago_Pago" },
                new TimeZone { Offset = -10, Text = "(GMT -10:00) America/Adak" },
                new TimeZone { Offset = -10, Text = "(GMT -10:00) Pacific/Honolulu" },
                new TimeZone { Offset = -9.5, Text = "(GMT -9:30) Pacific/Marquesas" },
                new TimeZone { Offset = -9, Text = "(GMT -9:00) Pacific/Gambier" },
                new TimeZone { Offset = -9, Text = "(GMT -9:00) America/Anchorage" },
                new TimeZone { Offset = -8, Text = "(GMT -8:00) America/Los_Angeles" },
                new TimeZone { Offset = -8, Text = "(GMT -8:00) Pacific/Pitcairn" },
                new TimeZone { Offset = -7, Text = "(GMT -7:00) America/Phoenix" },
                new TimeZone { Offset = -7, Text = "(GMT -7:00) America/Denver" },
                new TimeZone { Offset = -6, Text = "(GMT -6:00) America/Guatemala" },
                new TimeZone { Offset = -6, Text = "(GMT -6:00) America/Chicago" },
                new TimeZone { Offset = -6, Text = "(GMT -6:00) Pacific/Easter" },
                new TimeZone { Offset = -5, Text = "(GMT -5:00) America/Bogota" },
                new TimeZone { Offset = -5, Text = "(GMT -5:00) America/New_York" },
                new TimeZone { Offset = -4.5, Text = "(GMT -4:30) America/Caracas" },
                new TimeZone { Offset = -4, Text = "(GMT -4:00) America/Halifax" },
                new TimeZone { Offset = -4, Text = "(GMT -4:00) America/Santo_Domingo" },
                new TimeZone { Offset = -4, Text = "(GMT -4:00) America/Asuncion" },
                new TimeZone { Offset = -3.5, Text = "(GMT -3:30) America/St_Johns" },
                new TimeZone { Offset = -3, Text = "(GMT -3:00) America/Godthab" },
                new TimeZone { Offset = -3, Text = "(GMT -3:00) America/Argentina/Buenos_Aires" },
                new TimeZone { Offset = -3, Text = "(GMT -3:00) America/Montevideo" },
                new TimeZone { Offset = -2, Text = "(GMT -2:00) America/Noronha" },
                new TimeZone { Offset = -2, Text = "(GMT -2:00) Etc/GMT+2" },
                new TimeZone { Offset = -1, Text = "(GMT -1:00) Atlantic/Azores" },
                new TimeZone { Offset = -1, Text = "(GMT -1:00) Atlantic/Cape_Verde" },
                new TimeZone { Offset = 0, Text = "(GMT 0:00) Etc/UTC" },
                new TimeZone { Offset = 0, Text = "(GMT 0:00) Europe/London" },
                new TimeZone { Offset = 1, Text = "(GMT +1:00) Europe/Berlin" },
                new TimeZone { Offset = 1, Text = "(GMT +1:00) Africa/Lagos" },
                new TimeZone { Offset = 1, Text = "(GMT +1:00) Africa/Windhoek" },
                new TimeZone { Offset = 2, Text = "(GMT +2:00) Asia/Beirut" },
                new TimeZone { Offset = 2, Text = "(GMT +2:00) Africa/Johannesburg" },
                new TimeZone { Offset = 3, Text = "(GMT +3:00) Europe/Moscow" },
                new TimeZone { Offset = 3, Text = "(GMT +3:00) Asia/Baghdad" },
                new TimeZone { Offset = 3.5, Text = "(GMT +3:30) Asia/Tehran" },
                new TimeZone { Offset = 4, Text = "(GMT +4:00) Asia/Dubai" },
                new TimeZone { Offset = 4, Text = "(GMT +4:00) Asia/Yerevan" },
                new TimeZone { Offset = 4.5, Text = "(GMT +4:30) Asia/Kabul" },
                new TimeZone { Offset = 5, Text = "(GMT +5:00) Asia/Yekaterinburg" },
                new TimeZone { Offset = 5, Text = "(GMT +5:00) Asia/Karachi" },
                new TimeZone { Offset = 5.5, Text = "(GMT +5:30) Asia/Kolkata" },
                new TimeZone { Offset = 5.75, Text = "(GMT +5:45) Asia/Kathmandu" },
                new TimeZone { Offset = 6, Text = "(GMT +6:00) Asia/Dhaka" },
                new TimeZone { Offset = 6, Text = "(GMT +6:00) Asia/Omsk" },
                new TimeZone { Offset = 6.5, Text = "(GMT +6:30) Asia/Rangoon" },
                new TimeZone { Offset = 7, Text = "(GMT +7:00) Asia/Krasnoyarsk" },
                new TimeZone { Offset = 7, Text = "(GMT +7:00) Asia/Jakarta" },
                new TimeZone { Offset = 8, Text = "(GMT +8:00) Asia/Shanghai" },
                new TimeZone { Offset = 8, Text = "(GMT +8:00) Asia/Irkutsk" },
                new TimeZone { Offset = 8.75, Text = "(GMT +8:45) Australia/Eucla" },
                new TimeZone { Offset = 8.75, Text = "(GMT +8:45) 'Australia/Eucla" },
                new TimeZone { Offset = 9, Text = "(GMT +9:00) Asia/Yakutsk" },
                new TimeZone { Offset = 9, Text = "(GMT +9:00) Asia/Tokyo" },
                new TimeZone { Offset = 9.5, Text = "(GMT +9:30) Australia/Darwin" },
                new TimeZone { Offset = 9.5, Text = "(GMT +9:30) Australia/Adelaide" },
                new TimeZone { Offset = 10, Text = "(GMT +10:00) Australia/Brisbane" },
                new TimeZone { Offset = 10, Text = "(GMT +10:00) Asia/Vladivostok" },
                new TimeZone { Offset = 10, Text = "(GMT +10:00) Australia/Sydney" },
                new TimeZone { Offset = 10.5, Text = "(GMT +10:30) Australia/Lord_Howe" },
                new TimeZone { Offset = 11, Text = "(GMT +11:00) Asia/Kamchatka" },
                new TimeZone { Offset = 11, Text = "(GMT +11:00) Pacific/Noumea" },
                new TimeZone { Offset = 11.5, Text = "(GMT +11:30) Pacific/Norfolk" },
                new TimeZone { Offset = 12, Text = "(GMT +12:00) Pacific/Auckland" },
                new TimeZone { Offset = 12, Text = "(GMT +12:00) Pacific/Tarawa" },
                new TimeZone { Offset = 12.75, Text = "(GMT +12:45) Pacific/Chatham" },
                new TimeZone { Offset = 13, Text = "(GMT +13:00) Pacific/Tongatapu" },
                new TimeZone { Offset = 13, Text = "(GMT +13:00) Pacific/Apia" },
                new TimeZone { Offset = 14, Text = "(GMT +14:00) Pacific/Kiritimati" }
            };
        }

        public class TimeZone
        {
            public double Offset { get; set; }
            public string Text { get; set; }
        }
    }
}