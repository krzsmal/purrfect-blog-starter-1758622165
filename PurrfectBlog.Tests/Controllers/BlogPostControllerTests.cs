using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using PurrfectBlog.Controllers;
using PurrfectBlog.Models;
using FluentAssertions;
using PurrfectBlog.Tests.Helpers;
using System;
using System.Reflection;
using System.Linq;

namespace PurrfectBlog.Tests.Controllers
{
    [TestClass]
    public class BlogPostControllerTests
    {
        private BlogPostController _controller;

        [TestInitialize]
        public void Setup()
        {
            _controller = new BlogPostController();
            TestHelper.SetupControllerContext(_controller);
        }

        [TestMethod]
        public void Details_WithNullId_ReturnsCustomBadRequestView()
        {
            // Act
            var result = _controller.Details(null) as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.ViewName.Should().Be("~/Views/Error/BadRequest.cshtml");
            TestHelper.GetResponseStatusCode(_controller).Should().Be(400);
        }

        [TestMethod]
        public void CreatePost_GET_ReturnsView()
        {
            // Act
            var result = _controller.CreatePost() as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.ViewName.Should().BeNullOrEmpty(); // Uses default view
        }

        [TestMethod]
        public void EditPost_GET_WithNullId_ReturnsCustomBadRequestView()
        {
            // Act
            var result = _controller.EditPost((int?)null) as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.ViewName.Should().Be("~/Views/Error/BadRequest.cshtml");
            TestHelper.GetResponseStatusCode(_controller).Should().Be(400);
        }

        [TestMethod]
        public void CreatePost_POST_WithInvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "", // Invalid - empty title
                Content = "Test content",
                Category = "Test"
            };
            _controller.ModelState.AddModelError("Title", "Title is required");

            // Act
            var result = _controller.CreatePost(blogPost) as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.ViewName.Should().BeNullOrEmpty(); // Uses default view
            result.Model.Should().Be(blogPost);
            _controller.ModelState.IsValid.Should().BeFalse();
            _controller.ModelState["Title"].Errors.Should().NotBeEmpty();
        }

        [TestMethod]
        public void CreatePost_POST_WithInvalidContent_ReturnsViewWithModel()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = "", // Invalid - empty content
                Category = "Test"
            };
            _controller.ModelState.AddModelError("Content", "Content is required");

            // Act
            var result = _controller.CreatePost(blogPost) as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.ViewName.Should().BeNullOrEmpty(); // Uses default view
            result.Model.Should().Be(blogPost);
            _controller.ModelState.IsValid.Should().BeFalse();
            _controller.ModelState["Content"].Errors.Should().NotBeEmpty();
        }

        [TestMethod]
        public void CreatePost_POST_HasHttpPostAttribute()
        {
            // Arrange
            var methodInfo = typeof(BlogPostController).GetMethod("CreatePost", new[] { typeof(BlogPost) });

            // Act
            var httpPostAttribute = methodInfo.GetCustomAttribute<HttpPostAttribute>();

            // Assert
            httpPostAttribute.Should().NotBeNull("CreatePost POST action should have [HttpPost] attribute");
        }

        [TestMethod]
        public void CreatePost_POST_HasValidateAntiForgeryTokenAttribute()
        {
            // Arrange
            var methodInfo = typeof(BlogPostController).GetMethod("CreatePost", new[] { typeof(BlogPost) });

            // Act
            var antiForgeryAttribute = methodInfo.GetCustomAttribute<ValidateAntiForgeryTokenAttribute>();

            // Assert
            antiForgeryAttribute.Should().NotBeNull("CreatePost POST action should have [ValidateAntiForgeryToken] attribute for security");
        }

        [TestMethod]
        public void EditPost_POST_HasHttpPostAttribute()
        {
            // Arrange
            var methodInfo = typeof(BlogPostController).GetMethod("EditPost", new[] { typeof(BlogPost) });

            // Act
            var httpPostAttribute = methodInfo.GetCustomAttribute<HttpPostAttribute>();

            // Assert
            httpPostAttribute.Should().NotBeNull("EditPost POST action should have [HttpPost] attribute");
        }

        [TestMethod]
        public void EditPost_POST_HasValidateAntiForgeryTokenAttribute()
        {
            // Arrange
            var methodInfo = typeof(BlogPostController).GetMethod("EditPost", new[] { typeof(BlogPost) });

            // Act
            var antiForgeryAttribute = methodInfo.GetCustomAttribute<ValidateAntiForgeryTokenAttribute>();

            // Assert
            antiForgeryAttribute.Should().NotBeNull("EditPost POST action should have [ValidateAntiForgeryToken] attribute for security");
        }

        [TestMethod]
        public void EditPost_POST_WithInvalidModelState_ReturnsViewWithModel()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Id = 1,
                Title = "Test Post",
                Content = "Test content",
                Category = "Test",
                CreatedAt = DateTime.Now.AddDays(-1)
            };
            // Force ModelState to be invalid
            _controller.ModelState.AddModelError("Title", "Test validation error");

            // Act
            var result = _controller.EditPost(blogPost) as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.ViewName.Should().BeNullOrEmpty(); // Uses default view
            result.Model.Should().Be(blogPost);
            _controller.ModelState.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Delete_POST_HasHttpPostAttribute()
        {
            // Arrange
            var methodInfo = typeof(BlogPostController).GetMethod("Delete", new[] { typeof(int) });

            // Act
            var httpPostAttribute = methodInfo.GetCustomAttribute<HttpPostAttribute>();

            // Assert
            httpPostAttribute.Should().NotBeNull("Delete action should have [HttpPost] attribute");
        }

        [TestMethod]
        public void Delete_POST_HasValidateAntiForgeryTokenAttribute()
        {
            // Arrange
            var methodInfo = typeof(BlogPostController).GetMethod("Delete", new[] { typeof(int) });

            // Act
            var antiForgeryAttribute = methodInfo.GetCustomAttribute<ValidateAntiForgeryTokenAttribute>();

            // Assert
            antiForgeryAttribute.Should().NotBeNull("Delete action should have [ValidateAntiForgeryToken] attribute for security");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _controller?.Dispose();
        }
    }
}