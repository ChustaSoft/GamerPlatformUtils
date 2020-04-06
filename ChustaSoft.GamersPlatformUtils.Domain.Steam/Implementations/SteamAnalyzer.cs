using ChustaSoft.GamersPlatformUtils.Abstractions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class SteamAnalyzer : IAnalyzer
    {
        private const string STEAM_64BITARCH_HKEY = @"SOFTWARE\Wow6432Node\Valve\Steam";
        private const string STEAM_32BITARCH_HKEY = @"SOFTWARE\Valve\Steam";
        private const string STEAM_INSTALLPATH_HKEY = "InstallPath";
        private const string STEAM_REDIST_FOLDER_NAME = "_CommonRedist";

        public string SteamPath { get; set; }

        public SteamAnalyzer()
        {
            SteamPath = FindSteamPath();
        }

        public async Task<IEnumerable<FileInfo>> AnalyzeAsync()
        {
            if (string.IsNullOrEmpty(SteamPath))
                return null;

            List<string> paths = new List<string>();

            string commonSteamPath = $"{SteamPath}\\steamapps\\common";

            if (!Directory.Exists(commonSteamPath))
                return null;

            return await Task.Run(() => GetFiles(commonSteamPath));
        }

        private string FindSteamPath()
        {
            bool is64BitArch = Environment.Is64BitOperatingSystem;
            string regPath = is64BitArch ? STEAM_64BITARCH_HKEY : STEAM_32BITARCH_HKEY;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(regPath);
            string path = (string)key?.GetValue(STEAM_INSTALLPATH_HKEY);

            if (key == null || string.IsNullOrEmpty(path))
            {
                return null;
            }

            key.Close();

            if (!Directory.Exists(path))
                return null;

            return path;
        }

        private IEnumerable<FileInfo> GetFiles(string path)
        {
            List<FileInfo> files = new List<FileInfo>();

            DirectoryInfo commonDirectory = new DirectoryInfo(path);

            foreach (var nestedDirectory in commonDirectory.EnumerateDirectories())
            {
                if (nestedDirectory.FullName.Contains(STEAM_REDIST_FOLDER_NAME))
                {
                    var nestedFolderFiles = nestedDirectory.GetFiles().ToList();
                    files.AddRange(nestedFolderFiles);

                }

                if (nestedDirectory.GetDirectories().Length > 0)
                    files.AddRange(GetFiles(nestedDirectory.FullName));
            }

            return files.OrderBy(x => x.FullName);
        }
    }
}
