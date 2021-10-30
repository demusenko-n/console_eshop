using System;
using System.Collections.Generic;
using System.Linq;
using SolidDAL.Context;
using SolidDAL.Entities;

namespace SolidDAL.Repositories
{
    public class OrderCollectionRepository : IRepository<Order>
    {
        private readonly IStoreContext _context;

        public OrderCollectionRepository(IStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllByFilter(Func<Order, bool> predicate)
        {
            return _context.Orders.Where(predicate);
        }

        public Order GetById(Guid id)
        {
            return _context.Orders.First(order => order.Id == id);
        }

        public void Create(Order item)
        {
            _context.Orders.Add(item);
        }

        public void Delete(Order item)
        {
            _context.Orders.Remove(item);
        }

        public void Update(Order item)
        {
            var index = _context.Orders.FindIndex(order => order.Equals(item));
            if (index == -1)
            {
                throw new InvalidOperationException("Item doesn't exist in collection");
            }
            _context.Orders[index] = item;
        }
    }
}