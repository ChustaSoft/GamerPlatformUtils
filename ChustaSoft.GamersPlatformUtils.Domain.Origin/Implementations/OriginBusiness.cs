using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using ChustaSoft.GamersPlatformUtils.Infrastructure;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class OriginBusiness : IPlatform, ILinkFinder
    {
        private const string ORIGIN_CONFIG_XML = "local.xml";
        private const string ORIGIN_FOLDER_NAME = "Origin";

        private const string LIBRARY_XML_KEY = "DownloadInPlaceDir";
        private const string LIBRARY_XML_FIRST_LEVEL_TAG = "Settings";

        public bool Available => IsAvailable();
        public string Name => "Origin";
        public string Brand => "Electronic Arts";
        public string AppPath { private set; get; }
        public string ConfigXMLPath { private set; get; }
        public IEnumerable<string> Libraries => throw new NotImplementedException();

        private readonly IFileRepository _fileRepository;

        public string RootFolderName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public OriginBusiness(IFileRepository fileRepository)
        {
            LoadPlatform();
            _fileRepository = fileRepository;
        }

        private void LoadPlatform()
        {
            this.AppPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), ORIGIN_FOLDER_NAME);
            this.ConfigXMLPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), ORIGIN_FOLDER_NAME, ORIGIN_CONFIG_XML);
        }

        public Task<IEnumerable<GameLink>> FindAsync()
        {
            return Task.Run(() => {

                var  xmlValues = _fileRepository.Read(this.ConfigXMLPath);

                string libraryLocation = xmlValues.ContainsKey(LIBRARY_XML_KEY) ? xmlValues[LIBRARY_XML_KEY] : string.Empty;

                return GetGameLinksFromLibraryDirectory(libraryLocation);
            });
        }

        private bool IsAvailable()
        {
            return Directory.Exists(this.AppPath);
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
