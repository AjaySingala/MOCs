using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using OperasWebSites.Controllers;
using OperasWebSites.Models;
using OperasWebSites.Tests.Repositories;

namespace OperasWebSites.Tests
{
    [TestClass]
    public class OperasControllerTest
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            // Arrange
            var repo = new OperaRepositoryTest();
            var controller = new OperasController(repo);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
