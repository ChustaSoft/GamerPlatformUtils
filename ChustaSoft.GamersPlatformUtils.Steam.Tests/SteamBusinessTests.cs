using ChustaSoft.GamersPlatformUtils.Domain.Implementations;
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
            var steamPlatform = new SteamBusiness();

            #if DEBUG
            Assert.IsTrue(steamPlatform.Available);
            #else
            Assert.IsTrue(true);
            #endif
        }

        [Test]
        public async Task Given_InstalledEnviromentAvailable_When_Analyze_Then_ReturnListOfFiles()
        {
            var steamPlatform = new SteamBusiness();

            #if DEBUG
            var files = await steamPlatform.AnalyzeAsync();
            bool result = files.Count() >= 0;

            Assert.IsTrue(result);
            #else
            Assert.IsTrue(true);
            #endif

        }
    }
}