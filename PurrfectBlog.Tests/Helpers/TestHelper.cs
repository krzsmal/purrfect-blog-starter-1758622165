using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using Moq;

namespace PurrfectBlog.Tests.Helpers
{
    public static class TestHelper
    {
        public static void SetupControllerContext(Controller controller)
        {
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var context = new Mock<HttpContextBase>();

            response.SetupProperty(r => r.StatusCode);

            context.Setup(x => x.Request).Returns(request.Object);
            context.Setup(x => x.Response).Returns(response.Object);

            var routeData = new RouteData();
            controller.ControllerContext = new ControllerContext(context.Object, routeData, controller);
        }

        public static int GetResponseStatusCode(Controller controller)
        {
            return controller.Response.StatusCode;
        }
    }
}