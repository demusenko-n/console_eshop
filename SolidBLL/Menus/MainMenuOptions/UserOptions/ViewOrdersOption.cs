using System.Linq;
using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions
{
    public class ViewOrdersOption : UserOption, IMainMenuOption
    {
        private readonly IOrderService _orderService;
        private readonly IPresenter _presenter;
        private readonly Session _session;
        public override string Name => "History of orders";
        public override void Execute()
        {

            var user = (User)_session["User"];

            var allOrdersByUser = _orderService.GetAllOrdersByUser(user).ToArray();

            if (allOrdersByUser.Length > 0)
            {
                _presenter.WriteLine("Your orders:");
                foreach (var order in allOrdersByUser)
                {
                    _presenter.WriteLine($"\nOrder status: {order.Status}\nProduct list:");
                    foreach (var (product, count) in order.Goods)
                    {
                        _presenter.WriteLine($"{product.Name} - {count}");
                    }
                    _presenter.WriteLine("");
                }
            }
            else
            {
                _presenter.WriteLine("Your orders history is empty.");
            }
        }

        public ViewOrdersOption(IOrderService orderService, Session session, IPresenter presenter)
        {
            _orderService = orderService;
            _session = session;
            _presenter = presenter;
        }
    }
}