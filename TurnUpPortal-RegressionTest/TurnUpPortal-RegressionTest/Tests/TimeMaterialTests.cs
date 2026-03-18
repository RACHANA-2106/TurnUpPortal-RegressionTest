using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TurnUpPortal_RegressionTest.Models;
using TurnUpPortal_RegressionTest.Pages;
using TurnUpPortal_RegressionTest.Utilities;

namespace TurnUpPortal_RegressionTest.Tests
{
    [TestFixture]
    public class TimeMaterialTests : BaseTest
    {
        [Test]
        public void CreateTimeMaterialRecord_ShouldCreateSuccessfully()
        {
            var page = HomePage.GoToTimeMaterials();

            var record = new TimeMaterialData
            {
                Code = $"TM_{DateTime.UtcNow:yyyyMMddHHmm}",
                Description = "Automation-created TM record",
                Price = "100"
            };

            page.CreateRecord(record);
            Thread.Sleep(8000); // Wait for the record to be created and appear in the list
            Assert.That(page.GetLastRecordCode(), Is.EqualTo(record.Code));
        }

        [Test]
        public void EditTimeMaterialRecord_ShouldUpdateSuccessfully()
        {
            var page = HomePage.GoToTimeMaterials();

            var original = new TimeMaterialData
            {
                Code = $"TM_{DateTime.UtcNow:yyyyMMdd}",
                Description = "Original description",
                Price = "100"
            };

            page.CreateRecord(original);
            Thread.Sleep(8000);

            var updated = new TimeMaterialData
            {
                Code = $"{original.Code}_Edited",
                Description = "Updated description",
                Price = "150"
            };

            page.EditLastRecord(updated);
            Thread.Sleep(8000); // Wait for the record to be created and appear in the list
            Assert.That(page.GetLastRecordCode(), Is.EqualTo(updated.Code));
        }

        [Test]
        public void DeleteTimeMaterialRecord_ShouldDeleteLastRecord()
        {
            var page = HomePage.GoToTimeMaterials();

            var record = new TimeMaterialData
            {
                Code = $"TM_{DateTime.UtcNow:yyyyMMddHHmmss}",
                Description = "To be deleted",
                Price = "110"
            };

            page.CreateRecord(record);
            Thread.Sleep(8000);
            page.DeleteLastRecord();
            Thread.Sleep(8000); // Wait for the record to be created and appear in the list
            Assert.That(page.GetLastRecordCode(), Is.Not.EqualTo(record.Code));
        }
    }


}
