using Autofac;
using SolidTask.Business_Logic.Services;
using SolidTask.Presentation.Controllers;
using SolidTask.Repositories;

namespace SolidTask.App
{
    public class ApplicationContext
    {
        private readonly IContainer _container;
        public Session Session { get; }
        public ApplicationContext()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProductCollectionRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<OrderCollectionRepository>().As<IOrderRepository>().SingleInstance();
            builder.RegisterType<UserCollectionRepository>().As<IUserRepository>().SingleInstance();

            builder.RegisterType<UserService>().AsSelf().SingleInstance();
            builder.RegisterType<ProductService>().AsSelf().SingleInstance();
            builder.RegisterType<OrderService>().AsSelf().SingleInstance();

            builder.RegisterType<ControllerContainer>().AsSelf().SingleInstance();
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
    }
}