using System;
using Microsoft.Extensions.DependencyInjection;
using SolidBLL.Menus.MainMenuOptions;
using SolidBLL.Options;
using SolidPL.Infrastructure;

namespace SolidPL.App
{
    public class Application
    {
        public Application()
        { }

        public void Run()
        {
            ServiceCollection services = new();
            ServiceConfigurator.ConfigureServices(services);
            using var provider = services.BuildServiceProvider();

            var menu = provider.GetRequiredService<MainMenu>();
            try
            {
                menu.Execute();
            }
            catch (OptionInterruptedByUserException)
            {
                Console.WriteLine("See you next time!");
            }
            
        }
    }
}