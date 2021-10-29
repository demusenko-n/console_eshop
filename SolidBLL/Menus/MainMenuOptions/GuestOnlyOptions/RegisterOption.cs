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

        // public override Menu ParentMenu { get; }

        public override string Name => "Register";

        public override void Execute()
        {
            _presenter.WriteLine("Input login:");

            var login = _presenter.Read();
            var user = _userService.GetUserByLogin(login);

            while (user != null)
            {
                _presenter.WriteLine("This login is already in use.");
                _presenter.WriteLine("Input login:");
                login = _presenter.Read();
                user = _userService.GetUserByLogin(login);
            }

            _presenter.WriteLine("Input email:");

            var email = _presenter.Read();
            user = _userService.GetUserByEmail(email);

            while (user != null)
            {
                _presenter.WriteLine("This email is already in use.");
                _presenter.WriteLine("Input email:");
                email = _presenter.Read();
                user = _userService.GetUserByEmail(email);
            }

            _presenter.WriteLine("Input name:");
            var name = _presenter.Read();

            _presenter.WriteLine("Input password:");
            var password = _presenter.Read();

            user = new User(login, password, name, email);
            
            _userService.RegisterUser(user);
            _session["User"] = user;
            _presenter.WriteLine("Registration successful!");
        }

    }
}