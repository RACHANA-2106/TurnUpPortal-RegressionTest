using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Models;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Pages
{
    public class EmployeePage
    {

        private readonly IWebDriver driver;

        private readonly By createNewButton = By.XPath("//*[@id='container']/p/a");
        private readonly By nameInput = By.Id("Name");
        private readonly By usernameInput = By.Id("Username");
        private readonly By contactInput = By.Id("ContactDisplay");
        private readonly By passwordInput = By.Name("Password");
        private readonly By retypePasswordInput = By.Id("RetypePassword");
        private readonly By adminCheckbox = By.CssSelector("#IsAdmin");
        private readonly By groupDropdown = By.CssSelector(".k-multiselect-wrap.k-floatwrap");
        private readonly By firstGroupOption = By.XPath("/html/body/div[5]/div/ul/li[1]");
        private readonly By saveButton = By.Id("SaveButton");
        private readonly By listButton = By.CssSelector("div[id='container'] div a");
        private readonly By lastPageButton = By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span[1]");
        private readonly By lastRowNameCell = By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]");

        public EmployeePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CreateEmployee(EmployeeData employee)
        {
            WaitHelper.WaitUntilClickable(driver, createNewButton).Click();

            driver.FindElement(nameInput).SendKeys(employee.Name);
            driver.FindElement(usernameInput).SendKeys(employee.Username);
            driver.FindElement(contactInput).SendKeys(employee.ContactNumber);
            driver.FindElement(passwordInput).SendKeys(employee.Password);
            driver.FindElement(retypePasswordInput).SendKeys(employee.RetypePassword);

            driver.FindElement(adminCheckbox).Click();
            driver.FindElement(groupDropdown).Click();
            WaitHelper.WaitUntilClickable(driver, firstGroupOption).Click();

            driver.FindElement(saveButton).Click();
            WaitHelper.WaitUntilClickable(driver, listButton).Click();
        }

        public string GetLastEmployeeName()
        {
            WaitHelper.WaitUntilClickable(driver, lastPageButton).Click();
            return WaitHelper.WaitUntilVisible(driver, lastRowNameCell).Text.Trim();
        }
    }
}