using FakeMoodle.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DIL;
using System.Web.Http.Cors;

namespace FakeMoodle
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = new UnityResolver(UnityConfig.Container);
            config.EnableCors(new EnableCorsAttribute("*","*","*"));
            AutoMapperConfig.Initialize();

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
