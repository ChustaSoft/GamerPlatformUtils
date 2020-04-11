using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Infrastructure;
using System;
using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class PlatformFactory : IPlatformFactory
    {

        private readonly SteamBusiness _steamBusiness;
        private readonly OriginBusiness _originBusiness;
        private readonly XboxBusiness _xboxBusiness;


        public PlatformFactory() 
        {
            _steamBusiness = new SteamBusiness();
            _originBusiness = new OriginBusiness(new XMLFileRepository());
            _xboxBusiness = new XboxBusiness(new PowershellRepository());
        }


        public IEnumerable<IAnalyzer> GetAnalyzers()
        {
            return new List<IAnalyzer>
            {
                _steamBusiness,                
            };
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
            return new List<ILinkFinder> {
                _originBusiness,
                _xboxBusiness
            };
        }

        public IEnumerable<PlatformBase> GetPlatforms()
        {
            return new List<PlatformBase>
            {
                _steamBusiness,
                _originBusiness,
                _xboxBusiness
            };
        }

    }
}
