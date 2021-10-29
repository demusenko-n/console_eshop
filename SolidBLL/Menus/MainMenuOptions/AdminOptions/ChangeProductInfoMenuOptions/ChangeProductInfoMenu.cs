using System.Collections.Generic;
using System.Linq;
using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ChangeProductInfoMenuOptions
{
    public class ChangeProductInfoMenu : Menu, IMainMenuOption
    {
        public override string Name => "Manage product information";
        public override Role AccessRequired => Role.Admin;
        public override bool ForbidForHigherRoles => false;
        private readonly IPresenter _presenter;
        private readonly IProductService _productService;
        private readonly Session _session;

        public ChangeProductInfoMenu(IPresenter presenter, IProductService productService, Session session, IEnumerable<IChangeProductInfoMenuOption> options)
            : base(presenter, session, options)
        {
            _presenter = presenter;
            _productService = productService;
            _session = session;
        }


        protected override void PreExecuteActions()
        {
            _presenter.WriteLine("Enter the string to search the product: ");
            var strToFind = _presenter.Read();
            var foundProducts = _productService.GetAllProductsByString(strToFind).ToArray();
            if (foundProducts.Length == 0)
            {
                _presenter.WriteLine("Nothing found.");
                return;
            }

            for (var i = 0; i < foundProducts.Length; i++)
            {
                var product = foundProducts[i];//
                _presenter.WriteLine($"{i + 1}. {product.Name}\n{product.Description}\nPrice: {product.Price}\n");
            }

            var inputStr = _presenter.Read();
            int index;
            while (!int.TryParse(inputStr, out index) || index - 1 < 0 || index - 1 >= foundProducts.Length)
            {
                _presenter.WriteLine("Incorrect index");
                inputStr = _presenter.Read();
            }
            _presenter.Clear();

            var chosenProduct = foundProducts[index - 1];
            _session["TargetProduct"] = chosenProduct;
        }
    }
}