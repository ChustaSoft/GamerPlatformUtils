using ChustaSoft.Common.Helpers;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Services
{
    public class AnalyzerService : ServiceBase, IAnalyzerService
    {

        public readonly IDictionary<string, IAnalyzer> _analyzers;


        public AnalyzerService(ILogger logger, IPlatformFactory platformFactory)
            : base(logger)
        {
            _analyzers = platformFactory.GetAnalyzers();
        }


        public Task<IEnumerable<FileInfo>> AnalyzeAsync(IEnumerable<string> platforms)
        {
            return Task.Run(() => GetAnalysedPaths(platforms));
        }


        private async Task<IEnumerable<FileInfo>> GetAnalysedPaths(IEnumerable<string> platforms)
        {
            var filePaths = new ConcurrentBag<FileInfo>();
            var analyzerTasks = platforms.Select(async platform =>
            {
                if (_analyzers.ContainsKey(platform))
                    filePaths.AddRange(await _analyzers[platform].AnalyzeAsync());
                else
                    _logger.LogWarning($"Selected platform has no analyzer implemented: {platform}");
            });

            await Task.WhenAll(analyzerTasks);
            
            return filePaths;
        }

    }
}
