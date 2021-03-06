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

        public Product GetProductById(Guid id)
        {
            return _unitOfWork.ProductRepository
                .GetById(id);
        }

        public void CreateProduct(Product newProduct)
        {
            _unitOfWork.ProductRepository.Create(newProduct);
        }

        public IEnumerable<Product> GetAllProductsByString(string strToFind)
        {
            return _unitOfWork.ProductRepository.GetAllByFilter(product =>
                product.Name.Contains(strToFind, StringComparison.CurrentCultureIgnoreCase));
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
        }
    }
}