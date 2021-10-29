using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ChangeProductInfoMenuOptions
{
    public class ChangeProductName : AdminOption, IChangeProductInfoMenuOption
    {

        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        private readonly Session _session;

        public ChangeProductName(IProductService productService, IPresenter presenter, Session session)
        {
            _productService = productService;
            _presenter = presenter;
            _session = session;
        }

        public override string Name => "Manage product name";
        public override void Execute()
        {
            var targetProduct = (Product)_session["TargetProduct"];
            _presenter.WriteLine($"Current product name - {targetProduct.Name}");
            _presenter.WriteLine("New name: ");
            var newName = _presenter.Read();

            targetProduct.Name = newName;
            _productService.UpdateProduct(targetProduct);

            _presenter.WriteLine("Product name changed successfully!");
        }
    }
}