using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public class CleanResult
    {

        public bool Success { get; set; }
        public int CleanedDirectories { get; set; }
        public IDictionary<string, string> ErrorList { get; set; }


        public CleanResult()
        {
            ErrorList = new Dictionary<string, string>();
            Success = true;
            CleanedDirectories = 0;
        }


        public override string ToString() => $"Files removed: {CleanedDirectories}, Errors: {ErrorList.Count}.";

    }
}
