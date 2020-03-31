using ChustaSoft.GamersPlatformUtils.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class PlatformFactory : IPlatformFactory
    {
        public Task<IEnumerable<IAnalyzer>> GetAnalyzersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICleaner>> GetCleanersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPlatform>> GetPlatformsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
