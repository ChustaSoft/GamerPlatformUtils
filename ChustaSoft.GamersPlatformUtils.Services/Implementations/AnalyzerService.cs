using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Services.Contracts;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Services.Implementations
{
    public class AnalyzerService : IAnalyzerService
    {

        public readonly IDictionary<string, IAnalyzer> _analyzers;


        public AnalyzerService(IPlatformFactory platformFactory)
        {
            _analyzers = platformFactory.GetAnalyzers();
        }


        public Task<IEnumerable<FileInfo>> AnalyzeAsync(IEnumerable<string> platforms)
        {
            return Task.Run(() => GetAnalysedPaths(platforms));
        }


        private IEnumerable<FileInfo> GetAnalysedPaths(IEnumerable<string> platforms)
        {
            var filePaths = new ConcurrentBag<FileInfo>();

            platforms
                .AsParallel()
                .ForAll(async platform =>
                {
                    filePaths.AddRange(await _analyzers[platform].AnalyzeAsync());
                });

            return filePaths;
        }

    }
}
