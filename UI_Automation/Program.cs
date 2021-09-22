using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito"); 
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            try
            {
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("ApplicationURL"));
                Thread.Sleep(3000);
                driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("television");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("nav-search-submit-button")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//div[@class='s-expand-height s-include-content-margin s-latency-cf-section s-border-bottom']//img[@data-image-index='1']")).Click();
                Thread.Sleep(3000);
                

                String windowHandle = driver.WindowHandles[1];
                driver.SwitchTo().Window(windowHandle);
                driver.FindElement(By.XPath("//input[@value='Add to Cart']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("attach-close_sideSheet-link")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("nav-cart-count-container")).Click();
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred : " + e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
