using ChustaSoft.GamersPlatformUtils.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chustasoft.GamersPlatformUtils.Infrastructure.Implementations
{
    public class VDFFileRepository : IReadFileRepository
    {

        private const int PAIR_VALUE_OCCURENCES_NUMBER = 4;


        public IDictionary<string, string> Read(string path)
        {
            var dictionary = new Dictionary<string, string>();
            var dataArray = File.ReadAllLines(path);

            foreach (var line in dataArray)
            {
                var positions = GetQuotesPositions(line);

                if (positions.Count() == PAIR_VALUE_OCCURENCES_NUMBER)
                {
                    var keyValue = GetKeyValueFromLine(line, positions);

                    dictionary.TryAdd(keyValue.Key, keyValue.Value);
                }
            }

            return dictionary;
        }


        private static List<int> GetQuotesPositions(string line)
        {
            var positions = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '"')
                    positions.Add(i);
            }

            return positions;
        }

        private (string Key, string Value) GetKeyValueFromLine(string line, IList<int> positions)
        {
            var keyStr = line.Substring(positions[0] + 1, line.Length - positions[1] - 1).Trim();
            var valueStr = line.Substring(positions[2] + 1, line.Length - positions[2] - 1).Replace("\\\\", "\\").Replace('"', ' ').Trim();

            return (keyStr, valueStr);
        }

    }
}
