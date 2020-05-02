namespace ChustaSoft.GamersPlatformUtils.Domain
{
    public struct OriginConstants
    {
        public const string PLATFORM_NAME = "Origin";
        public const string BRAND_NAME = "Electronic Arts";

        internal const string ORIGIN_CONFIG_XML = "local.xml";
        internal const string ORIGIN_FOLDER_NAME = "Origin";
        internal const string LIBRARY_XML_KEY = "DownloadInPlaceDir";
        internal const string LIBRARY_XML_FIRST_LEVEL_TAG = "Settings";

        internal const string CURRENT_LOCATION_64_SYSTEM = @"SOFTWARE\Wow6432Node\Electronic Arts";
        internal const string CURRENT_LOCATION_32_SYSTEM = @"SOFTWARE\Electronic Arts";
        internal const string LEGACY_LOCATION_64_SYSTEM = @"SOFTWARE\Wow6432Node\EA Games";
        internal const string LEGACY_LOCATION_32_SYSTEM = @"SOFTWARE\EA Games";
    }
}
