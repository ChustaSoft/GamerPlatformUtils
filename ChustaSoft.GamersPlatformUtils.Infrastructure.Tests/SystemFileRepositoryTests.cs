using Chustasoft.GamersPlatformUtils.Infrastructure.Implementations;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Infrastructure.Tests
{
    public class SystemFileRepositoryTests
    {

        private const string TEST_FILE_NAME = @"test.txt";


        [SetUp]
        public void InitializeTest() 
        {
            CheckFileExistingForDelete();

            using (FileStream fs = File.Create(TEST_FILE_NAME))
            {
                byte[] title = new UTF8Encoding(true).GetBytes("Test text file");
                fs.Write(title, 0, title.Length);
                byte[] author = new UTF8Encoding(true).GetBytes("ChustaSoft");
                fs.Write(author, 0, author.Length);
            }
        }

        [TearDown]
        public void FinalizeTest()
        {
            CheckFileExistingForDelete();
        }


        [Test]
        public async Task Given_ListOfFileInfo_When_Clean_Then_ReturnSuccessCleanResult()
        {
            var systemFileRepository = new SystemFileRepository();
            var files = new List<FileInfo> { new FileInfo(TEST_FILE_NAME) };

            var cleanResult = await systemFileRepository.DeleteAsync(files);

            Assert.IsTrue(cleanResult.Success);
            Assert.AreEqual(files.Count, cleanResult.CleanedDirectories);
        }


        private static void CheckFileExistingForDelete()
        {
            if (File.Exists(TEST_FILE_NAME))
                File.Delete(TEST_FILE_NAME);
        }

    }
}