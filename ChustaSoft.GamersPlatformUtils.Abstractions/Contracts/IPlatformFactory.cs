using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions.Contracts
{
    public interface IPlatformFactory
    {

        Task<IEnumerable<IPlatform>> GetPlatformsAsync();

        Task<IEnumerable<IAnalyzer>> GetAnalyzersAsync();

        Task<IEnumerable<ICleaner>> GetCleanersAsync();

    }
}
