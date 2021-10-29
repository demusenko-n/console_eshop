using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions.ChangePersonalDataMenuOptions
{
    public class ChangeLoginOption : UserOption, IChangePersonalDataMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ChangeLoginOption(Session session, IUserService userService, IPresenter presenter)
        {
            _session = session;
            _userService = userService;
            _presenter = presenter;
        }

        public override string Name => "Change account login";

        public override void Execute()
        {
            var currentUser = (User) _session["User"];

            _presenter.WriteLine($"Your login - {currentUser.Login}");
            _presenter.WriteLine("Input new login: ");

            var newLogin = _presenter.Read();

            while (_userService.GetUserByLogin(newLogin) != null)
            {
                _presenter.WriteLine("This login is already in use.");
                _presenter.WriteLine("Input new login: ");
                newLogin = _presenter.Read();
            }

            currentUser.Login = newLogin;

            _userService.UpdateUser(currentUser);
            _presenter.WriteLine("Login successfully changed");
        }
    }
}