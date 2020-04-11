using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain.Constants;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class SteamBusiness : Platform, IAnalyzer
    {

        public SteamBusiness() 
            : base()
        { }


        public async Task<IEnumerable<FileInfo>> AnalyzeAsync()
        {
            if (string.IsNullOrEmpty(AppPath))
                return null;

            var paths = new List<string>();

            string commonSteamPath = $"{AppPath}{SteamConstants.GAMES_FOLDER}";

            if (!Directory.Exists(commonSteamPath))
                return null;

            return await Task.Run(() => GetFiles(commonSteamPath));
        }


        protected override void LoadPlatform()
        {
            this.AppPath = GetPath();
            this.Available = !string.IsNullOrEmpty(AppPath);
            this.Name = SteamConstants.PLATFORM_NAME;
            this.Brand = SteamConstants.BRAND_NAME;
            this.Libraries = Enumerable.Empty<string>();
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

                if (!nestedDirectory.GetDirectories().Any())
                    files.AddRange(GetFiles(nestedDirectory.FullName));
            }

            return files.OrderBy(x => x.FullName);
        }

    }
}
