namespace ChustaSoft.GamersPlatformUtils.Abstractions
{

    public struct RepositoriesDefinition 
    {
        public const string XML_REPOSITORY = "XML";
        public const string VDF_REPOSITORY = "VDF";
        public const string SYSTEM_REPOSITORY = "SYS";
        public const string POWERSHELL_REPOSITORY = "PS";
    }


    public delegate IReadFileRepository ServiceResolver(string key);


}
