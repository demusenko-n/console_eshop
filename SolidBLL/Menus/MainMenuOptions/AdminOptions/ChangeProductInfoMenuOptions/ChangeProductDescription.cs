using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ChangeProductInfoMenuOptions
{
    public class ChangeProductDescription : AdminOption, IChangeProductInfoMenuOption
    {

        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        private readonly Session _session;

        public ChangeProductDescription(IProductService productService, IPresenter presenter, Session session)
        {
            _productService = productService;
            _presenter = presenter;
            _session = session;
        }

        public override string Name => "Manage product description";
        public override void Execute()
        {
            var targetProduct = (Product)_session["TargetProduct"];
            _presenter.WriteLine($"Current product description - {targetProduct.Description}");
            _presenter.WriteLine("New description: ");
            var newDescription = _presenter.Read();

            targetProduct.Description = newDescription;
            _productService.UpdateProduct(targetProduct);

            _presenter.WriteLine("Product description changed successfully!");
        }
    }
}