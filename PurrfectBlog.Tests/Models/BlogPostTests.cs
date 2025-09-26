using Microsoft.VisualStudio.TestTools.UnitTesting;
using PurrfectBlog.Models;
using FluentAssertions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace PurrfectBlog.Tests.Models
{
    [TestClass]
    public class BlogPostTests
    {
        [TestMethod]
        public void BlogPost_WithValidData_IsValid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Cat Story",
                Content = "This is a test content about cats",
                Category = "Funny",
                CreatedAt = DateTime.Now
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [TestMethod]
        public void BlogPost_WithNullCategory_IsValid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = "This is content",
                Category = null // Category is optional
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [TestMethod]
        public void BlogPost_WithEmptyTitle_IsInvalid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "", // Empty title
                Content = "This is content",
                Category = "Test"
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().NotBeEmpty();
            validationResults.Should().Contain(vr => vr.MemberNames.Contains("Title"));
        }

        [TestMethod]
        public void BlogPost_WithEmptyContent_IsInvalid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = "", // Empty content
                Category = "Test"
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().NotBeEmpty();
            validationResults.Should().Contain(vr => vr.MemberNames.Contains("Content"));
        }

        [TestMethod]
        public void BlogPost_WithTitleLength100_IsValid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = new string('A', 100),
                Content = "Test content",
                Category = "Test"
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [TestMethod]
        public void BlogPost_WithTitleLength101_IsInvalid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = new string('A', 101),
                Content = "Test content",
                Category = "Test"
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().NotBeEmpty();
            validationResults.Should().Contain(vr => vr.MemberNames.Contains("Title"));
        }

        [TestMethod]
        public void BlogPost_WithContentLength5000_IsValid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = new string('B', 5000),
                Category = "Test"
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [TestMethod]
        public void BlogPost_WithContentLength5001_IsInvalid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = new string('B', 5001),
                Category = "Test"
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().NotBeEmpty();
            validationResults.Should().Contain(vr => vr.MemberNames.Contains("Content"));
        }

        [TestMethod]
        public void BlogPost_WithCategoryLength50_IsValid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = "Test content",
                Category = new string('C', 50)
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().BeEmpty();
        }

        [TestMethod]
        public void BlogPost_WithCategoryLength51_IsInvalid()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = "Test content",
                Category = new string('C', 51)
            };

            // Act
            var validationResults = ValidateModel(blogPost);

            // Assert
            validationResults.Should().NotBeEmpty();
            validationResults.Should().Contain(vr => vr.MemberNames.Contains("Category"));
        }

        [TestMethod]
        public void BlogPost_CreatedAt_IsSetAutomatically()
        {
            // Arrange
            var beforeCreation = DateTime.Now.AddSeconds(-1);

            // Act
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = "Test content",
                Category = "Test"
            };
            var afterCreation = DateTime.Now.AddSeconds(1);

            // Assert
            blogPost.CreatedAt.Should().BeAfter(beforeCreation);
            blogPost.CreatedAt.Should().BeBefore(afterCreation);
        }

        [TestMethod]
        public void BlogPost_Id_DefaultsToZero()
        {
            // Arrange & Act
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = "Test content",
                Category = "Test"
            };

            // Assert
            blogPost.Id.Should().Be(0, "Id should default to 0 for new instances");
        }

        [TestMethod]
        public void BlogPost_Id_CanBeSet()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Test Title",
                Content = "Test content",
                Category = "Test"
            };

            // Act
            blogPost.Id = 123;

            // Assert
            blogPost.Id.Should().Be(123);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}