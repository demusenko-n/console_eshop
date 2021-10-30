using Microsoft.Extensions.DependencyInjection;
using SolidDAL.Context;
using SolidDAL.Entities;
using SolidDAL.Repositories;
using SolidDAL.UoW;

namespace SolidDAL.Infrastructure
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStoreContext, StoreContext>();
            serviceCollection.AddTransient<IRepository<Product>, ProductCollectionRepository>();
            serviceCollection.AddTransient<IRepository<User>, UserCollectionRepository>();
            serviceCollection.AddTransient<IRepository<Order>, OrderCollectionRepository>();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}