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
        private const string ConfirmationWordString = "received";
        private const string CancellationWordString = "cancel";

        public override void Execute()
        {
            var user = (User)_session["User"];

            var allOrdersByUser = _orderService.GetAllOrdersByUser(user).ToArray();

            if (allOrdersByUser.Length == 0)
            {
                _presenter.WriteLine("Your orders history is empty.");
                return;
            }

            _presenter.WriteLine("Your orders:");
            for (var i = 0; i < allOrdersByUser.Length; i++)
            {
                var order = allOrdersByUser[i];
                _presenter.WriteLine($"\n{i + 1} -> Order status: {order.Status}\nProduct list:");
                foreach (var (product, count) in order.Goods)
                {
                    _presenter.WriteLine($"{product.Name} - {count}");
                }

                _presenter.WriteLine("");
            }
            _presenter.WriteLine("Input order number:");
            var orderIndexStr = _presenter.Read();
            int orderIndex;
            while (!int.TryParse(orderIndexStr, out orderIndex) || orderIndex-1 < 0 || orderIndex-1 >= allOrdersByUser.Length)
            {
                _presenter.WriteLine("Incorrect order number!");
                orderIndexStr = _presenter.Read();
            }
            
            var chosenOrder = allOrdersByUser[orderIndex - 1];
            _presenter.Clear();
            if (chosenOrder.Status == OrderStatus.CancelledByUser 
                || chosenOrder.Status == OrderStatus.CancelledByAdmin 
                || chosenOrder.Status == OrderStatus.Completed 
                || chosenOrder.Status == OrderStatus.Received)
            {
                _presenter.WriteLine("You cannot change order status.");
                return;
            }

            _presenter.WriteLine($"Write '{CancellationWordString}' to cancel order");
            _presenter.WriteLine($"Write '{ConfirmationWordString}' to mark order as received");

            var inputStr = _presenter.Read();
            if (inputStr == CancellationWordString)
            {
                chosenOrder.Status = OrderStatus.CancelledByUser;
                _orderService.UpdateOrder(chosenOrder);
                _presenter.WriteLine("Order status updated");
            }

            if (inputStr == ConfirmationWordString)
            {
                chosenOrder.Status = OrderStatus.Received;
                _orderService.UpdateOrder(chosenOrder);
                _presenter.WriteLine("Order status updated");
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