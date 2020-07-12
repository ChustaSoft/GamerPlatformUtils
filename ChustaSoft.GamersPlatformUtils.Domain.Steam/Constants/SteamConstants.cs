using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Domain
{
    public struct SteamConstants
    {
        public const string PLATFORM_NAME = "Steam";
        public const string BRAND_NAME = "Valve";

        internal const string REG_ENTRY = @"SOFTWARE\Wow6432Node\Valve\Steam";
        internal const string INSTALLPATH_HKEY = "InstallPath";        
        internal const string GAMES_FOLDER = "\\steamapps\\common";
        internal const string BASEFOLDER_CONFIG_KEY = "BaseInstallFolder_";
        internal const string CONFIG_SUBPATH = "\\config\\config.vdf";

        internal static List<string> TRASH_FOLDERS = new List<string>
        {
            "_CommonRedist",
            "vcredist",
            "Support",
            "Docs",
            "Documentation",
        };
    }
}
