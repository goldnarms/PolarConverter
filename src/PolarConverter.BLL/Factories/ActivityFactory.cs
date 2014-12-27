using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Helpers;

namespace PolarConverter.BLL.Factories
{
    public static class ActivityFactory
    {
        public static Activity_t CreateActivity(string sport, string notes, DateTime starTime)
        {
            return new Activity_t { Id = starTime.ToUniversalTimeZone(), Sport = SportHelper.SetSport(sport), Notes = notes };
        }
    }
}
