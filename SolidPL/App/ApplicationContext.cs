namespace SolidPL.App
{
    public class ApplicationContext
    {
        //private readonly IContainer _container;
        //public Session Session { get; }

        //private void RegisterControllers(ContainerBuilder builder)
        //{
        //    var currentAssembly = Assembly.GetExecutingAssembly();

        //    Type[] types = currentAssembly.GetTypes()
        //        .Where(type => type.Namespace == "SolidTask.Presentation.Controllers")
        //        .Where(type => !type.IsAbstract && type.IsClass && type.Name.EndsWith("Controller")).ToArray();

        //    builder.RegisterTypes(types).AsSelf();
        //}

        //private void RegisterServices(ContainerBuilder builder)
        //{
        //    builder.RegisterType<UserService>().AsSelf().SingleInstance();
        //    builder.RegisterType<ProductService>().AsSelf().SingleInstance();
        //    builder.RegisterType<OrderService>().AsSelf().SingleInstance();
        //}

        //private void RegisterRepositories(ContainerBuilder builder)
        //{
        //    builder.RegisterType<ProductCollectionRepository>().As<IProductRepository>().SingleInstance();
        //    builder.RegisterType<OrderCollectionRepository>().As<IOrderRepository>().SingleInstance();
        //    builder.RegisterType<UserCollectionRepository>().As<IUserRepository>().SingleInstance();
            
        //}

        //public ApplicationContext()
        //{
        //    //IoC

        //    var builder = new ContainerBuilder();

        //    RegisterRepositories(builder);
        //    RegisterServices(builder);
        //    RegisterControllers(builder);

        //    _container = builder.Build();

        //    Session = new Session
        //    {
        //        CurrentUser = _container.Resolve<UserService>().Guest
        //    };

        //    _container.Resolve(typeof(IOrderRepository));
        //}
        //public T Resolve<T>()
        //{
        //    return _container.Resolve<T>();
        //}

        //public object Resolve(Type serviceType)
        //{
        //    return _container.Resolve(serviceType);
        //}
    }
}