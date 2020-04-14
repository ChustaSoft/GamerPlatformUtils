using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain.Constants;
using System;
using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class PlatformFactory : IPlatformFactory
    {

        private readonly SteamBusiness _steamBusiness;
        private readonly OriginBusiness _originBusiness;
        private readonly XboxBusiness _xboxBusiness;


        public PlatformFactory(IReadWriteFileRepository readWriteFileRepository, IReadFileRepository readFileRepository) 
        {
            _steamBusiness = new SteamBusiness();
            _originBusiness = new OriginBusiness(readWriteFileRepository);
            _xboxBusiness = new XboxBusiness(readFileRepository);
        }


        public IDictionary<string, IAnalyzer> GetAnalyzers()
        {
            return new Dictionary<string, IAnalyzer>
            {
                { SteamConstants.PLATFORM_NAME, _steamBusiness }
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

        public IDictionary<string, PlatformBase> GetPlatforms()
        {
            return new Dictionary<string, PlatformBase>
            {
                { SteamConstants.PLATFORM_NAME, _steamBusiness },
                { OriginConstants.PLATFORM_NAME, _originBusiness },
                { XboxConstants.PLATFORM_NAME, _xboxBusiness }
            };
        }

    }
}
