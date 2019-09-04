using Autofac;
using Autofac.Integration.WebApi;
using Farm.Dal;
using Farm.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Farm.Api
{
    public static class Autofac
    {
        public static void Register()
        {
            // Base set-up
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            //                          .Where(t => t.GetCustomAttribute<InjectableAttribute>() != null)
            //                          .AsImplementedInterfaces()
            //                          .InstancePerRequest();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            // Build the Container
            var container = builder.Build();

            //Create the Dependency Resolver
            var resolver = new AutofacWebApiDependencyResolver(container);

            //Configuring WebApi with Dependency Resolver
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static void SetUpRegistration(ContainerBuilder builder)
        {
            //builder.RegisterType<FarmRepository>()
            //    .As<IRepository<FarmDal>>()
            //    .WithParameter("context", new FarmDataContext());

            builder.RegisterType<FarmUnitOfWork>().As<IUnitOfWork>();
        }
    }
}