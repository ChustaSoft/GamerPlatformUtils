using ChustaSoft.GamersPlatformUtils.Abstractions;
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


        public IEnumerable<IAnalyzer> GetAnalyzers()
        {
            return new List<IAnalyzer>
            {
                _steamBusiness
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
            throw new NotImplementedException();
        }

        public IEnumerable<PlatformBase> GetPlatforms()
        {
            return new List<PlatformBase>
            {
                _steamBusiness,
                _originBusiness
            };
        }

    }
}
