using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Pages
{
    public class LoginPage
    {
        
        private readonly IWebDriver driver;

        private readonly By usernameInput = By.Id("UserName");
        private readonly By passwordInput = By.Id("Password");
        private readonly By loginButton = By.XPath("//input[@value='Log in']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl(TestSettings.BaseUrl);
        }

        public void Login(string username, string password)
        {
            Open();

            WaitHelper.WaitUntilVisible(driver, usernameInput).SendKeys(username);
            driver.FindElement(passwordInput).SendKeys(password);
            driver.FindElement(loginButton).Click();
        }
    }
}
