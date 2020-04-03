using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface ICleaner
    {
        Task<CleanResult> CleanAsync(IEnumerable<FileInfo> paths);
    }
}
