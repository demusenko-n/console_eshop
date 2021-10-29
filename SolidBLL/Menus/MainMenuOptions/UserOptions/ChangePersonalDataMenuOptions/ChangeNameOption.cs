using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions.ChangePersonalDataMenuOptions
{
    public class ChangeNameOption : UserOption, IChangePersonalDataMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ChangeNameOption(Session session, IUserService userService, IPresenter presenter)
        {
            _session = session;
            _userService = userService;
            _presenter = presenter;
        }

        public override string Name => "Change account name";
        public override void Execute()
        {
            var currentUser = (User) _session["User"];

            _presenter.WriteLine($"Your name - {currentUser.Name}");
            _presenter.WriteLine("Input new name: ");

            var newName = _presenter.Read();
            currentUser.Name = newName;

            _userService.UpdateUser(currentUser);
            _presenter.WriteLine("Name successfully changed");
        }
    }
}