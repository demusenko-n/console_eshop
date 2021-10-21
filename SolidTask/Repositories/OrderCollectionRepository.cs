using System;
using System.Collections.Generic;
using System.Linq;
using SolidTask.Domain.Entities;

namespace SolidTask.Repositories
{
    public class OrderCollectionRepository : IOrderRepository
    {
        private readonly List<Order> _orders;

        public OrderCollectionRepository()
        {
            _orders = new List<Order>();
        }

        public IEnumerable<Order> GetAllByFilter(Func<Order, bool> predicate)
        {
            return _orders.Where(predicate);
        }

        public Order GetById(Guid id)
        {
            return _orders.First(order => order.Id == id);
        }

        public void Create(Order item)
        {
            _orders.Add(item);
        }

        public void Delete(Order item)
        {
            _orders.Remove(item);
        }

        public void Update(Order item)
        {
            int index = _orders.FindIndex(order => order.Equals(item));
            if (index == -1)
            {
                throw new InvalidOperationException("Item doesn't exist in collection");
            }
            _orders[index] = item;
        }
    }
}