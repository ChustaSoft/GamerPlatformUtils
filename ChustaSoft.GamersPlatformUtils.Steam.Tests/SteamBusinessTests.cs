using ChustaSoft.GamersPlatformUtils.Domain.Implementations;
using NUnit.Framework;

namespace ChustaSoft.GamersPlatformUtils.Steam.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var steamPlatform = new SteamBusiness();
            
            Assert.IsTrue(steamPlatform.Available);
        }
    }
}