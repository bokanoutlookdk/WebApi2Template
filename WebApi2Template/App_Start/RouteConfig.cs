using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApi2Template
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }

        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{action}/{id}",
        //        defaults: new { action = "Index", id = UrlParameter.Optional }
        //    );

        //    // Set Swagger as default start page

        //    routes.MapHttpRoute(
        //        name: "swagger_root",
        //        routeTemplate: "",
        //        defaults: null,
        //        constraints: null,
        //        handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));


        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //   );
        //}
    }
}
