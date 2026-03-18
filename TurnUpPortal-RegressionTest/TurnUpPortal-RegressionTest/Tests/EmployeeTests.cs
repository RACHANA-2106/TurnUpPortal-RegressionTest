using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortal_RegressionTest.Models;
using TurnUpPortal_RegressionTest.Pages;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Tests
{
    [TestFixture]
    public class EmployeeTests : BaseTest
    {
        [Test]
        public void CreateEmployee_ShouldCreateSuccessfully()
        {
            var page = HomePage.GoToEmployees();

            var uniqueValue = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

            var employee = new EmployeeData
            {
                Name = $"Rachel_{uniqueValue}",
                Username = $"TestEngineer_{uniqueValue}",
                ContactNumber = "0274561234",
                Password = "TestR@211"
            };

            page.CreateEmployee(employee);

            Assert.That(page.GetLastEmployeeName(), Is.EqualTo(employee.Name));
        }
    }
}
