using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ManageUserDataMenuOptions
{
    public class ManageUserPasswordOption : AdminOption, IManageUserDataMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ManageUserPasswordOption(Session session, IUserService userService, IPresenter presenter)
        {
            _session = session;
            _userService = userService;
            _presenter = presenter;
        }

        public override string Name => "Manage account password";
        public override void Execute()
        {
            var targetUser = (User)_session["TargetUser"];

            _presenter.WriteLine($"Current password - {targetUser.Password}");
            _presenter.WriteLine("Input new password: ");

            var newPassword = _presenter.Read();


            targetUser.Password = newPassword;

            _userService.UpdateUser(targetUser);
            _presenter.WriteLine("Password successfully changed");
        }
    }
}