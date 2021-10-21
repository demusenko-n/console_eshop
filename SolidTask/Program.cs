using System;
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

            Application application = new();
            application.Run();

        }
    }
}
