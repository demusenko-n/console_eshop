using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ChangeProductInfoMenuOptions
{
    public class ChangeProductPrice : AdminOption, IChangeProductInfoMenuOption
    {

        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        private readonly Session _session;

        public ChangeProductPrice(IProductService productService, IPresenter presenter, Session session)
        {
            _productService = productService;
            _presenter = presenter;
            _session = session;
        }

        public override string Name => "Manage product price";
        public override void Execute()
        {
            var targetProduct = (Product)_session["TargetProduct"];
            _presenter.WriteLine($"Current product price - {targetProduct.Price}");
            _presenter.WriteLine("New price: ");
            var newPriceStr = _presenter.Read();
            decimal newPrice;
            while (!decimal.TryParse(newPriceStr, out newPrice))
            {
                _presenter.WriteLine("Invalid price!");
                _presenter.WriteLine("New price: ");
                newPriceStr = _presenter.Read();
            }

            targetProduct.Price = newPrice;
            _productService.UpdateProduct(targetProduct);

            _presenter.WriteLine("Product price changed successfully!");
        }
    }
}