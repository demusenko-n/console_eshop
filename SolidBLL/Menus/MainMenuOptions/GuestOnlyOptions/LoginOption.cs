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

       // public override Menu ParentMenu { get; }

       public override string Name => "Login";

       public override void Execute()
        {
            _presenter.WriteLine("Input login:");
            var login = _presenter.Read();
            _presenter.WriteLine("Input password:");
            var password = _presenter.Read();
            var user = _userService.GetUserByLoginPassword(login, password);
            if (user == null)
            {
                _presenter.WriteLine("Invalid login or password!");
            }
            else
            {
                _session["User"] = user;
                _presenter.WriteLine("Successful login");
            }
        }
    }
}