using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace sakinawedsjuzar
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            


                config.Routes.MapHttpRoute(
                "GetCollectionEntityImages",
                "api/WeddingAPI/GetCollectionEntityImages",
                new { controller = "WeddingAPI", action = "GetCollectionEntityImages" }

            );

            config.Routes.MapHttpRoute(
                "PostDeleteLoveStory",
                "api/WeddingAPI/PostDeleteLoveStory",
                new { controller = "WeddingAPI", action = "PostDeleteLoveStory" }

            );
            config.Routes.MapHttpRoute(
                "PostCommonInfo",
                "api/WeddingAPI/PostCommonInfo",
                new { controller = "WeddingAPI", action = "PostCommonInfo" }

            );

            config.Routes.MapHttpRoute(
                "PostNewEvent",
                "api/WeddingAPI/PostNewEvent",
                new { controller = "WeddingAPI", action = "PostNewEvent" }

            );

            config.Routes.MapHttpRoute(
                "PostDeleteImage",
                "api/WeddingAPI/PostDeleteImage",
                new { controller = "WeddingAPI", action = "PostDeleteImage" }

            );

            config.Routes.MapHttpRoute(
                "PostNewLoveStory",
                "api/WeddingAPI/PostNewLoveStory",
                new { controller = "WeddingAPI", action = "PostNewLoveStory" }

            );

            config.Routes.MapHttpRoute(
                "GetCommonInfo",
                "api/WeddingAPI/GetCommonInfo",
                new { controller = "WeddingAPI", action = "GetCommonInfo" }

            );

            config.Routes.MapHttpRoute(
                "PostFileUpload",
                "api/WeddingAPI/PostFileUpload",
                new { controller = "WeddingAPI", action = "PostFileUpload" }

            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
