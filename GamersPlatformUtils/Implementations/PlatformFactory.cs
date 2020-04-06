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


        public PlatformFactory(IFileRepository fileRepository)
        {
            _steamBusiness = new SteamBusiness();
            _originBusiness = new OriginBusiness(fileRepository);
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
