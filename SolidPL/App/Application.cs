//using System;
//using System.Reflection;
//using System.Text;
//using Microsoft.Extensions.DependencyInjection;
//using SolidPL.Utility;

//namespace SolidPL.App
//{
//    public class Application
//    {
//        private Controller _currentController;
//        public void SwitchToAction(string controllerName, string actionName, params object[] args)
//        {
//            if (!controllerName.EndsWith("Controller")) controllerName += "Controller";

//            var controllerType = Type.GetType($"{Assembly.GetExecutingAssembly().GetName().Name}.Controllers.{controllerName}");
//            if (controllerType == null) throw new Exception($"Unknown controllerName {controllerName}");

//            var actionMethod = controllerType.GetMethod(actionName);
//            if (actionMethod == null) throw new Exception($"Couldn't find {actionName} in {controllerName}");

//            _currentController = (Controller) ApplicationContext.Provider.GetRequiredService(controllerType);

//            actionMethod.Invoke(_currentController, args);
//        }

//        public void SwitchToDefault() => SwitchToAction("MainPage", "Index");

//        public void DisplayView(string pageName, string viewName, params object[] args)
//        {
//            if (!pageName.EndsWith("Controller")) pageName = pageName[..^"Controller".Length];

//            var viewType = Type.GetType($"{Assembly.GetExecutingAssembly().GetName().Name}.Views.{pageName}.{viewName}");
//            if (viewType == null) throw new Exception($"Unknown viewType {pageName}.{viewName}");

//            var viewMethod = viewType.GetMethod("Display");
//            if (viewMethod == null) throw new Exception($"Couldn't find Display method in {pageName}.{viewName}");
            
//            viewMethod.Invoke(ApplicationContext.Provider.GetRequiredService(viewType), args);
//        }

//        private static Application _instance;
//        public static Application Instance => _instance ??= new Application();

//        private Application()
//        {
//            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;
//            Console.BackgroundColor = ConsoleColor.Black;
//            Console.ForegroundColor = ConsoleColor.White;
//        }

//        public void Run()
//        {
//            SwitchToDefault();

//            while (true)
//            {
//                if (ConsoleUtility.CancelableReadLine(out string val))
//                {
//                    _currentController.Input(val);
//                }
//                else
//                {
//                    SwitchToDefault();
//                }
//            }
//        }
//    }
//}