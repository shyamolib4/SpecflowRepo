
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
            Program.IntitializeDriver();
            System.IO.Directory.CreateDirectory(Program.LogFolder);
          
        }

        [TestMethod]
        
        public void TestMethod1()
        {
            Program.Login();
        }

        [TestMethod]
        public void TestMethod2()
        {
            Program.AddToCart();
        }


        [TestCleanup]
        public void TearDown()
        {
            Program.WebDriver.Quit();
        }
    }
}
