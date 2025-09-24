using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PurrfectBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Custom route for individual post /Posts/{id}
            routes.MapRoute(
                name: "PostDetails",
                url: "Posts/{id}",
                defaults: new { controller = "BlogPost", action = "Details" },
                constraints: new { id = @"\d+" }
            );

            // Custom route for posts list /Posts
            routes.MapRoute(
                name: "PostsList",
                url: "Posts",
                defaults: new { controller = "BlogPost", action = "Index" }
            );

            // Custom route for /CreatePost
            routes.MapRoute(
                name: "CreatePost",
                url: "CreatePost",
                defaults: new { controller = "BlogPost", action = "CreatePost" }
            );

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
