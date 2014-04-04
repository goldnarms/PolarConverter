using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Interfaces
{
    public interface IConversion
    {
        ConversionResult Convert(UploadViewModel model);
    }
}
