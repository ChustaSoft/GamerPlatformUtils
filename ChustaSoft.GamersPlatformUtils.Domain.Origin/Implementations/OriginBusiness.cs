using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class OriginBusiness : IPlatform
    {
        private const string ORIGIN_CONFIG_XML = "local.xml";
        private const string ORIGIN_FOLDER_NAME = "Origin";

        public bool Available => IsAvailable();
        public string Name => "Origin";
        public string Brand => "Electronic Arts";
        public string AppPath { private set; get; }
        public IEnumerable<string> Libraries => throw new NotImplementedException();

        public OriginBusiness()
        {
            LoadPlatform();
        }

        private void LoadPlatform()
        {
            this.AppPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), ORIGIN_FOLDER_NAME, ORIGIN_CONFIG_XML); ;
        }

        private bool IsAvailable()
        {
            return Directory.Exists(this.AppPath);
        }
    }
}
