using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUpPortal_RegressionTest.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver)
        {
           
            driver.Navigate().GoToUrl("http://horse.industryconnect.io");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("UserName")).SendKeys("hari");
            driver.FindElement(By.Id("Password")).SendKeys("123123");

            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();

            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);

        }
    }
}
