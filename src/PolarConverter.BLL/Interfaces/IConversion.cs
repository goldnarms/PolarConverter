using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Interfaces
{
    public interface IConversion
    {
        ConversionResult Convert(UploadViewModel model);
    }
}
