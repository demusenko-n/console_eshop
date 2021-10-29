using Microsoft.Extensions.DependencyInjection;
using SolidBLL.Menus.MainMenuOptions.AdminOptions;
using SolidBLL.Menus.MainMenuOptions.AdminOptions.ChangeProductInfoMenuOptions;
using SolidBLL.Menus.MainMenuOptions.AdminOptions.ManageUserDataMenuOptions;
using SolidBLL.Menus.MainMenuOptions.GuestOnlyOptions;
using SolidBLL.Menus.MainMenuOptions.UserOptions;
using SolidBLL.Menus.MainMenuOptions.UserOptions.ChangePersonalDataMenuOptions;

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
            serviceCollection.AddTransient<IMainMenuOption, ChangePersonalDataMenu>();
            serviceCollection.AddTransient<IMainMenuOption, ManageUserDataMenu>();
            serviceCollection.AddTransient<IMainMenuOption, ChangeProductInfoMenu>();

            DiChangePersonalDataMenuConfigurator.Configure(serviceCollection);
            DiManageUserDataMenuConfigurator.Configure(serviceCollection);
            DiChangeProductInfoMenuConfigurator.Configure(serviceCollection);
        }
    }
}