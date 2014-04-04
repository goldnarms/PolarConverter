using PolarConverter.BLL.Entiteter;

namespace PolarConverter.BLL.Interfaces
{
    public interface IFileMapper
    {
        byte[] MapData(PolarFile hrmFile, UploadViewModel model);
    }
}