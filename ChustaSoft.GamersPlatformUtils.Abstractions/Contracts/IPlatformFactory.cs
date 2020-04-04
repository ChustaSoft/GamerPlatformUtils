using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IPlatformFactory
    {
        IEnumerable<IPlatform> GetPlatforms();

        IEnumerable<IAnalyzer> GetAnalyzers();

        IEnumerable<ICleaner> GetCleaners();

        IEnumerable<ILinkFinder> GetLinkFinders();

        IEnumerable<ILinkAssigner> GetLinkAssigners();
    }
}
