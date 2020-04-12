using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain.Constants;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class OriginBusiness : PlatformBase, ILinkFinder
    {

        private readonly IReadWriteFileRepository _readWriteFileRepository;

        private string ConfigXMLPath { get; set; }

        public OriginBusiness(IReadWriteFileRepository readWriteFileRepository)
            : base()
        {
            _readWriteFileRepository = readWriteFileRepository;
        }

        protected override void LoadPlatform()
        {
            this.AppPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), OriginConstants.ORIGIN_FOLDER_NAME);
            this.ConfigXMLPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), OriginConstants.ORIGIN_FOLDER_NAME, OriginConstants.ORIGIN_CONFIG_XML);
            this.Available = Directory.Exists(this.AppPath);
            this.Name = OriginConstants.PLATFORM_NAME;
            this.Brand = OriginConstants.BRAND_NAME;
            this.Libraries = Enumerable.Empty<string>();
        }

        public Task<IEnumerable<GameLink>> FindAsync()
        {
            return Task.Run(() => {

                var  xmlValues = _readWriteFileRepository.Read(this.ConfigXMLPath);

                string libraryLocation = xmlValues.ContainsKey(OriginConstants.LIBRARY_XML_KEY) ? xmlValues[OriginConstants.LIBRARY_XML_KEY] : string.Empty;

                return GetGameLinksFromLibraryDirectory(libraryLocation);
            });
        }

        private IEnumerable<GameLink> GetGameLinksFromLibraryDirectory(string path)
        {
            List<GameLink> gameLinks = new List<GameLink>();
            Directory.GetDirectories(path).ToList().ForEach(subDirectory =>
            {
                gameLinks.Add(new GameLink { Name = Path.GetFileName(subDirectory), Path = FileSystem.GetFileInfo((Path.Combine(path, subDirectory))) });
            });

            return gameLinks;
        }
    }
}
