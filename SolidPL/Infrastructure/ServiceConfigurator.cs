using Microsoft.Extensions.DependencyInjection;
using SolidBLL;

namespace SolidPL.Infrastructure
{
    public static class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            SolidBLL.Infrastructure.ServiceConfigurator.Configure(serviceCollection);

            serviceCollection.AddTransient<IPresenter, PresenterConsole>();
        }
    }
}