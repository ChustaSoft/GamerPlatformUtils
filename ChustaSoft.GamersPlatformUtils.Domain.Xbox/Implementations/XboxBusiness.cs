using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain
{
    public class XboxBusiness : PlatformBase, IXboxBusiness, ILinkFinder
    {

        public XboxBusiness(ServiceResolver serviceAccessor)
            : base(serviceAccessor, RepositoriesDefinition.POWERSHELL_REPOSITORY)
        { }


        public Task<IEnumerable<GameLink>> FindAsync()
        {
            return Task.Run(() =>
            {
                var fileResults = _readFileRepository.Read(string.Empty);

                IEnumerable<GameLink> installedApps = fileResults.Keys.Select(x => new GameLink { Name = x, Path = new FileInfo(fileResults[x]) }).ToList();

                return installedApps;
            });
        }

        protected override void LoadPlatform()
        {
            this.AppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.Available = Directory.Exists(AppPath);
            this.Name = XboxConstants.PLATFORM_NAME;
            this.Brand = XboxConstants.BRAND_NAME;
            this.Libraries = Enumerable.Empty<string>();
        }

    }
}
