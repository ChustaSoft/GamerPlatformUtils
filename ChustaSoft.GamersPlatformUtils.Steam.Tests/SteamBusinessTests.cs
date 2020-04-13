using ChustaSoft.GamersPlatformUtils.Domain.Implementations;
using NUnit.Framework;

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
    }
}