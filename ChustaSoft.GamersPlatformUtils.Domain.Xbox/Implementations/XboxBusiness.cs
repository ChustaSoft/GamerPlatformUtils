using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Linq;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Management.Automation;
using ChustaSoft.GamersPlatformUtils.Infrastructure;

namespace ChustaSoft.GamersPlatformUtils.Domain.Implementations
{
    public class XboxBusiness : IPlatform, ILinkFinder
    {
        public bool Available => throw new NotImplementedException();

        public string Name => "Xbox";

        public string Brand => "Micosoft";

        public string AppPath => throw new NotImplementedException();

        public IEnumerable<string> Libraries => throw new NotImplementedException();

        public string RootFolderName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private readonly string powershellExecutionPolicy = "Set-ExecutionPolicy -Scope Process -ExecutionPolicy Unrestricted;";

        IFileRepository _fileRepository;

        public XboxBusiness(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public Task<IEnumerable<GameLink>> FindAsync()
        {
            return Task.Run(() =>
            {
                Dictionary<string, string> fileResults = _fileRepository.Read(string.Empty);

                IEnumerable<GameLink> installedApps = fileResults.Keys.Select(x => new GameLink { Name = x, Path = new FileInfo(fileResults[x]) }).ToList();

                return installedApps;
            });
        }
                
    }
}
