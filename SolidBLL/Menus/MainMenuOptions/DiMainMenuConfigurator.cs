using Microsoft.Extensions.DependencyInjection;
using SolidBLL.Menus.MainMenuOptions.AdminOptions;
using SolidBLL.Menus.MainMenuOptions.GuestOnlyOptions;
using SolidBLL.Menus.MainMenuOptions.UserOptions;

namespace SolidBLL.Menus.MainMenuOptions
{
    public static class DiMainMenuConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<MainMenu>();
            serviceCollection.AddTransient<IMainMenuOption, LoginOption>();
            serviceCollection.AddTransient<IMainMenuOption, RegisterOption>();
            serviceCollection.AddTransient<IMainMenuOption, SearchByNameOption>();
            serviceCollection.AddTransient<IMainMenuOption, LogoutOption>();
            serviceCollection.AddTransient<IMainMenuOption, AddToCartOption>();
            serviceCollection.AddTransient<IMainMenuOption, AddNewProductOption>();
            serviceCollection.AddTransient<IMainMenuOption, CartNewOrderOption>();
            serviceCollection.AddTransient<IMainMenuOption, ViewOrdersOption>();
        }
    }
}