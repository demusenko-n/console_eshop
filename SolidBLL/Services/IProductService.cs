using System;
using System.Collections.Generic;
using SolidDAL.Entities;

namespace SolidBLL.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsByPartOfName(string partOfName);
        Product GetProductById(Guid id);
        void CreateProduct(Product newProduct);
    }
}