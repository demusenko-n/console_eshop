using System;
using SolidTask.Presentation.Controllers;

namespace SolidTask.App
{
    public static class Application
    {
        public static ApplicationContext Context { get; }
        //public static Controller Controller { get; set; }

        public static void SwitchToAction(string controllerName, string actionName, params object[] args)
        {
            if (!controllerName.EndsWith("Controller")) controllerName += "Controller";
            
            var controllerType = Type.GetType($"SolidTask.Presentation.Controllers.{controllerName}");
            if (controllerType == null) throw new Exception($"Unknown controllerName {controllerName}");
            
            var actionMethod = controllerType.GetMethod(actionName);
            if (actionMethod == null) throw new Exception($"Couldn't find {actionName} in {controllerName}");

            var controller = Context.Resolve(controllerType);

            actionMethod.Invoke(controller, args);
        }

        static Application()
        {
            Context = new ApplicationContext();
        }
        

        public static void Run()
        {

        }
    }
}