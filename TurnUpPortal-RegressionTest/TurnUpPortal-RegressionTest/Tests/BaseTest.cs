using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Pages;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver = null!;
        protected LoginPage LoginPage = null!;
        protected HomePage HomePage = null!;

        [SetUp]
        public void SetUp()
        {
            Driver = WebDriverFactory.CreateChromeDriver();

            LoginPage = new LoginPage(Driver);
            HomePage = new HomePage(Driver);

            LoginPage.Login(TestSettings.Username, TestSettings.Password);

            Assert.That(HomePage.IsLoggedInAs("Hello hari!"), Is.True, "Login was not successful.");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
