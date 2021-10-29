using System;
using useless.OperationAccessTypes;

namespace useless
{
    //Помечаем эту операцию, что она доступна и для гостя, и для юзера, и для админа
    public class OperationShowAllProducts : IMenuOperation, IAdminOperation, IUserOperation, IGuestOperation
    {
        public string Description => "Show all products";
        public void Execute()
        {
            Console.WriteLine("Product list: ");
            foreach (Product product in _productService.GetAllProducts())
            {
                Console.WriteLine($"{product.Name}");
                Console.WriteLine($"{product.Description}");
                Console.WriteLine($"Price:{product.Price}");
            }
        }

        private readonly IProductService _productService;
        public OperationShowAllProducts(IProductService productService)
        {
            _productService = productService;
        }
    }
}