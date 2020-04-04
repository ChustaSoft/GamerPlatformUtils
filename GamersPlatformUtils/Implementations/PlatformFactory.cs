using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class PlatformFactory : IPlatformFactory
    {

        private readonly SteamBusiness _steamBusiness;
        private readonly OriginBusiness _originBusiness;


        public PlatformFactory()
        {
            _steamBusiness = new SteamBusiness();
            _originBusiness = new OriginBusiness();
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
                _steamBusiness,
                _originBusiness
            };
        }

    }
}
