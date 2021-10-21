namespace SolidTask.Presentation.Controllers.ControllerFactories
{
    public class MainControllerFactory : IControllerFactory
    {
        public Controller Create()
        {
            return new MainPageController();
        }
    }
}