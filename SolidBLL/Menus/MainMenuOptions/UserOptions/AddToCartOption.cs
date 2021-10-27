using System.Linq;
using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions
{

    public class AddToCartOption : UserOption, IMainMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        private readonly Session _session;
        public override string Name => "Add products to cart";
        public override void Execute()
        {
            _presenter.Write("Enter the name or part of the name of the product: ");
            var inputStr = _presenter.Read();
            var searchResults = _productService.GetProductsByPartOfName(inputStr).ToArray();
            if (searchResults.Length <= 0)
            {
                _presenter.Write("Nothing found.\n");
                return;
            }

            _presenter.Write("Results:\n");
            for (var i = 0; i < searchResults.Length; i++)
            {
                var product = searchResults[i];
                _presenter.Write($"{i + 1}. \n{product.Name}\n{product.Description}\nPrice: {product.Price}\n");
            }

            while (true)
            {
                _presenter.Write("Input product number to add in cart (press esc to cancel): ");
                inputStr = _presenter.Read();
                int indexInput;
                while (!int.TryParse(inputStr, out indexInput) || indexInput - 1 >= searchResults.Length || indexInput - 1 < 0)
                {
                    _presenter.Write("Invalid input!\n");
                    inputStr = _presenter.Read();
                }

                Product selectedProduct = searchResults[indexInput - 1];

                Cart cart = (Cart)_session["Cart"];
                cart.Add(selectedProduct.Id);
                _presenter.Write($"Product {selectedProduct.Name} added!\n");
            }
        }

        public AddToCartOption(IProductService productService, IPresenter presenter, Session session)
        {
            _productService = productService;
            _presenter = presenter;
            _session = session;
        }

    }
}