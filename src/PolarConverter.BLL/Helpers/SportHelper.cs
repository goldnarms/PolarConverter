using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Helpers
{
    class SportHelper
    {
        public static Sport_t SetSport(string sport)
        {
            switch (sport)
            {
                case "Biking":
                    return Sport_t.Biking;
                case "Other":
                    return Sport_t.Other;
                case "Running":
                    return Sport_t.Running;
                default:
                    return Sport_t.Other;
            }
        }
    }
}
