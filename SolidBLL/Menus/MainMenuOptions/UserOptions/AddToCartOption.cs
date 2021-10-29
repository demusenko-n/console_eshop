using System.Linq;
using SolidBLL.Options;
using SolidBLL.Services;

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
            _presenter.WriteLine("Enter the name or part of the name of the product: ");
            var inputStr = _presenter.Read();
            var searchResults = _productService.GetProductsByPartOfName(inputStr).ToArray();
            if (searchResults.Length <= 0)
            {
                _presenter.WriteLine("Nothing found.");
                return;
            }

            _presenter.WriteLine("Results:");
            for (var i = 0; i < searchResults.Length; i++)
            {
                var product = searchResults[i];
                _presenter.WriteLine($"{i + 1}. \n{product.Name}\n{product.Description}\nPrice: {product.Price}");
            }

            while (true)
            {
                _presenter.WriteLine("Input product number to add in cart (press esc to cancel): ");
                inputStr = _presenter.Read();
                int indexInput;
                while (!int.TryParse(inputStr, out indexInput) || indexInput - 1 >= searchResults.Length || indexInput - 1 < 0)
                {
                    _presenter.WriteLine("Invalid input!");
                    inputStr = _presenter.Read();
                }

                var selectedProduct = searchResults[indexInput - 1];

                var cart = (Cart)_session["Cart"];
                cart.Add(selectedProduct.Id);
                _presenter.WriteLine($"Product {selectedProduct.Name} added!");
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