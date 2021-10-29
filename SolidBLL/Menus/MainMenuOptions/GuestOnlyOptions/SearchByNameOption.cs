using System.Linq;
using SolidBLL.Options;
using SolidBLL.Services;

namespace SolidBLL.Menus.MainMenuOptions.GuestOnlyOptions
{
    public class SearchByNameOption : GuestOnlyOption, IMainMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        public override string Name => "Search for products by name";
        public override void Execute()
        {
            _presenter.WriteLine("Enter the name or part of the name of the product: ");
            var inputStr = _presenter.Read();
            var searchResults = _productService.GetProductsByPartOfName(inputStr).ToArray();
            if (searchResults.Length > 0)
            {
                _presenter.WriteLine("Results:");
                foreach (var product in searchResults)
                {
                    _presenter.WriteLine($"\n{product.Name}\n{product.Description}\nPrice: {product.Price}");
                }
            }
            else
            {
                _presenter.WriteLine("Nothing found.");
            }

        }

        public SearchByNameOption(IProductService productService, IPresenter presenter)
        {
            _productService = productService;
            _presenter = presenter;
        }
    }
}