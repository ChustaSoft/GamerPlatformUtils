using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions.Contracts
{
    public interface IPlatformFactory
    {

        Task<IEnumerable<IPlatform>> GetPlatforms();

        Task<IEnumerable<IAnalyzer>> GetAnalyzers();

        Task<IEnumerable<ICleaner>> GetCleaners();

    }
}
