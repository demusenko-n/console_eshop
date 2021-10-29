using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ManageUserDataMenuOptions
{
    public class ManageUserNameOption : AdminOption, IManageUserDataMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ManageUserNameOption(Session session, IUserService userService, IPresenter presenter)
        {
            _session = session;
            _userService = userService;
            _presenter = presenter;
        }

        public override string Name => "Manage account name";
        public override void Execute()
        {
            var targetUser = (User)_session["TargetUser"];

            _presenter.WriteLine($"Current name - {targetUser.Name}");
            _presenter.WriteLine("Input new name: ");

            var newName = _presenter.Read();


            targetUser.Name = newName;

            _userService.UpdateUser(targetUser);
            _presenter.WriteLine("Name successfully changed");
        }
    }
}