using System.Collections.Generic;
using SolidBLL.Options;
using SolidBLL.Services;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions.UserOptions.ChangePersonalDataMenuOptions
{
    public class ChangePersonalDataMenu : Menu, IMainMenuOption
    {
        public ChangePersonalDataMenu(IEnumerable<IChangePersonalDataMenuOption> options, Session session, IPresenter presenter) 
            : base(presenter, session, options)
        { }

        public override string Name => "Change personal information";
        public override Role AccessRequired => Role.User;
        public override bool ForbidForHigherRoles => false;
    }
}