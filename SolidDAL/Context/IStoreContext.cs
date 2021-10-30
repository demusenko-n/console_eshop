using System.Collections.Generic;
using SolidDAL.Entities;

namespace SolidDAL.Context
{
    public interface IStoreContext
    {
        List<Order> Orders { get; }

        List<User> Users { get; }

        List<Product> Products { get; }
    }
}