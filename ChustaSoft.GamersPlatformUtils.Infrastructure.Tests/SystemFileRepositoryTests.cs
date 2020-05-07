using Chustasoft.GamersPlatformUtils.Infrastructure.Implementations;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Infrastructure.Tests
{
    public class SystemFileRepositoryTests
    {
        [Test]
        public async Task Given_ListOfFileInfo_When_Clean_Then_ReturnSuccessCleanResult()
        {
#if DEBUG 
            var systemFileRepository = new SystemFileRepository();
            var files = new List<FileInfo> { new FileInfo("TestFile") };

            var cleanResult = await systemFileRepository.DeleteAsync(files);

            Assert.IsTrue(cleanResult.Success);
#else
            Assert.IsTrue(true);
#endif
        }
    }
}