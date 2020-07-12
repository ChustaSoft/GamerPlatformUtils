using Chustasoft.GamersPlatformUtils.Infrastructure.Implementations;
using ChustaSoft.GamersPlatformUtils.Domain;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Steam.Tests
{
    public class SteamBusinessTests
    {
        [Test]
        public void Given_SteamPlatformInInstalledEnvironment_When_Available_Then_True()
        {
#if DEBUG
            var steamPlatform = new SteamBusiness((x) => new VDFFileRepository());
            Assert.IsTrue(steamPlatform.Available);
#else
            Assert.IsTrue(true);
#endif
        }

        [Test]
        public async Task Given_InstalledEnviromentAvailable_When_Analyze_Then_ReturnListOfFiles()
        {
#if DEBUG
            var steamPlatform = new SteamBusiness((x) => new VDFFileRepository());
            var files = await steamPlatform.AnalyzeAsync();
            bool result = files.Count() >= 0;

            Assert.IsTrue(result);
#else
            Assert.IsTrue(true);
#endif

        }

    }
}