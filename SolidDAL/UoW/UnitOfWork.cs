using System;
using SolidDAL.Context;
using SolidDAL.Entities;
using SolidDAL.Repositories;

namespace SolidDAL.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {


        private readonly IStoreContext _storeContext;

        private IRepository<Product> _productRepository;
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;

        public UnitOfWork(IStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IRepository<Product> ProductRepository => _productRepository ??= new ProductCollectionRepository(_storeContext);

        public IRepository<Order> OrderRepository => _orderRepository ??= new OrderCollectionRepository(_storeContext);

        public IRepository<User> UserRepository => _userRepository ??= new UserCollectionRepository(_storeContext);

        public void Dispose() {}
    }
}