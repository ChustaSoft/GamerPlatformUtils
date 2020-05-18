using ChustaSoft.GamersPlatformUtils.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Services
{
    public class FileService : IFileService
    {

        private readonly IFileDeleteRepository _fileDeleteRepository;


        public FileService(IFileDeleteRepository fileDeleteRepository)
        {
            _fileDeleteRepository = fileDeleteRepository;
        }


        public async Task<CleanResult> Clean(IEnumerable<FileInfo> fileInfoEnumerable)
        {
            return await _fileDeleteRepository.DeleteAsync(fileInfoEnumerable);
        }

    }
}
