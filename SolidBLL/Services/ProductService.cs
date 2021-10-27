using System;
using System.Collections.Generic;
using SolidDAL.Entities;
using SolidDAL.UoW;

namespace SolidBLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetProductsByPartOfName(string partOfName)
        {
            return _unitOfWork.ProductRepository
                .GetAllByFilter(product=>product.Name.Contains(partOfName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}