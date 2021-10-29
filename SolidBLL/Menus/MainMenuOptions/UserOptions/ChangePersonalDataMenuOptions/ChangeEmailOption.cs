using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions.ChangePersonalDataMenuOptions
{
    public class ChangeEmailOption : UserOption, IChangePersonalDataMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ChangeEmailOption(Session session, IUserService userService, IPresenter presenter)
        {
            _session = session;
            _userService = userService;
            _presenter = presenter;
        }

        public override string Name => "Change account email";
        public override void Execute()
        {
            var currentUser = (User)_session["User"];

            _presenter.WriteLine($"Your email - {currentUser.Email}");
            _presenter.WriteLine("Input new email: ");

            var newEmail = _presenter.Read();

            while (_userService.GetUserByEmail(newEmail) != null)
            {
                _presenter.WriteLine("This email is already in use.");
                _presenter.WriteLine("Input new email: ");
                newEmail = _presenter.Read();
            }

            currentUser.Email = newEmail;

            _userService.UpdateUser(currentUser);
            _presenter.WriteLine("Email successfully changed");
        }
    }
}