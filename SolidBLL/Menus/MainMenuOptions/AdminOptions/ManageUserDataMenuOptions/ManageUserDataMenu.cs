using System.Collections.Generic;
using System.Linq;
using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.AdminOptions.ManageUserDataMenuOptions
{
    public class ManageUserDataMenu : Menu, IMainMenuOption
    {
        public override string Name => "View or change personal information of users";
        public override Role AccessRequired => Role.Admin;
        public override bool ForbidForHigherRoles => false;
        private readonly IPresenter _presenter;
        private readonly IUserService _userService;
        private readonly Session _session;

        public ManageUserDataMenu(IPresenter presenter, IUserService userService, Session session, IEnumerable<IManageUserDataMenuOption> options) 
            : base(presenter, session, options)
        {
            _presenter = presenter;
            _userService = userService;
            _session = session;
        }


        protected override void PreExecuteActions()
        {
            _presenter.WriteLine("Enter the string to search the user: ");
            var strToFind = _presenter.Read();
            var foundUsers = _userService.GetAllUsersByString(strToFind).ToArray();
            if (foundUsers.Length == 0)
            {
                _presenter.WriteLine("Nothing found.");
                return;
            }

            for (var i = 0; i < foundUsers.Length; i++)
            {
                var user = foundUsers[i];
                _presenter.WriteLine($"{i + 1}. Login: {user.Login}\nName: {user.Name}\nEmail: {user.Email}\nRole: {user.Role}\n");
            }

            var inputStr = _presenter.Read();
            int index;
            while (!int.TryParse(inputStr, out index) || index - 1 < 0 || index - 1 >= foundUsers.Length)
            {
                _presenter.WriteLine("Incorrect index");
                inputStr = _presenter.Read();
            }
            _presenter.Clear();

            var chosenUser = foundUsers[index - 1];
            _session["TargetUser"] = chosenUser;
        }
    }
}