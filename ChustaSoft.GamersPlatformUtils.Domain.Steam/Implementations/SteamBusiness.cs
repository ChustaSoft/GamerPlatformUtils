using ChustaSoft.GamersPlatformUtils.Abstractions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class SteamBusiness : IPlatform
    {

        private const string STEAM_REG_ENTRY = @"SOFTWARE\Wow6432Node\Valve\Steam";


        public bool Available => !string.IsNullOrEmpty(AppPath);
        public string Name => "Steam";
        public string Brand => "Valve";
        public string AppPath { private set; get; }
        public IEnumerable<string> Libraries => throw new NotImplementedException();


        public SteamBusiness() 
        {
            LoadPlatform();
        }


        private void LoadPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                using (var key = Registry.LocalMachine.OpenSubKey(STEAM_REG_ENTRY))
                {
                    if (key?.GetValue("InstallPath") is string configuredPath)
                        this.AppPath = configuredPath;
                }
            }
        }

    }
}
