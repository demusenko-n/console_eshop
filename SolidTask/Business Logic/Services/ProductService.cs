using SolidTask.Repositories;

namespace SolidTask.Business_Logic.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        { 
            _productRepository = productRepository;
        }
    }
}