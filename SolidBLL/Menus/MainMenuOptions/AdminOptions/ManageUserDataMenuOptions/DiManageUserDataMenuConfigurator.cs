using Microsoft.Extensions.DependencyInjection;
using SolidBLL.Menus.MainMenuOptions.UserOptions.ChangePersonalDataMenuOptions;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ManageUserDataMenuOptions
{
    public static class DiManageUserDataMenuConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ManageUserDataMenu>();

            serviceCollection.AddTransient<IManageUserDataMenuOption, ManageUserEmailOption>();
            serviceCollection.AddTransient<IManageUserDataMenuOption, ManageUserNameOption>();
            serviceCollection.AddTransient<IManageUserDataMenuOption, ManageUserLoginOption>();
            serviceCollection.AddTransient<IManageUserDataMenuOption, ManageUserPasswordOption>();
        }
    }
}