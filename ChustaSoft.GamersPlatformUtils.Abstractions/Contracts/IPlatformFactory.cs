using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IPlatformFactory
    {
        IDictionary<string, IPlatform> GetPlatforms();

        IDictionary<string, IAnalyzer> GetAnalyzers();

        IDictionary<string, ICleaner> GetCleaners();

        IDictionary<string, ILinkFinder> GetLinkFinders();

        IDictionary<string, ILinkAssigner> GetLinkAssigners();
    }
}
