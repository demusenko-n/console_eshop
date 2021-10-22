using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SolidDAL.Context;
using SolidDAL.Repositories;

namespace SolidPL.Infrastructure
{
    public static class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            SolidBLL.Infrastructure.ServiceConfigurator.Configure(serviceCollection);
            ConfigureControllers(serviceCollection);
        }

        private static void ConfigureControllers(IServiceCollection serviceCollection)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            Type[] types = currentAssembly.GetTypes()
                .Where(type => type.Namespace == $"{currentAssembly.GetName().Name}.Controllers")
                .Where(type => !type.IsAbstract && type.IsClass && type.Name.EndsWith("Controller")).ToArray();

            foreach (var controllerType in types)
            {
                serviceCollection.AddTransient(controllerType);
                //Console.WriteLine($"Added controller {controllerType.Name} as transient");
            }
        }
    }
}