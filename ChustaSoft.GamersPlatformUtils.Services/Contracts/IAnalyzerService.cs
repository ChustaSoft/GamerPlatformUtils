using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Services.Contracts
{
    public interface IAnalyzerService
    {
        Task<IEnumerable<FileInfo>> AnalyzeAsync(IEnumerable<string> platforms);
    }
}
