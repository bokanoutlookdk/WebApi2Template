using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApi2Template.Utils.ExceptionHandling;

namespace WebApi2Template
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;

            config.Services.Replace(typeof(IExceptionLogger), new EventLogExceptionLogger());

            config.MapHttpAttributeRoutes();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
