using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Moq;
using System.Web;

namespace PurrfectBlog.Tests.Routing
{
    [TestClass]
    public class RouteTests
    {
        private RouteCollection _routes;

        [TestInitialize]
        public void Setup()
        {
            _routes = new RouteCollection();
            RouteConfig.RegisterRoutes(_routes);
        }

        [TestMethod]
        public void EditPost_WithValidId_MapsToCorrectController()
        {
            // Arrange
            var url = "~/EditPost/123";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            routeData.Should().NotBeNull("EditPost route should be found");
            routeData.Values["controller"].Should().Be("BlogPost");
            routeData.Values["action"].Should().Be("EditPost");
            routeData.Values["id"].Should().Be("123");
        }

        [TestMethod]
        public void EditPost_WithNonNumericId_DoesNotMatchEditPostRoute()
        {
            // Arrange
            var url = "~/EditPost/abc";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            // Should match default route, not EditPost route
            routeData.Should().NotBeNull("Some route should match");
            routeData.Values["controller"].Should().Be("EditPost");
            routeData.Values["action"].Should().Be("abc");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [TestMethod]
        public void EditPost_WithNoId_DoesNotMatchEditPostRoute()
        {
            // Arrange
            var url = "~/EditPost";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            // Should match default route, not EditPost route
            routeData.Should().NotBeNull("Some route should match");
            routeData.Values["controller"].Should().Be("EditPost");
            routeData.Values["action"].Should().Be("Index");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [TestMethod]
        public void PostDetails_WithValidId_MapsToCorrectController()
        {
            // Arrange
            var url = "~/Posts/456";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            routeData.Should().NotBeNull("Posts/{id} route should be found");
            routeData.Values["controller"].Should().Be("BlogPost");
            routeData.Values["action"].Should().Be("Details");
            routeData.Values["id"].Should().Be("456");
        }

        [TestMethod]
        public void PostDetails_WithNonNumericId_DoesNotMatchPostDetailsRoute()
        {
            // Arrange
            var url = "~/Posts/xyz";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            // Should match default route, not PostDetails route
            routeData.Should().NotBeNull("Some route should match");
            routeData.Values["controller"].Should().Be("Posts");
            routeData.Values["action"].Should().Be("xyz");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [TestMethod]
        public void CreatePost_MapsToCorrectController()
        {
            // Arrange
            var url = "~/CreatePost";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            routeData.Should().NotBeNull("CreatePost route should be found");
            routeData.Values["controller"].Should().Be("BlogPost");
            routeData.Values["action"].Should().Be("CreatePost");
        }

        [TestMethod]
        public void DefaultRoute_RootUrl_MapsToHomeIndex()
        {
            // Arrange
            var url = "~/";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            routeData.Should().NotBeNull("Default route should be found");
            routeData.Values["controller"].Should().Be("Home");
            routeData.Values["action"].Should().Be("Index");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [TestMethod]
        public void DefaultRoute_HomeOnly_MapsToHomeIndex()
        {
            // Arrange
            var url = "~/Home";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            routeData.Should().NotBeNull("Default route should be found");
            routeData.Values["controller"].Should().Be("Home");
            routeData.Values["action"].Should().Be("Index");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [TestMethod]
        public void HomeContact_MapsCorrectly()
        {
            // Arrange
            var url = "~/Home/Contact";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            routeData.Should().NotBeNull("Home/Contact route should be found");
            routeData.Values["controller"].Should().Be("Home");
            routeData.Values["action"].Should().Be("Contact");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [TestMethod]
        public void ErrorController_NotFound_MapsCorrectly()
        {
            // Arrange
            var url = "~/Error/NotFound";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            routeData.Should().NotBeNull("Error/NotFound route should be found");
            routeData.Values["controller"].Should().Be("Error");
            routeData.Values["action"].Should().Be("NotFound");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [TestMethod]
        public void BlogPostIndex_MapsCorrectly()
        {
            // Arrange
            var url = "~/BlogPost/Index";

            // Act
            var routeData = _routes.GetRouteData(CreateHttpContext(url));

            // Assert
            routeData.Should().NotBeNull("BlogPost/Index route should be found");
            routeData.Values["controller"].Should().Be("BlogPost");
            routeData.Values["action"].Should().Be("Index");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        private HttpContextBase CreateHttpContext(string url)
        {
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(url);
            mockRequest.Setup(x => x.PathInfo).Returns(string.Empty);

            var mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(x => x.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(x => x.Request).Returns(mockRequest.Object);
            mockContext.Setup(x => x.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }
    }
}