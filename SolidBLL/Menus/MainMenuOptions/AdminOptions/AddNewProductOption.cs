using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions
{
    public class AddNewProductOption : AdminOption, IMainMenuOption
    {
        public override string Name => "Add new product";

        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        public AddNewProductOption(IPresenter presenter, IProductService productService)
        {
            _presenter = presenter;
            _productService = productService;
        }
        public override void Execute()
        {
            

            _presenter.WriteLine("Input product name:");
            var productName = _presenter.Read();

            _presenter.WriteLine("Input product description:");
            var productDescription = _presenter.Read();

            _presenter.WriteLine("Input product price:");
            var productPriceStr = _presenter.Read();

            decimal productPrice;
            while (!decimal.TryParse(productPriceStr, out productPrice))
            {
                _presenter.WriteLine("Invalid price!");
                productPriceStr = _presenter.Read();
            }

            Product newProduct = new(productName, productDescription, productPrice);
            _productService.CreateProduct(newProduct);

            _presenter.WriteLine("Product added successfully!");
        }
    }
}