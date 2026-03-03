using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Pages
{
    public class HomePage
    {
        public void UserLoginConfirm(IWebDriver driver)
        {
            
            IWebElement actualText = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            if (actualText.Text == "Hello hari!")
            {
                Console.WriteLine("User logged in Successfully!");

            }
            else
            {
                Console.WriteLine("User login failed.");

            }
        }
        public void Navigate(IWebDriver driver)
        {
            // Create a Time and material
            IWebElement adminTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminTab.Click();

            Wait.WaitForElementToBeClicable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/ul[1]/li[5]/ul[1]/li[3]/a[1]"));
            timeAndMaterialOption.Click();
        }

    }
}
