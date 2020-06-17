using ChustaSoft.GamersPlatformUtils.Abstractions;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain
{
    public class OriginBusiness : FileDependantPlatformBase, IOriginBusiness, ILinkFinder, IAnalyzer
    {

        private string ConfigXMLPath { get; set; }


        public OriginBusiness(ServiceResolver serviceAccessor)
            : base(serviceAccessor, RepositoriesDefinition.XML_REPOSITORY)
        { }


        public Task<IEnumerable<GameLink>> FindAsync()
        {
            return Task.Run(() => {
                var gameLinks = new List<GameLink>();

                foreach (var pathLibrary in this.Libraries) 
                {
                    if (Directory.Exists(pathLibrary))
                    {
                        foreach (var subDirectory in Directory.GetDirectories(pathLibrary))
                            gameLinks.Add(new GameLink(Path.GetFileName(subDirectory), FileSystem.GetFileInfo(Path.Combine(pathLibrary, subDirectory))));
                    }
                }
                return gameLinks.AsEnumerable();
            });
        }

        public async Task<IEnumerable<FileInfo>> AnalyzeAsync()
        {
            return await Task.Run(() =>
            {
                return new List<FileInfo>(FindPaths().Select(x => new FileInfo(x)));
            });
        }

        protected override void LoadPlatform()
        {
            this.AppPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), OriginConstants.ORIGIN_FOLDER_NAME);
            this.ConfigXMLPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), OriginConstants.ORIGIN_FOLDER_NAME, OriginConstants.ORIGIN_CONFIG_XML);
            this.Available = Directory.Exists(this.AppPath);
            this.Name = OriginConstants.PLATFORM_NAME;
            this.Brand = OriginConstants.BRAND_NAME;
            this.Libraries = GetLibraries();
        }


        private IEnumerable<string> GetLibraries()
        {
            var librariesPaths = new List<string>();

            TryAddSecondaryPath(librariesPaths);

            return librariesPaths;
        }

        private void TryAddSecondaryPath(List<string> librariesPaths)
        {
            var xmlValues = _readFileRepository.Read(this.ConfigXMLPath);

            if (xmlValues.ContainsKey(OriginConstants.LIBRARY_XML_KEY))
                librariesPaths.Add(xmlValues[OriginConstants.LIBRARY_XML_KEY]);
        }

        private IEnumerable<string> FindPaths()
        {
            /*TODO: Bug
             * Paso 1: Parece ser que primero carga del registro todos los installation paths, los cuales los añade por defecto a la lista de directorios a borrar
             * 1. SearchOnCurrentLocations
             * 2. SearchOnLegacyLocations
             * 3. AddNestedFiles (Con este registra todos los subpaths de cada installation de Origin)
             * Paso 2: En realidad, debería sólo incluir la segunda búsqueda, que es el siguiente paso
             * 1. FindFilesByType
             * 2. FindFilesOnLibFolder
             * 
             * foundpaths solo debería devolver lo que hace el paso 2 ??
             * Qué funcion tiene la lista files ??
            */
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

                files.AddRange(from f in Directory.GetFiles(path) where fileRegex.IsMatch(f) select f);
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
            var foundPaths = new List<string>();
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
