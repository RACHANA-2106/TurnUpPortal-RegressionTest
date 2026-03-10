using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Pages
{
    public class EmployeePage
    {

        public void CreateEmployeeRecord(IWebDriver driver)
        {

            IWebElement createNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNew.Click();

             IWebElement name = driver.FindElement(By.XPath("//input[@id='Name']"));
             name.SendKeys("Rachel");

            IWebElement username = driver.FindElement(By.Id("Username"));
            username.SendKeys("TestEngineerR21");

            IWebElement contactNo = driver.FindElement(By.Id("ContactDisplay"));
            contactNo.SendKeys("0274561234");

            IWebElement password = driver.FindElement(By.XPath("//input[@name='Password']"));
            password.SendKeys("TestR@211");

            IWebElement retypePassword = driver.FindElement(By.Id("RetypePassword"));
            retypePassword.SendKeys("TestR@211");

            IWebElement adminCheckbox = driver.FindElement(By.CssSelector("#IsAdmin"));
            adminCheckbox.Click();

            IWebElement groupDropdown = driver.FindElement(By.CssSelector(".k-multiselect-wrap.k-floatwrap"));
            groupDropdown.Click();

            Wait.WaitForElementToBeClickable(driver, "XPath", "/html[1]/body[1]/div[5]/div[1]/ul[1]/li[1]", 2);

            IWebElement groupOption = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/div[1]/ul[1]/li[1]"));
            groupOption.Click();

            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

            IWebElement list = driver.FindElement(By.CssSelector("div[id='container'] div a"));
            list.Click();

            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[4]/a[4]/span[1]", 3);

            IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton.Click();

            IWebElement newEmpRecord = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table[1]/tbody[1]/tr[last()]/td[1]"));
            //Console.WriteLine(newEmpRecord.Text);

            if (newEmpRecord.Text == "Rachel")
            {
                Assert.Pass("Employee record created successfully!");
            }
            else
            {
                Assert.Fail("Employee record creation failed.");

            }


        }
    }
}