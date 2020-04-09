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

        public XboxBusiness()
        {
            FindAsync();
        }

        public Task<IEnumerable<GameLink>> FindAsync()
        {
            List<String> result = null;
            var assembly = Assembly.GetExecutingAssembly();
            //Load the powershell script to get installed apps
            var resourceName = "C:\\Code\\GamerPlatformUtils\\ChustaSoft.GamersPlatformUtils.Domain.Xbox\\Resources\\GetAUMIDScript.txt";
            try
            {
                Stream stream = new FileStream(resourceName, FileMode.Open);
                using (stream)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        //Every entry is listed separated by ;
                        result = ScriptManager.RunScript(reader.ReadToEnd()).Split(';').ToList<string>();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error trying to get installed apps on your PC " + Environment.NewLine + e.Message, e.InnerException);
            }

            return null;
        }


        //public Task<IEnumerable<GameLink>> FindAsync()
        //{
        //    return Task.Run(() => {

        //        var appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages");

        //        string[] directories = Directory.GetDirectories(appPath);


        //        List<KeyValuePair<string, string>> installs = new List<KeyValuePair<string, string>>();
        //        List<string> keys = new List<string>() {
        //              @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
        //              @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        //            };

        //        // The RegistryView.Registry64 forces the application to open the registry as x64 even if the application is compiled as x86 
        //        FindInstalls(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64), keys, installs);
        //        FindInstalls(RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64), keys, installs);

        //        installs = installs.Where(s => !string.IsNullOrWhiteSpace(s.Value) && !string.IsNullOrWhiteSpace(s.Key) && s.Key.Contains("Microsoft")).Distinct().ToList();
        //        //installs.Sort(); // The list of ALL installed applications


        //        return new List<GameLink>().AsEnumerable();
        //    });
        //}




        private void FindInstalls(RegistryKey regKey, List<string> keys, List<KeyValuePair<string, string>> installedApps)
        {
            foreach (string key in keys)
            {
                using (RegistryKey rk = regKey.OpenSubKey(key))
                {
                    if (rk == null)
                    {
                        continue;
                    }
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            try
                            {
                                installedApps.Add( new KeyValuePair<string, string> (Convert.ToString(sk.GetValue("Publisher")), Convert.ToString(sk.GetValue("DisplayName"))));
                            }
                            catch (Exception ex)
                            { }
                        }
                    }
                }
            }
        }
    }

    static class ScriptManager
    {
        public static string RunScript(string scriptText)
        {
            // create Powershell runspace
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it
            runspace.Open();

            // create a pipeline and feed it the script text
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            // add an extra command to transform the script
            // output objects into nicely formatted strings

            // remove this line to get the actual objects
            // that the script returns. For example, the script

            // "Get-Process" returns a collection
            // of System.Diagnostics.Process instances.
            pipeline.Commands.Add("Out-String");

            // execute the script
            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace
            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
