using SolidDAL.Domain.Entities;
using SolidDAL.Repositories;

namespace SolidDAL.UoW
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<User> UserRepository { get; }
    }
}