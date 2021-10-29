using Microsoft.Extensions.DependencyInjection;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ChangeProductInfoMenuOptions
{
    public static class DiChangeProductInfoMenuConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ChangeProductInfoMenu>();

            serviceCollection.AddTransient<IChangeProductInfoMenuOption, ChangeProductName>();
            serviceCollection.AddTransient<IChangeProductInfoMenuOption, ChangeProductDescription>();
            serviceCollection.AddTransient<IChangeProductInfoMenuOption, ChangeProductPrice>();
        }
    }
}