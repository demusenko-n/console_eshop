using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SolidTask.Domain.Entities;

namespace SolidTask.Repositories
{
    public class ProductCollectionRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductCollectionRepository()
        {
            _products = new List<Product>
            {
                new Product("prod1", "desc1", 1),
                new Product("prod2", "desc2", 2),
                new Product("prod3", "desc3", 3),
                new Product("prod4", "desc4", 4),
                new Product("prod5", "desc5", 5),
                new Product("prod6", "desc6", 6)
            };
        }
        public IEnumerable<Product> GetAllByFilter(Func<Product, bool> predicate)
        {
            return _products.Where(predicate);
        }
        public Product GetById(Guid id)
        {
            return _products.First(product => product.Id == id);
        }
        public void Create(Product item)
        {
            _products.Add(item);
        }
        public void Delete(Product item)
        {
            _products.Remove(item);
        }
        public void Update(Product item)
        {
            int index = _products.FindIndex(product => product.Id == item.Id);
            if (index == -1)
            {
                throw new InvalidOperationException("Item doesn't exist in collection");
            }
            _products[index] = item;    
        }
    }
}