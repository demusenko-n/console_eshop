using System;
using System.Collections.Generic;
using System.Linq;
using SolidBLL.Options;
using SolidDAL.Entities;

namespace SolidBLL.Menus.MainMenuOptions
{
    public class MainMenu : OpenOption, IMenu
    {
        //public override IMenu ParentMenu => null;
        public override string Name => "Main menu";

        public override void Execute()
        {
            var counter = 1;

            var currentUser = (User)_session["User"];

            foreach (var option in this.GetOptionsForRole(currentUser.Role))
            {
                _presenter.Write($"{counter}. {option.Name}\n");
                counter++;
            }
            
            var userInput = _presenter.Read();
            int optionIndex;

            while (!int.TryParse(userInput, out optionIndex) || optionIndex < 1 || optionIndex >= counter)
            {
                _presenter.Write("Incorrect input!\n");
                userInput = _presenter.Read();
            }

            Options[optionIndex].Execute();
        }

        public List<IOption> Options { get; }
        private readonly Session _session;
        private readonly IPresenter _presenter;

        public MainMenu(IEnumerable<IMainMenuOption> options, Session session, IPresenter presenter)
        {
            Options = options.Cast<IOption>().ToList();
            _session = session;
            _presenter = presenter;
        }
    }
}