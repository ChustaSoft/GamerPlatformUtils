using Chustasoft.GamersPlatformUtils.Infrastructure.Implementations;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain
{
    public class SteamBusiness : PlatformBase, ISteamBusiness, IAnalyzer
    {

        public SteamBusiness()
            : base()
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

        protected async override void LoadPlatform()
        {
            this.AppPath = GetPath();
            this.Available = !string.IsNullOrEmpty(AppPath);
            this.Name = SteamConstants.PLATFORM_NAME;
            this.Brand = SteamConstants.BRAND_NAME;
            //this.Libraries = await GetLibraries();


            var configPath = this.AppPath + SteamConstants.CONFIG_SUBPATH;
            //var dataArray = await File.ReadAllLinesAsync(configPath);

            //var secondaryPaths = dataArray.Where(x => x.Contains(SteamConstants.BASEFOLDER_CONFIG_KEY));

            //return secondaryPaths.Select(x => GetPathFromConfigLine(x));

            var repo = new JSONFileRepository();

            var data = repo.Read(configPath);

            //return Enumerable.Empty<string>();
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

        //private async Task<IEnumerable<string>> GetLibraries()
        //{
        //    var librariesPaths = new List<string>();

        //    TryAddMainPath(librariesPaths);
        //    await TryAddSecondaryPaths(librariesPaths);

        //    return librariesPaths;
        //}

        //private async Task TryAddSecondaryPaths(List<string> librariesPaths)
        //{
        //    var secondaryPaths = await GetSecondaryPathsAsync();
        //    if (secondaryPaths.Any())
        //        librariesPaths.AddRange(secondaryPaths);
        //}

        private void TryAddMainPath(List<string> librariesPaths)
        {
            var mainPath = $"{AppPath}{SteamConstants.GAMES_FOLDER}";
            if (Directory.Exists(mainPath))
                librariesPaths.Add(mainPath);
        }

        //private IEnumerable<string> GetSecondaryPathsAsync()
        //{
        //    var configPath = this.AppPath + SteamConstants.CONFIG_SUBPATH;
        //    //var dataArray = await File.ReadAllLinesAsync(configPath);

        //    //var secondaryPaths = dataArray.Where(x => x.Contains(SteamConstants.BASEFOLDER_CONFIG_KEY));

        //    //return secondaryPaths.Select(x => GetPathFromConfigLine(x));

        //    var repo = new JSONFileRepository();

        //    var data = repo.Read(configPath);

        //    return Enumerable.Empty<string>();
        //}

        //private string GetPathFromConfigLine(string configLine)
        //{
        //    Regex pathRegex = new Regex(@"[A-Z]:\\\\(.*)", RegexOptions.IgnoreCase);

        //    return pathRegex.Match(configLine).Value.Replace("\\\\", "\\").Replace('"', ' ').Trim();
        //}

    }
}
