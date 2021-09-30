using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI_Automation
{
    public class Scenarios
    {
        public static void Login()
        {
            // WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["ApplicationURL"]);
            IWebElement SigninGrid = Utilities.WebDriver.FindElement(By.XPath("//div[@class='nav-signin-tt nav-flyout']"));

            try
            {
                if (SigninGrid.Displayed)
                {
                    Utilities.WebDriver.FindElement(By.Id("nav-signin-tooltip")).Click();
                    Utilities.Log("Clicked on Sign-In through the popup grid");
                    SignIn();
                }
                else
                {
                    Utilities.WebDriver.FindElement(By.Id("nav-link-accountList")).Click();
                    Utilities.Log("Clicked on signin through the Hyperlink");
                    SignIn();
                }

            }
            catch (Exception e)
            {
                Utilities.Log("Error occurred : " + e.Message);
            }
            finally
            {
                Thread.Sleep(5000);
                // WebDriver.Quit();
            }
        }

        public static void SignIn()
        {
            String SignInText = Utilities.WebDriver.FindElement(By.XPath("//h1[@class='a-spacing-small']")).Text;

            if (SignInText.Contains("Sign-In"))
            {

                Utilities.Log("We are on the Sign-In Page");

                Utilities.WebDriver.FindElement(By.Id("ap_email")).SendKeys(ConfigurationManager.AppSettings["UserEmail"]);
                Utilities.WebDriver.FindElement(By.Id("continue")).Click();
                Utilities.WebDriver.FindElement(By.Id("ap_password")).SendKeys(ConfigurationManager.AppSettings["Password"]);
                Utilities.WebDriver.FindElement(By.Id("signInSubmit")).Click();

                Thread.Sleep(3000);

                String AppUser = Utilities.WebDriver.FindElement(By.Id("nav-link-accountList-nav-line-1")).Text;
                String[] user = AppUser.Split(',');

                String actUser = user[1].Trim();

                if (ConfigurationManager.AppSettings["UserName"].Equals(actUser))
                {
                    Utilities.Log("User " + actUser + " Successfully Signed-In");


                }
                else
                {
                    Utilities.Log("User " + actUser + " Not Successfully Signed-In");

                }
            }
            else
            {
                Utilities.Log("We are not on the Sign-In page");
            }
        }

        public static void AddToCart()
        {
            try
            {
                Utilities.WebDriver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("television");
                Thread.Sleep(3000);
                Utilities.WebDriver.FindElement(By.Id("nav-search-submit-button")).Click();
                Thread.Sleep(3000);
                Utilities.WebDriver.FindElement(By.XPath("//div[@class='s-expand-height s-include-content-margin s-latency-cf-section s-border-bottom']//img[@data-image-index='1']")).Click();
                Thread.Sleep(3000);
                String windowHandle = Utilities.WebDriver.WindowHandles[1];
                Utilities.WebDriver.SwitchTo().Window(windowHandle);

                String telName = Utilities.WebDriver.FindElement(By.Id("productTitle")).Text;
                Utilities.Log("Element to be added in the cart:" + telName);

                Utilities.WebDriver.FindElement(By.XPath("//input[@value='Add to Cart']")).Click();
                Thread.Sleep(3000);
                Utilities.WebDriver.FindElement(By.Id("nav-cart-count-container")).Click();
                Thread.Sleep(3000);

                IList<IWebElement> list = Utilities.WebDriver.FindElements(By.XPath("//span[@class='a-truncate-cut']"));

                foreach (IWebElement el in list)
                {
                    //Program.Log("In the cart:" + el.Text);

                    if (el.Text.Contains(telName))
                    {
                        //Assert.AreEqual(telName, el.Text);
                        Utilities.Log("Verified item in the cart is:" + el.Text);
                        break;
                    }
                    else
                    {
                        //Assert.AreNotEqual(telName, el.Text);
                    }
                }
            }
            catch (Exception e)
            {
                Utilities.Log("Error occurred : " + e.Message);
            }
            finally
            {
                Thread.Sleep(5000);
                Utilities.WebDriver.Quit();

            }
        }
    }
}
