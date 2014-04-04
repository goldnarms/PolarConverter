using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarConverter.BLL.Factories
{
    public static class TrainingCenterFactory
    {
        public static TrainingCenterDatabase_t CreateTrainingCenterDatabase(Activity_t activity)
        {
            return new TrainingCenterDatabase_t { Author = new Application_t { Name = "www.polarconverter.com" }, Activities = new ActivityList_t { Activity = new []{ activity}} };
        }
    }
}
