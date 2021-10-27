using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.GuestOnlyOptions
{

    public class RegisterOption : GuestOnlyOption, IMainMenuOption
    {
        private readonly IPresenter _presenter;
        private readonly Session _session;
        private readonly IUserService _userService;
        public RegisterOption(IPresenter presenter, Session session, IUserService userService)
        {

            _presenter = presenter;
            _session = session;
            _userService = userService;
        }

        // public override IMenu ParentMenu { get; }

        public override string Name => "Register";

        public override void Execute()
        {
            _presenter.Write("Input login:\n");

            var login = _presenter.Read();
            var user = _userService.GetUserByLogin(login);

            while (user != null)
            {
                _presenter.Write("This login is already in use.\n");
                _presenter.Write("Input login:\n");
                login = _presenter.Read();
                user = _userService.GetUserByLogin(login);
            }

            _presenter.Write("Input email:\n");

            var email = _presenter.Read();
            user = _userService.GetUserByEmail(email);

            while (user != null)
            {
                _presenter.Write("This email is already in use.\n");
                _presenter.Write("Input email:\n");
                email = _presenter.Read();
                user = _userService.GetUserByEmail(email);
            }

            _presenter.Write("Input name:\n");
            var name = _presenter.Read();

            _presenter.Write("Input password:\n");
            var password = _presenter.Read();

            user = new User(login, password, name, email);
            
            _userService.RegisterUser(user);
            _session["User"] = user;
            _presenter.Write("Registration successful!\n");
        }

    }
}