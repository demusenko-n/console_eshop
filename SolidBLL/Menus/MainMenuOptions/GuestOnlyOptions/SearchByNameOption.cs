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
            _presenter.Write("Enter the name or part of the name of the product: ");
            var inputStr = _presenter.Read();
            var searchResults = _productService.GetProductsByPartOfName(inputStr).ToArray();
            if (searchResults.Length > 0)
            {
                _presenter.Write("Results:\n");
                foreach (var product in searchResults)
                {
                    _presenter.Write($"\n{product.Name}\n{product.Description}\nPrice: {product.Price}\n");
                }
            }
            else
            {
                _presenter.Write("Nothing found.\n");
            }

        }

        public SearchByNameOption(IProductService productService, IPresenter presenter)
        {
            _productService = productService;
            _presenter = presenter;
        }
    }
}