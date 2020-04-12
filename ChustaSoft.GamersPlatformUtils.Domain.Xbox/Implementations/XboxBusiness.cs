using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using ChustaSoft.GamersPlatformUtils.Domain.Constants;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class XboxBusiness : PlatformBase, ILinkFinder
    {
        private readonly IReadFileRepository _readFileRepository;

        public XboxBusiness(IReadFileRepository readFileRepository) 
            : base()
        {
            _readFileRepository = readFileRepository;
        }

        protected override void LoadPlatform()
        {
            this.AppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.Available = Directory.Exists(AppPath);
            this.Name = SteamConstants.PLATFORM_NAME;
            this.Brand = SteamConstants.BRAND_NAME;
            this.Libraries = Enumerable.Empty<string>();
        }

        public Task<IEnumerable<GameLink>> FindAsync()
        {
            return Task.Run(() =>
            {
                var fileResults = _readFileRepository.Read(string.Empty);

                IEnumerable<GameLink> installedApps = fileResults.Keys.Select(x => new GameLink { Name = x, Path = new FileInfo(fileResults[x]) }).ToList();

                return installedApps;
            });
        }
                
    }
}
