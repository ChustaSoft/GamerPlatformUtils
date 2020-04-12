using ChustaSoft.GamersPlatformUtils.Abstractions;
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
