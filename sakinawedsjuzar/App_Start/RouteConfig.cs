using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sakinawedsjuzar
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
            "AboutUsFooter",
            "Wedding/AboutUsFooter",
            new { controller = "Wedding", action = "AboutUsFooter" }
            );

            routes.MapRoute(
            "UploadImage",
            "Wedding/UploadImageForCommonInfo",
            new { controller = "Wedding", action = "UploadImageForCommonInfo" }
            );

            routes.MapRoute(
            "UploadImageForLoveStory",
            "Wedding/UploadImageForLoveStory",
            new { controller = "Wedding", action = "UploadImageForLoveStory" }
            );

            routes.MapRoute(
            "dataUrlToImage",
            "Wedding/dataUrlToImage",
            new { controller = "Wedding", action = "dataUrlToImage" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Wedding", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}