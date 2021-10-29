using SolidBLL.Options;
using SolidBLL.Services;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions
{
    public class LogoutOption : UserOption, IMainMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly Session _session;
        private readonly IUserService _userService;
        public LogoutOption(IPresenter presenter, Session session, IUserService userService)
        {
            _presenter = presenter;
            _session = session;
            _userService = userService;
        }
        public override string Name => "Logout";
        public override void Execute()
        {
            _session["User"] = _userService.Guest;
            _presenter.WriteLine("Logout successful!");
        }
    }
}