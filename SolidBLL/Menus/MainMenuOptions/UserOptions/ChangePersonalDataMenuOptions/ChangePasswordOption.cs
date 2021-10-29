using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions.ChangePersonalDataMenuOptions
{
    public class ChangePasswordOption : UserOption, IChangePersonalDataMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ChangePasswordOption(Session session, IUserService userService, IPresenter presenter)
        {
            _session = session;
            _userService = userService;
            _presenter = presenter;
        }

        public override string Name => "Change account password";
        public override void Execute()
        {
            var currentUser = (User)_session["User"];

            _presenter.WriteLine($"Your password - {currentUser.Password}");
            _presenter.WriteLine("Input new password: ");

            var newPassword = _presenter.Read();
            currentUser.Password = newPassword;

            _userService.UpdateUser(currentUser);
            _presenter.WriteLine("Password successfully changed");
        }
    }
}