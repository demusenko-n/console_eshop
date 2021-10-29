using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ManageUserDataMenuOptions
{
    public class ManageUserEmailOption : AdminOption, IManageUserDataMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ManageUserEmailOption(Session session, IUserService userService, IPresenter presenter)
        {
            _session = session;
            _userService = userService;
            _presenter = presenter;
        }

        public override string Name => "Manage account email";
        public override void Execute()
        {
            var targetUser = (User)_session["TargetUser"];

            _presenter.WriteLine($"Current email - {targetUser.Email}");
            _presenter.WriteLine("Input new email: ");

            var newEmail = _presenter.Read();

            while (_userService.GetUserByEmail(newEmail) != null)
            {
                _presenter.WriteLine("This email is already in use.");
                _presenter.WriteLine("Input new email: ");
                newEmail = _presenter.Read();
            }

            targetUser.Email = newEmail;

            _userService.UpdateUser(targetUser);
            _presenter.WriteLine("Email successfully changed");
        }
    }
}