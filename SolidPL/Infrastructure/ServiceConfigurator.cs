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
        }
    }
}