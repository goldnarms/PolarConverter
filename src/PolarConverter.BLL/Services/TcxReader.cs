using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Services
{
    public class TcxReader
    {
        public TrainingCenterDatabase_t Deserialize(Stream stream)
        {
            var ser = new XmlSerializer(typeof(TrainingCenterDatabase_t));
            return (TrainingCenterDatabase_t)ser.Deserialize(stream);
        }
    }
}
