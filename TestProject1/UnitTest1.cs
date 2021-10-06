
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using UI_Automation;


namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void Startup()
        {
            Utilities.IntitializeDriver();
            System.IO.Directory.CreateDirectory(Utilities.LogFolder);
            Utilities.Log("***********************************************************START of test case***********************************************************");
            Scenarios.Login();
        }

        
        [TestMethod]
        public void TestMethod2()
        {
            Scenarios.AddToCart();
        }

        [TestCleanup]
        public void TearDown()
        {
            Scenarios.Logout();
            Utilities.WebDriver.Quit();
            Utilities.Log("***********************************************************END of test case************************************************************");
        }
    }
}
