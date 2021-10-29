using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions
{
    public class CartNewOrderOption : UserOption, IMainMenuOption
    {   
        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly Session _session;
        private const string NewOrderWord = "order";
        private const string ClearCartWord = "clear";

        public CartNewOrderOption(IProductService productService, IPresenter presenter, Session session, IOrderService orderService)
        {
            _productService = productService;
            _presenter = presenter;
            _session = session;
            _orderService = orderService;
        }

        public override string Name => "Cart management";
        public override void Execute()
        {
            var cart = (Cart) _session["Cart"];

            var totalPrice = 0m;
            _presenter.WriteLine("Cart content:");
            foreach ( var (id, count) in cart.ProductsCount)
            {
                var product = _productService.GetProductById(id);
                _presenter.WriteLine($"{product.Name} -- {count}:");
                totalPrice += product.Price * count;
            }
            _presenter.WriteLine($"Total price: {totalPrice}");

            if (cart.ProductsCount.Count == 0) return;

            _presenter.WriteLine($"Write '{ClearCartWord}' to clear the cart\nWrite '{NewOrderWord}' to confirm new order");

            var inputStr = _presenter.Read();
            if (inputStr == ClearCartWord)
            {
                cart.Clear();
            }

            if (inputStr == NewOrderWord)
            {
                CreateOrder();
            }
        }
        private void CreateOrder()
        {
            var cart = (Cart)_session["Cart"];
            var user = (User) _session["User"];

            var newOrder = new Order(user);
            foreach (var (id, count) in cart.ProductsCount)
            {
                newOrder.Goods.Add(_productService.GetProductById(id), count);
            }

            _orderService.CreateOrder(newOrder);
            cart.Clear();

            _presenter.WriteLine("Order created!");
        }
    }
}