using System;
using System.Collections.Generic;
using System.Linq;
using SolidDAL.Context;
using SolidDAL.Domain.Entities;

namespace SolidDAL.Repositories
{
    public class ProductCollectionRepository : IRepository<Product>
    {
        private readonly StoreContext _context;

        public ProductCollectionRepository(StoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllByFilter(Func<Product, bool> predicate)
        {
            return _context.Products.Where(predicate);
        }
        public Product GetById(Guid id)
        {
            return _context.Products.First(product => product.Id == id);
        }
        public void Create(Product item)
        {
            _context.Products.Add(item);
        }
        public void Delete(Product item)
        {
            _context.Products.Remove(item);
        }
        public void Update(Product item)
        {
            int index = _context.Products.FindIndex(product => product.Id == item.Id);
            if (index == -1)
            {
                throw new InvalidOperationException("Item doesn't exist in collection");
            }
            _context.Products[index] = item;    
        }
    }
}