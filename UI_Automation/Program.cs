using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI_Automation
{
    
    class Program
    {
        public static void Main(String[] args)
        {
            AmazonSearch();
        }

      
        public static void AmazonSearch()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito","headless"); 
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),options);
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

                String telName=driver.FindElement(By.Id("productTitle")).Text;
                Console.WriteLine("Element to be added in the cart:" +telName);

                driver.FindElement(By.XPath("//input[@value='Add to Cart']")).Click();
                Thread.Sleep(3000);
                //driver.FindElement(By.Id("attach-close_sideSheet-link")).Click();
                //Thread.Sleep(3000);
                driver.FindElement(By.Id("nav-cart-count-container")).Click();
                Thread.Sleep(3000);

                //IList<IWebElement> list = driver.FindElements(By.XPath("//span[@class='a-truncate-cut']"));

                IList<IWebElement> list = driver.FindElements(By.XPath("//span[@class='a-truncate-cut']"));

                foreach(IWebElement el in list)
                {
                    Console.WriteLine("In the cart:" + el.Text);

                    if (el.Text.Contains(telName))
                    {
                        Assert.AreEqual(telName, el.Text);
                        Console.WriteLine("Verified item in the cart is:" + el.Text);
                    }
                    else
                    {
                        Assert.AreNotEqual(telName, el.Text);
                    }
                }
                
         

                
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
