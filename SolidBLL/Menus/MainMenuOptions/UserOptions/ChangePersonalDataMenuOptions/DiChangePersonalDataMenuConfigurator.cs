using Microsoft.Extensions.DependencyInjection;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions.ChangePersonalDataMenuOptions
{
    public static class DiChangePersonalDataMenuConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ChangePersonalDataMenu>();
            serviceCollection.AddTransient<IChangePersonalDataMenuOption, ChangeNameOption>();
            serviceCollection.AddTransient<IChangePersonalDataMenuOption, ChangeEmailOption>();
            serviceCollection.AddTransient<IChangePersonalDataMenuOption, ChangeLoginOption>();
            serviceCollection.AddTransient<IChangePersonalDataMenuOption, ChangePasswordOption>();
        }
    }
}