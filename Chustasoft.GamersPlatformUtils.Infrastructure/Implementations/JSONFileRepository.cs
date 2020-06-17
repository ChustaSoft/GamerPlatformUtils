using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chustasoft.GamersPlatformUtils.Infrastructure.Implementations
{
    public class JSONFileRepository : IReadFileRepository
    {
        private const int PAIR_VALUE_OCCURENCES_NUMBER = 4;

        public IDictionary<string, string> Read(string path)
        {
            var dictionary = new Dictionary<string, string>();
            var dataArray = File.ReadAllLines(path);

            foreach (var line in dataArray) 
            {
                //*TODO: IDENTYFY LINES WITH 4 "
                //If ok, extract key and value, and add it to dictionary
                var reps = line.Count(f => f == '"');

                if (reps == PAIR_VALUE_OCCURENCES_NUMBER) 
                {
                    var key = GetKey(line);
                    var value = GetValueData(line);
                }

                


                

                //dictionary.Add(line, GetValueData(line));
            }

            return dictionary;
        }

        private string GetKey(string fileLine) 
        {
            var firstquoteIndex = fileLine.IndexOf('"');
            var keyTextStarts = fileLine.Substring(firstquoteIndex, fileLine.Length - 1 - firstquoteIndex);
            var secondQuoteIndex = keyTextStarts.IndexOf('"');
            keyTextStarts = keyTextStarts.Substring(secondQuoteIndex, keyTextStarts.Length - 1 - secondQuoteIndex);
            var thridQuoteIndex = keyTextStarts.IndexOf('"');
            var keyValue = keyTextStarts.Substring(0, thridQuoteIndex);

            return keyValue;
        }

        private string GetValueData(string keyData)
        {
            Regex pathRegex = new Regex(@"[A-Z]:\\\\(.*)", RegexOptions.IgnoreCase);

            return pathRegex.Match(keyData).Value.Replace("\\\\", "\\").Replace('"', ' ').Trim();
        }

    }
}
