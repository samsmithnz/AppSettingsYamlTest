using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppSettingsYamlTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public IConfigurationRoot Configuration;

        [TestInitialize]
        public void TestStartUp()
        {
            IConfigurationBuilder config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings2.json");
            Configuration = config.Build();
        }


        [TestMethod]
        public void ShouldFailInGitHubActions()
        {

            Assert.AreEqual("1977 was the best year", Configuration["AppSettings:MySecret"]);
        }

        [TestMethod]
        public void ShouldFailLocally()
        {

            Assert.AreEqual("2020 is the worst year", Configuration["AppSettings:MySecret2"]);
        }
    }
}
