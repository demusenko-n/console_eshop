using Microsoft.Extensions.DependencyInjection;

namespace SolidBLL.Infrastructure
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            SolidDAL.Infrastructure.ServiceConfigurator.Configure(serviceCollection);
        }
    }
}