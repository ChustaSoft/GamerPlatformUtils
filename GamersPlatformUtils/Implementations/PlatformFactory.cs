using ChustaSoft.GamersPlatformUtils.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class PlatformFactory : IPlatformFactory
    {
        public Task<IEnumerable<IAnalyzer>> GetAnalyzers()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICleaner>> GetCleaners()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPlatform>> GetPlatforms()
        {
            throw new NotImplementedException();
        }
    }
}
