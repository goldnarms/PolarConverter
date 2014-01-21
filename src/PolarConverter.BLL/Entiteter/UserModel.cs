using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolarConverter.BLL.Entiteter
{
    public class UserModel
    {
        public Dictionary<string, string> HrmFiles { get; set; }

        public Dictionary<string, string> GpxFiles { get; set; }

        public Dictionary<string, string> XmlFiles { get; set; }
        
        public Dictionary<string, string> SportName { get; set; }

        public UserInfo UserInfo { get; set; }

        public double? Weight { get; set; }

        public bool SendToStrava { get; set; }

        public string StravaUsername { get; set; }

        public string TimeZoneCorrection { get; set; }

        public string Message { get; set; }

        public string UserGuid { get; set; }

        public bool ForceGarmin { get; set; }
    }
}
