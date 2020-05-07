using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chustasoft.GamersPlatformUtils.Infrastructure.Implementations
{
    public class SystemFileRepository : IFileDeleteRepository
    {

        public async Task<CleanResult> DeleteAsync(IEnumerable<FileInfo> paths)
        {
            return await Task.Run(() =>
            {
                var result = new CleanResult();

                foreach (FileInfo file in paths)
                    PerformRemove(result, file);

                if (result.ErrorList.Any())
                    result.Success = false;

                return result;
            });
        }


        private static void PerformRemove(CleanResult result, FileInfo file)
        {
            try
            {
                if (!file.IsReadOnly)
                {
                    file.Delete();
                    result.CleanedDirectories++;
                }
            }
            catch (Exception ex)
            {
                result.ErrorList.Add(file.FullName, ex.Message);
            }
        }

    }
}
