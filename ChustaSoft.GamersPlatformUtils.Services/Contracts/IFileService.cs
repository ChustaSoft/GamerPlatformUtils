using ChustaSoft.GamersPlatformUtils.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Services
{
    public interface IFileService
    {

        Task<CleanResult> Clean(IEnumerable<FileInfo> fileInfoEnumerable);
        

    }
}
