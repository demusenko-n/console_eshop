using Microsoft.Extensions.DependencyInjection;
using SolidBLL.Services;

namespace SolidBLL.Infrastructure
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            SolidDAL.Infrastructure.ServiceConfigurator.Configure(serviceCollection);
            serviceCollection.AddTransient<IOrderService, OrderService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}