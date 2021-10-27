using SolidBLL.Options;
using SolidBLL.Services;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions
{
    public class CartNewOrderOption : UserOption, IMainMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        private readonly Session _session;

        public CartNewOrderOption(IProductService productService, IPresenter presenter, Session session)
        {
            _productService = productService;
            _presenter = presenter;
            _session = session;
        }

        public override string Name => "Cart";
        public override void Execute()
        {
            Cart cart = (Cart) _session["Cart"];

            _presenter.Write("Cart content: ");
        }
    }
}