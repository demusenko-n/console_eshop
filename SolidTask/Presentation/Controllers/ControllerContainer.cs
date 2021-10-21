using System.Collections.Generic;
using System.ComponentModel.Design;
using SolidTask.Presentation.Controllers.ControllerFactories;

namespace SolidTask.Presentation.Controllers
{
    public class ControllerContainer
    {
        private readonly Dictionary<string, IControllerFactory> _factories;
        public Controller DefaultController => Get("Main");
        public ControllerContainer()
        {
            _factories = new Dictionary<string, IControllerFactory>
            {
                {"Main", new MainControllerFactory()}
            };
        }

        public void Register(string key, IControllerFactory factory)
        {
            _factories.Add(key, factory);
        }

        public Controller Get(string key)
        {
            return _factories[key].Create();
        }

    }
}