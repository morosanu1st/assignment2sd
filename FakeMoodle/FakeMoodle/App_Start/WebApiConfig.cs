using FakeMoodle.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DIL;
using System.Web.Http.Cors;
using FakeMoodle.Authorization;
using System.Web.Mvc;
using BussinessContracts;

namespace FakeMoodle
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = new UnityResolver(UnityConfig.Container);
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            var v=config.DependencyResolver.GetService(typeof(IAuthService));
            config.Filters.Add(new AuthenticationFilter((IAuthService)config.DependencyResolver.GetService(typeof(IAuthService))));
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
