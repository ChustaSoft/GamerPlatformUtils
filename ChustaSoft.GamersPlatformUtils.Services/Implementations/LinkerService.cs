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
    public class LinkerService : ServiceBase, ILinkerService
    {

        public readonly IDictionary<string, ILinkFinder> _finders;        


        public LinkerService(ILogger logger, IPlatformFactory platformFactory)
            : base(logger)
        {
            _finders = platformFactory.GetLinkFinders();
        }


        public Task<IEnumerable<GameLink>> SearchAsync(IEnumerable<string> platforms)
        {
            return Task.Run(() => GetAnalysedPaths(platforms));
        }


        private async Task<IEnumerable<GameLink>> GetAnalysedPaths(IEnumerable<string> platforms)
        {
            var filePaths = new ConcurrentBag<GameLink>();
            var analyzerTasks = platforms.Select(async platform =>
            {
                if (_finders.ContainsKey(platform))
                    filePaths.AddRange(await _finders[platform].FindAsync());
                else
                    _logger.LogWarning($"Selected platform has no LinkFinder implemented: {platform}");
            });

            await Task.WhenAll(analyzerTasks);
            
            return filePaths;
        }

    }
}
