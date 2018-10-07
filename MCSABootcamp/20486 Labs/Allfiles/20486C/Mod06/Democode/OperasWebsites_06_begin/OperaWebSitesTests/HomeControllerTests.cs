using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using OperasWebsites.Controllers;
using OperasWebsites.Models;
using OperasWebSite.Controllers;

namespace OperaWebSitesTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            // Arrange
            HomeController controller = new HomeController();
            var expected = "Index";

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(expected, result.ViewName);
        }

        [TestMethod]
        public void Test_Details_Return_Opera()
        {
            // Arrange
            IOperaRepository repo = new TestOperaRepository();
            OperaController controller = new OperaController(repo);
            var expected = 201;

            // Act
            var result = controller.Details(1) as ViewResult;
            var opera = result.Model as Opera;

            // Assert
            Assert.AreEqual(expected, opera.OperaID);
        }

        [TestMethod]
        public void Test_Details_Return_NotFound()
        {
            // Arrange
            IOperaRepository repo = new TestOperaRepository();
            OperaController controller = new OperaController(repo);
            var expected = 404;

            // Act
            var result = controller.Details(0) as HttpNotFoundResult;
            
            // Assert
            Assert.AreEqual(expected, result.StatusCode);
        }

    }
}
