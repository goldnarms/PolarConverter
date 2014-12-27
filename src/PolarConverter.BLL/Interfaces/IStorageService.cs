using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarConverter.BLL.Interfaces
{
    public interface IStorageService
    {
        string GetAuthorizeUrl();
        void GetFilesForUser();
    }
}
