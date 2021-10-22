using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SolidPL.Infrastructure;

namespace SolidPL
{
    internal static class Program
    {
        private static void Main()
        {
            ServiceCollection services = new();
            ServiceConfigurator.ConfigureServices(services);
            using var provider = services.BuildServiceProvider();
        }
    }
}
