using Autofac;
using DatabaseRepository.Interfaces;
using DatabaseRepository.Repositories;
using DatabaseRepository;
using Giveaways.Services.Interfaces;
using Giveaways.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();

            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<RegistrationService>().As<IRegistrationService>();
            builder.RegisterType<LoginDetailsRepository>().As<ILoginDetailsRepository>();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ILoginService>();
            }
        }
    }
}
