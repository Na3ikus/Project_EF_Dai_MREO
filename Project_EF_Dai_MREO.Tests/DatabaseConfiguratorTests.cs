using NUnit.Framework;
using System.Reflection;
using DAI_MREO.Configuration;

namespace DAI_MREO.Tests
{
    public class DatabaseConfiguratorTests
    {
        [Test]
        public void GetHostInfo_WithValidConnectionString_ReturnsServerAndUser()
        {
            string conn = """server=example.com;user id=testuser;password=secret;database=mydb;""";

            var method = typeof(DatabaseConfigurator).GetMethod("GetHostInfo", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(method, "GetHostInfo method not found");

            var result = method!.Invoke(null, new object[] { conn }) as string;

            Assert.IsNotNull(result);
            Assert.IsTrue(result!.Contains("example.com"));
            Assert.IsTrue(result.Contains("testuser"));
        }

        [Test]
        public void GetHostInfo_WithEmptyOrInvalid_ReturnsExpected()
        {
            var method = typeof(DatabaseConfigurator).GetMethod("GetHostInfo", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(method);

            var resEmpty = method!.Invoke(null, new object[] { string.Empty }) as string;
            Assert.AreEqual("Empty", resEmpty);

            var resBad = method.Invoke(null, new object[] { "not a conn string" }) as string;
            Assert.AreEqual("Unknown host", resBad);
        }
    }
}
