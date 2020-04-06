using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain.Constants;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class SteamBusiness : IPlatform
    {

        public bool Available => !string.IsNullOrEmpty(AppPath);
        public string Name => SteamConstants.PLATFORM_NAME;
        public string Brand => SteamConstants.BRAND_NAME;
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
                using (var key = Registry.LocalMachine.OpenSubKey(SteamConstants.STEAM_REG_ENTRY))
                {
                    if (key?.GetValue("InstallPath") is string configuredPath)
                        this.AppPath = configuredPath;
                }
            }
        }

    }
}
