using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace ChustaSoft.GamersPlatformUtils.Infrastructure
{
	public class PowershellRepository : IFileRepository
	{
        private const string POWERSHELL_RESULTS_SEPARATOR = "\n";
        private const string POWERSHELL_EXECUTION_POLICY = "Set-ExecutionPolicy -Scope Process -ExecutionPolicy Unrestricted;";
        private const string POWERSHELL_PATH = "getInstalledMicrosoftAppsPs.txt";
        private const string POWERSHELL_LINE_PARTS_SEPARATOR = "||";

        public PowershellRepository()
		{
		}

		public Dictionary<string, string> Read(string path)
		{
            RunScript(POWERSHELL_EXECUTION_POLICY);

            string psScript = File.ReadAllText(POWERSHELL_PATH);

            IEnumerable<string> resultLines = RunScript(psScript).Split(POWERSHELL_RESULTS_SEPARATOR).ToList();

            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            resultLines.ToList().ForEach(x => BuildResults(x, dataDictionary));

            return dataDictionary;
		}

		public void Write()
		{
			throw new NotImplementedException();
		}

        private void BuildResults(string appInfo, Dictionary<string, string> dataDictionary)
        {
            string[] appInfoParts = appInfo.Split(POWERSHELL_LINE_PARTS_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            if (appInfo.Contains(POWERSHELL_LINE_PARTS_SEPARATOR) && !dataDictionary.ContainsKey(appInfoParts[0]))
            {
                dataDictionary.Add(appInfoParts[0], appInfoParts[1]);
            }
        }

        private string RunScript(string scriptText)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();

            runspace.Open();

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            pipeline.Commands.Add("Out-String");

            Collection<PSObject> results = pipeline.Invoke();

            runspace.Close();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
