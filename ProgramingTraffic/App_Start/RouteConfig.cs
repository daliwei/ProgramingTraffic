using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProgramingTraffic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Category",
            //    "{controller}/{action}/{category}",
            //    new { controller = "Blog", action = "Posts", category = "" }
            //);

            routes.MapRoute(
                "Home",
                "{controller}/{action}/{id}",
                new { controller = "BlogEF", action = "Posts", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BlogEF", action = "Posts", id = UrlParameter.Optional }
            );
        }
    }
}
