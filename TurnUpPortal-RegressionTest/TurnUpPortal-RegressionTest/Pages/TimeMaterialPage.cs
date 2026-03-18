using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Models;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Pages
{
    public class TimeMaterialPage
    {
        private readonly IWebDriver driver;

        private readonly By createNewButton = By.XPath("//*[@id='container']/p/a");
        private readonly By typeCodeDropdown = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span");
        private readonly By timeOption = By.XPath("//*[@id='TypeCode_listbox']/li[2]");
        private readonly By codeInput = By.Id("Code");
        private readonly By descriptionInput = By.Id("Description");
        private readonly By priceClick= By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div[1]/span[1]/span[1]/input[1]");
        private readonly By priceInput = By.Id("Price");
        private readonly By saveButton = By.Id("SaveButton");
        private readonly By lastPageButton = By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span[1]");
        private readonly By lastRowCodeCell = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
        private readonly By lastRowEditButton = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        private readonly By lastRowDeleteButton = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]");

        public TimeMaterialPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CreateRecord(TimeMaterialData record)
        {
            WaitHelper.WaitUntilClickable(driver, createNewButton).Click();
            WaitHelper.WaitUntilClickable(driver, typeCodeDropdown).Click();
            WaitHelper.WaitUntilClickable(driver, timeOption).Click();

            driver.FindElement(codeInput).SendKeys(record.Code);
            driver.FindElement(descriptionInput).SendKeys(record.Description);
            driver.FindElement(priceClick).Click();
            driver.FindElement(priceInput).SendKeys(record.Price);

            driver.FindElement(saveButton).Click();
        }

        public void EditLastRecord(TimeMaterialData updatedRecord)
        {
            GoToLastPage();
            WaitHelper.WaitUntilClickable(driver, lastRowEditButton).Click();

            var codeTextbox = WaitHelper.WaitUntilVisible(driver, codeInput);
            codeTextbox.Clear();
            codeTextbox.SendKeys(updatedRecord.Code);

            var descriptionTextbox = driver.FindElement(descriptionInput);
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(updatedRecord.Description);

            var priceTextbox = driver.FindElement(priceClick);
            priceTextbox.Clear();
            //priceTextbox.SendKeys(updatedRecord.Price);

            driver.FindElement(saveButton).Click();
        }

        public void DeleteLastRecord()
        {
            GoToLastPage();
            WaitHelper.WaitUntilClickable(driver, lastRowDeleteButton).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public string GetLastRecordCode()
        {
            
            GoToLastPage();
            return WaitHelper.WaitUntilVisible(driver, lastRowCodeCell).Text.Trim();
        }

        public void GoToLastPage()
        {
            WaitHelper.WaitUntilClickable(driver, lastPageButton).Click();
        }

    }
}
