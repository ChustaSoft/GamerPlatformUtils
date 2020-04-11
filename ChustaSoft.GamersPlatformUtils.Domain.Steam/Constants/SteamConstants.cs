namespace ChustaSoft.GamersPlatformUtils.Domain.Constants
{
    public struct SteamConstants
    {
        public const string PLATFORM_NAME = "Steam";
        public const string BRAND_NAME = "Valve";

        internal const string REG_ENTRY = @"SOFTWARE\Wow6432Node\Valve\Steam";
        internal const string INSTALLPATH_HKEY = "InstallPath";
        internal const string REDIST_FOLDER_NAME = "_CommonRedist";
        internal const string GAMES_FOLDER = "\\steamapps\\common";
    }
}
