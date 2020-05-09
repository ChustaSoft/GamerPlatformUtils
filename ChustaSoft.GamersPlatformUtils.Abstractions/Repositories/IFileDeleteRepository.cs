using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IFileDeleteRepository
    {
        Task<CleanResult> DeleteAsync(IEnumerable<FileInfo> paths);
    }
}
