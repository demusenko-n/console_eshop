using System.Collections.Generic;
using SolidBLL.Options;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions
{
    public class MainMenu : Menu
    {
        public override Role AccessRequired => Role.Guest;
        public override bool ForbidForHigherRoles => false;
        //public override Menu ParentMenu => null;
        public override string Name => "Main menu";

        public MainMenu(IEnumerable<IMainMenuOption> options, Session session, IPresenter presenter) : base(presenter, session, options)
        { }
    }
}