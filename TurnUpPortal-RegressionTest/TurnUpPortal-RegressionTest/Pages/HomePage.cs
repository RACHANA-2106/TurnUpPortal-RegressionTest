using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        private readonly By helloUserText = By.XPath("//*[@id='logoutForm']/ul/li/a");
        private readonly By administrationMenu = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span");
        private readonly By timeAndMaterialsOption = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        private readonly By employeesOption = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetLoggedInUserText()
        {
            return WaitHelper.WaitUntilVisible(driver, helloUserText).Text.Trim();
        }

        public bool IsLoggedInAs(string expectedGreeting)
        {
            return GetLoggedInUserText().Equals(expectedGreeting, StringComparison.OrdinalIgnoreCase);
        }

        public TimeMaterialPage GoToTimeMaterials()
        {
            WaitHelper.WaitUntilClickable(driver, administrationMenu).Click();
            WaitHelper.WaitUntilClickable(driver, timeAndMaterialsOption).Click();
            return new TimeMaterialPage(driver);
        }

        public EmployeePage GoToEmployees()
        {
            WaitHelper.WaitUntilClickable(driver, administrationMenu).Click();
            WaitHelper.WaitUntilClickable(driver, employeesOption).Click();
            return new EmployeePage(driver);
        }

    }
}
