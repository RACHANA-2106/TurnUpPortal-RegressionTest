using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUpPortal_RegressionTest.Utilities
{
    public class WaitHelper
    {
        public static IWebElement WaitUntilVisible(IWebDriver driver, By locator, int seconds = TestSettings.DefaultWaitInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitUntilClickable(IWebDriver driver, By locator, int seconds = TestSettings.DefaultWaitInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool WaitUntilTextPresent(IWebDriver driver, By locator, string expectedText, int seconds = TestSettings.DefaultWaitInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return element.Text.Trim().Contains(expectedText, StringComparison.OrdinalIgnoreCase);
            });
        }
    }
}
