using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarManufactureApp;
using CarManufactureApp.Controllers;

namespace CarManufactureApp.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CarController controller = new CarController();

            // Act
            ViewResult result = controller.Index("","") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
