using SolidBLL.Options;
using SolidBLL.Services;

namespace SolidBLL.Menus.MainMenuOptions.GuestOnlyOptions
{
    public class LoginOption : GuestOnlyOption, IMainMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly Session _session;
        private readonly IUserService _userService;
        public LoginOption(IPresenter presenter, Session session, IUserService userService)
        {
            
            _presenter = presenter;
            _session = session;
            _userService = userService;
        }

       // public override IMenu ParentMenu { get; }

       public override string Name => "Login";

       public override void Execute()
        {
            _presenter.Write("Input login:\n");
            var login = _presenter.Read();
            _presenter.Write("Input password:\n");
            var password = _presenter.Read();
            var user = _userService.GetUserByLoginPassword(login, password);
            if (user == null)
            {
                _presenter.Write("Invalid login or password!\n");
            }
            else
            {
                _session["User"] = user;
                _presenter.Write("Successful login\n");
            }
        }
    }
}