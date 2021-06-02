using System;
using Xunit;
using project.Controllers;
using Microsoft.AspNetCore.Mvc;
using project.Data;
namespace ProjectUnitTest
{
    public class UnitTest3
    {
         [Fact]
       public void IndexTest()
      {
           // Arrange
           HController controller = new HController();

           // Act
           ViewResult result = controller.Index() as ViewResult;

           // Assert
           Assert.Equal("Hello world!", result?.ViewData["Message"]);
           Assert.NotNull(result);
           Assert.Equal("Index", result?.ViewName);
       }
    }
}

