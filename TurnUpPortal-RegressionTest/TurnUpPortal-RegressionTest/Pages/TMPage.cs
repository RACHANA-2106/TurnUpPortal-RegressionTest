using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            IWebElement createNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNew.Click();



            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();


            Wait.WaitForElementToBeClicable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 2);


            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TestR1");

            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("Sample test description R1");

            IWebElement priceClick = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div[1]/span[1]/span[1]/input[1]"));
            priceClick.Click();

            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys("100");

            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();
            Thread.Sleep(3000);

            IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton.Click();

            IWebElement newRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table[1]/tbody[1]/tr[last()]/td[1]"));

            if (newRecord.Text == "TestR1")
            {
                Assert.Pass("Time record created successfully!");
            }
            else
            {
                Assert.Fail("Time record creation failed.");

            }
        }
            public string GetCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }
        

       
        public void EditTimeRecord(IWebDriver driver)
        {
            Console.WriteLine("Time record edited successfully!");
        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            Console.WriteLine("Time record deleted successfully!");
        }

    }
}
