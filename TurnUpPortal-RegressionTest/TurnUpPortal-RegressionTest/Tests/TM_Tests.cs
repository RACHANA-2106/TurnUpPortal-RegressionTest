using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TurnUpPortal_RegressionTest.Pages;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            driver = new ChromeDriver();

            LoginPage lp = new LoginPage();
            lp.LoginActions(driver);


            HomePage hp = new HomePage();
            // hp.UserLoginConfirm(driver);
            hp.Navigate(driver);
        }
            [Test]
            public void CreateTimeRecordTest()
            {
                TMPage tmp = new TMPage();
                tmp.CreateTimeRecord(driver);
            }

            [Test]
            public void EditTimeRecordTest()
        {
            // Edit Time Record
            TMPage tmp = new TMPage();
            tmp.EditTimeRecord(driver);
        }
    }
    
}
