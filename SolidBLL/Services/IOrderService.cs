using System.Collections.Generic;
using SolidDAL.Entities;

namespace SolidBLL.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order newOrder);
        IEnumerable<Order> GetAllOrdersByUser(User user);
        void UpdateOrder(Order order);
    }
}