using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ManageUserDataMenuOptions
{
    public class ManageUserLoginOption : AdminOption, IManageUserDataMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ManageUserLoginOption(Session session, IUserService userService, IPresenter presenter)
        {
            _session = session;
            _userService = userService;
            _presenter = presenter;
        }

        public override string Name => "Manage account login";
        public override void Execute()
        {
            var targetUser = (User)_session["TargetUser"];

            _presenter.WriteLine($"Current login - {targetUser.Login}");
            _presenter.WriteLine("Input new login: ");

            var newLogin = _presenter.Read();

            while (_userService.GetUserByLogin(newLogin) != null)
            {
                _presenter.WriteLine("This login is already in use.");
                _presenter.WriteLine("Input new login: ");
                newLogin = _presenter.Read();
            }

            targetUser.Login = newLogin;

            _userService.UpdateUser(targetUser);
            _presenter.WriteLine("Login successfully changed");
        }
    }
}