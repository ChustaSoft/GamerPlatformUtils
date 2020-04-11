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


        public PlatformFactory(IFileRepository fileRepository)
        {
            _steamBusiness = new SteamBusiness();
            _originBusiness = new OriginBusiness(fileRepository);
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
            throw new NotImplementedException();
        }

        public IDictionary<string, PlatformBase> GetPlatforms()
        {
            return new Dictionary<string, PlatformBase>
            {
                { SteamConstants.PLATFORM_NAME, _steamBusiness },
                { OriginConstants.PLATFORM_NAME, _originBusiness },
            };
        }

    }
}
