using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain.Constants;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class OriginBusiness : PlatformBase, ILinkFinder, IAnalyzer
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

        public async Task<IEnumerable<FileInfo>> AnalyzeAsync()
        {
            return await Task.Run(() =>
            {
                return new List<FileInfo>(FindPaths().Select(x => new FileInfo(x)));
            });
        }

        private IEnumerable<string> FindPaths()
        {
            List<string> foundPaths = new List<string>();
            List<string> files = new List<string>();

            foundPaths.AddRange(SearchOnCurrentLocations());
            foundPaths.AddRange(SearchOnLegacyLocations());

            AddNestedFiles(foundPaths);

            FindFilesByType(files, foundPaths);
            FindFilesOnLibFolder(files, foundPaths);
            return foundPaths;
        }

        private void AddNestedFiles(List<string> paths)
        {
            var nested = paths.Where(Directory.Exists).Select(Directory.GetDirectories)
                .SelectMany(nestedGameFolders => nestedGameFolders)
                .ToList();
            paths.AddRange(nested);
        }

        private void FindFilesByType(List<string> files, IEnumerable<string> paths)
        {
            Regex dirRegex = new Regex("(.*)(directx|redist|miles|support|installer)(.*)", RegexOptions.IgnoreCase);

            foreach (var path in paths)
            {
                if (!dirRegex.IsMatch(path))
                {
                    continue;
                }
                if (ContainsReparsePoint(path) && PathExists(path))
                {
                    AddFilesByType(files, path);
                    FindFilesByType(files, Directory.GetDirectories(path));
                }
            }
        }

        private bool ContainsReparsePoint(string path)
        {
            var pathInfo = new FileInfo(path);
            return pathInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);
        }

        private bool PathExists(string path)
        {
            return Directory.Exists(path) || File.Exists(path);
        }
        
        private void FindFilesOnLibFolder(List<string> files, IEnumerable<string> paths)
        {
            foreach (var path in paths)
            {
                if (!path.Contains("\\lib"))
                {
                    continue;
                }
                AddFilesByOs(files, path);
                FindFilesOnLibFolder(files, Directory.GetDirectories(path));
            }
        }

        private void AddFilesByType(List<string> files, string path)
        {
            if (!string.IsNullOrEmpty(path)){
                Regex fileRegex = new Regex("(cab|exe|msi|so)", RegexOptions.IgnoreCase);

                files.AddRange(from f in Directory.GetFiles(path)
                               where fileRegex.IsMatch(f)
                               select f);
            }
        }

        private void AddFilesByOs(List<string> files, string path)
        {
            string[] filters = { "darwin", "linux" };

            foreach (var filter in filters.Where(filter => path.ToLower().Contains(filter)))
            {
                files.AddRange(Directory.GetFiles(path).Select(f => f));
            }
        }

        private IEnumerable<string> SearchOnCurrentLocations()
        {
            string regPath = Environment.Is64BitOperatingSystem ? OriginConstants.CURRENT_LOCATION_64_SYSTEM : OriginConstants.CURRENT_LOCATION_32_SYSTEM;
            return GetPaths(regPath);
        }

        private IEnumerable<string> SearchOnLegacyLocations()
        {
            string regPath = Environment.Is64BitOperatingSystem ? OriginConstants.LEGACY_LOCATION_64_SYSTEM : OriginConstants.LEGACY_LOCATION_32_SYSTEM;
            return GetPaths(regPath);
        }

        private IEnumerable<string> GetPaths(string directoryPath)
        {
            List<string> foundPaths = new List<string>();
            using (var root = Registry.LocalMachine.OpenSubKey(directoryPath))
            {
                if(root != null) {
                    foundPaths.AddRange(
                        root.GetSubKeyNames().Select(key => root.OpenSubKey(key)).Where(x => x != null).Select(x => x.GetValue("Install Dir"))
                            .Select(x => x?.ToString()).Where(Directory.Exists)
                        );
                }
            }
            return foundPaths;
        }
    }
}
