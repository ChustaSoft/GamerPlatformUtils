using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IAnalyzer
    {
        Task<IEnumerable<FileInfo>> AnalyzeAsync();
    }
}
