using ChustaSoft.GamersPlatformUtils.Abstractions;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain
{
    public class SteamBusiness : PlatformBase, ISteamBusiness, IAnalyzer
    {

        public SteamBusiness(ServiceResolver serviceAccessor)
           : base(serviceAccessor, RepositoriesDefinition.VDF_REPOSITORY)
        { }


        public async Task<IEnumerable<FileInfo>> AnalyzeAsync()
        {
            if (string.IsNullOrEmpty(AppPath))
                return null;

            return await Task.Run(() =>
            {
                var filesList = new List<FileInfo>();

                foreach (string path in this.Libraries)
                {
                    filesList.AddRange(GetFiles(path));
                }

                return filesList;
            });
        }

        protected override void LoadPlatform()
        {
            this.AppPath = GetPath();
            this.Available = !string.IsNullOrEmpty(AppPath);
            this.Name = SteamConstants.PLATFORM_NAME;
            this.Brand = SteamConstants.BRAND_NAME;
            this.Libraries = GetLibraries();
        }


        private string GetPath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                using (var key = Registry.LocalMachine.OpenSubKey(SteamConstants.REG_ENTRY))
                {
                    if (key?.GetValue(SteamConstants.INSTALLPATH_HKEY) is string configuredPath)
                        return configuredPath;
                }
            }
            return string.Empty;
        }

        private IEnumerable<FileInfo> GetFiles(string path)
        {
            var files = new List<FileInfo>();
            var commonDirectory = new DirectoryInfo(path);

            foreach (var nestedDirectory in commonDirectory.EnumerateDirectories())
            {
                if (nestedDirectory.FullName.Contains(SteamConstants.REDIST_FOLDER_NAME))
                {
                    var nestedFolderFiles = nestedDirectory.GetFiles().ToList();
                    files.AddRange(nestedFolderFiles);
                }

                if (nestedDirectory.GetDirectories().Any())
                    files.AddRange(GetFiles(nestedDirectory.FullName));
            }

            return files.OrderBy(x => x.FullName);
        }

        private IEnumerable<string> GetLibraries()
        {
            var librariesPaths = new List<string>();

            TryAddMainPath(librariesPaths);
            TryAddSecondaryPaths(librariesPaths);

            return librariesPaths;
        }

        private void TryAddSecondaryPaths(List<string> librariesPaths)
        {
            var secondaryPaths = _readFileRepository.Read(this.AppPath + SteamConstants.CONFIG_SUBPATH)
                .Where(x => x.Value.Contains(SteamConstants.BASEFOLDER_CONFIG_KEY))
                .Select(x => x.Value);

            if (secondaryPaths.Any())
                librariesPaths.AddRange(secondaryPaths);
        }

        private void TryAddMainPath(List<string> librariesPaths)
        {
            var mainPath = $"{AppPath}{SteamConstants.GAMES_FOLDER}";
            if (Directory.Exists(mainPath))
                librariesPaths.Add(mainPath);
        }

    }
}
