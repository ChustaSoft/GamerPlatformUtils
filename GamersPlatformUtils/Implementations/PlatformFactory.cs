using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class PlatformFactory : IPlatformFactory
    {

        private readonly SteamBusiness _steamBusiness;


        public PlatformFactory()
        {
            _steamBusiness = new SteamBusiness();
        }


        public IEnumerable<IAnalyzer> GetAnalyzers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICleaner> GetCleaners()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILinkAssigner> GetLinkAssigners()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILinkFinder> GetLinkFinders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPlatform> GetPlatforms()
        {
            return new List<IPlatform>
            {
                _steamBusiness
            };
        }

    }
}
