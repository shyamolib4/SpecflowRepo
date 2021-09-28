using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI_Automation
{
    class Program
    {
        public static IWebDriver WebDriver { get; set; }

        public static string LogFolder = ConfigurationManager.AppSettings["LogFolder"] + "\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        private static string LogFileName = LogFolder + "\\TestLog.txt";

        static void Main(string[] args)
        {
            Program.IntitializeDriver();
            System.IO.Directory.CreateDirectory(LogFolder);
            Program.Log("***********************************************************START of test case***********************************************************");

            WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["ApplicationURL"]);
            try
            {
                WebDriver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("television");
                Thread.Sleep(3000);
                WebDriver.FindElement(By.Id("nav-search-submit-button")).Click();
                Thread.Sleep(3000);
                WebDriver.FindElement(By.XPath("//div[@class='s-expand-height s-include-content-margin s-latency-cf-section s-border-bottom']//img[@data-image-index='1']")).Click();
                Thread.Sleep(3000);
                String windowHandle = WebDriver.WindowHandles[1];
                WebDriver.SwitchTo().Window(windowHandle);

                String telName= WebDriver.FindElement(By.Id("productTitle")).Text;
                Program.Log("Element to be added in the cart:" +telName);

                WebDriver.FindElement(By.XPath("//input[@value='Add to Cart']")).Click();
                Thread.Sleep(3000);
                WebDriver.FindElement(By.Id("nav-cart-count-container")).Click();
                Thread.Sleep(3000);

                IList<IWebElement> list = WebDriver.FindElements(By.XPath("//span[@class='a-truncate-cut']"));

                foreach (IWebElement el in list)
                {
                    Program.Log("In the cart:" + el.Text);

                    if (el.Text.Contains(telName))
                    {
                        Assert.AreEqual(telName, el.Text);
                        Program.Log("Verified item in the cart is:" + el.Text);
                    }
                    else
                    {
                        Assert.AreNotEqual(telName, el.Text);
                    }
                }
            }
            catch (Exception e)
            {
                Program.Log("Error occurred : " + e.Message);
            }
            finally
            {
                Thread.Sleep(5000);
                WebDriver.Quit();
                Program.Log("***********************************************************END of test case***********************************************************");
            }
        }
        
        public static IWebDriver IntitializeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            WebDriver = new ChromeDriver(options);
            WebDriver.Manage().Window.Maximize();
            return WebDriver;
        }
        
        public static void Log(string message)
        {
            File.AppendAllLines(LogFileName, new[] { message });
            Console.WriteLine(message);
        }
    }
}
