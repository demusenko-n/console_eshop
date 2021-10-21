using System;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using SolidTask.App;
using SolidTask.Presentation.Controllers;

namespace SolidTask
{
    internal static class Program
    {
        private static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;
            
            Application.Run();
            
            var controllerType = Type.GetType("SolidTask.Presentation.Controllers.MainPageController");

            object controller = Application.Context.Resolve(controllerType);

            controller.GetType().GetMethod("Index").Invoke(controller, null);
        }
    }
}
