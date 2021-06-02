using System;
using Xunit;
using project.Controllers;
using Microsoft.AspNetCore.Mvc;
using project.Data;


namespace ProjectUnitTest
{
    public class UnitTest2
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            HController controller = new HController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            HController controller = new HController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewNameEqualIndex()
        {
            // Arrange
            HController controller = new HController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.Equal("Index", result?.ViewName);
        }
    }
}
