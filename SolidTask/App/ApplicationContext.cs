using System;
using System.Linq;
using System.Reflection;
using Autofac;
using SolidTask.Business_Logic.Services;
using SolidTask.Repositories;

namespace SolidTask.App
{
    public class ApplicationContext
    {
        private readonly IContainer _container;
        public Session Session { get; }

        private void RegisterControllers(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            Type[] types = currentAssembly.GetTypes()
                .Where(type => type.Namespace == "SolidTask.Presentation.Controllers")
                .Where(type => !type.IsAbstract && !type.IsInterface && type.IsClass
                               && type.Name.EndsWith("Controller")).ToArray();

            foreach (var type in types)
            {
                Console.WriteLine($"Registered controller {type.Name}");
            }

            builder.RegisterTypes(types).AsSelf();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().AsSelf().SingleInstance();
            builder.RegisterType<ProductService>().AsSelf().SingleInstance();
            builder.RegisterType<OrderService>().AsSelf().SingleInstance();
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ProductCollectionRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<OrderCollectionRepository>().As<IOrderRepository>().SingleInstance();
            builder.RegisterType<UserCollectionRepository>().As<IUserRepository>().SingleInstance();
        }

        public ApplicationContext()
        {
            var builder = new ContainerBuilder();

            RegisterRepositories(builder);
            RegisterServices(builder);
            RegisterControllers(builder);

            _container = builder.Build();

            Session = new Session
            {
                CurrentUser = _container.Resolve<UserService>().Guest
            };
        }
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }
    }
}