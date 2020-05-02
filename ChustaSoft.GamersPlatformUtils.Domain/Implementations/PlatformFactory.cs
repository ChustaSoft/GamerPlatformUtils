using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Domain
{
    public class PlatformFactory : IPlatformFactory
    {

        private readonly ISteamBusiness _steamBusiness;
        private readonly IOriginBusiness _originBusiness;
        private readonly IXboxBusiness _xboxBusiness;


        public PlatformFactory(ISteamBusiness steamBusiness, IOriginBusiness originBusiness, IXboxBusiness xboxBusiness)
        {
            _steamBusiness = steamBusiness;
            _originBusiness = originBusiness;
            _xboxBusiness = xboxBusiness;
        }


        public IDictionary<string, IAnalyzer> GetAnalyzers()
        {
            return new Dictionary<string, IAnalyzer>
            {
                { SteamConstants.PLATFORM_NAME, _steamBusiness },
                { OriginConstants.PLATFORM_NAME, _originBusiness }
            };
        }

        public IDictionary<string, ICleaner> GetCleaners()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ILinkAssigner> GetLinkAssigners()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ILinkFinder> GetLinkFinders()
        {
            return new Dictionary<string, ILinkFinder> {
                { OriginConstants.PLATFORM_NAME, _originBusiness },
                { XboxConstants.PLATFORM_NAME, _xboxBusiness }
            };
        }

        public IDictionary<string, IPlatform> GetPlatforms()
        {
            return new Dictionary<string, IPlatform>
            {
                { SteamConstants.PLATFORM_NAME, _steamBusiness },
                { OriginConstants.PLATFORM_NAME, _originBusiness },
                { XboxConstants.PLATFORM_NAME, _xboxBusiness }
            };
        }

    }
}
