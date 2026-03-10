using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Pages;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Tests
{
    [TestFixture]
    public class EmployeeTests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);

            LoginPage lp = new LoginPage();
            lp.LoginActions(driver);


            HomePage hp = new HomePage();
            hp.NavigatetoEmployeesPage(driver);
        }
        [Test]
        public void CreateEmployeeTest()
        {
            EmployeePage emp = new EmployeePage();
            emp.CreateEmployeeRecord(driver);
        }


        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
