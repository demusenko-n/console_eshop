using SolidTask.Presentation.Controllers;

namespace SolidTask.App
{
    public class Application
    {
        public static ApplicationContext Context { get; }
        public static Controller Controller { get; set; }

        static Application()
        {
            Context = new ApplicationContext();
        }

        public Application()
        {
        }

        public void Run()
        {

        }
    }
}