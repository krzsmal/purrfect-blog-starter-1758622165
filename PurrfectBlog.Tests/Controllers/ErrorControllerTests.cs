using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using PurrfectBlog.Controllers;
using FluentAssertions;
using PurrfectBlog.Tests.Helpers;

namespace PurrfectBlog.Tests.Controllers
{
    [TestClass]
    public class ErrorControllerTests
    {
        private ErrorController _controller;

        [TestInitialize]
        public void Setup()
        {
            _controller = new ErrorController();
            TestHelper.SetupControllerContext(_controller);
        }

        [TestMethod]
        public void NotFound_ReturnsViewResult()
        {
            // Act
            var result = _controller.NotFound();

            // Assert
            result.Should().BeOfType<ViewResult>();
            // Note: Status code 404 is set by ASP.NET customErrors in Web.config, not by controller action
        }

        [TestMethod]
        public void BadRequest_ReturnsViewResult()
        {
            // Act
            var result = _controller.BadRequest();

            // Assert
            result.Should().BeOfType<ViewResult>();
            // Note: Status code 400 is set by ASP.NET customErrors in Web.config, not by controller action
        }

        [TestMethod]
        public void InternalServerError_ReturnsViewResult()
        {
            // Act
            var result = _controller.InternalServerError();

            // Assert
            result.Should().BeOfType<ViewResult>();
            // Note: Status code 500 is set by ASP.NET customErrors in Web.config, not by controller action
        }

        [TestMethod]
        public void Error_ReturnsViewResult()
        {
            // Act
            var result = _controller.Error();

            // Assert
            result.Should().BeOfType<ViewResult>();
            // Note: Error() action doesn't set specific status code, uses default 200
        }
    }
}