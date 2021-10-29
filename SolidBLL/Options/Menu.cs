using System.Collections.Generic;
using System.Linq;
using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public abstract class Menu : IOption
    {
        private readonly List<IOption> _options;
        private readonly Session _session;
        private readonly IPresenter _presenter;

        public abstract string Name { get; }
        public abstract Role AccessRequired { get; }
        public abstract bool ForbidForHigherRoles { get; }
        protected virtual void PreExecuteActions() { }
        public void Execute()
        {
            PreExecuteActions();
            while (true)
            {
                var counter = 1;
                var currentUser = (User)_session["User"];

                var availableOptions = _options.Where(option => option.HasAccess(currentUser.Role)).ToArray();

                foreach (var option in availableOptions)
                {
                    _presenter.WriteLine($"{counter}. {option.Name}");
                    counter++;
                }
                _presenter.WriteLine("Press ESC to go back.");
                var userInput = _presenter.Read();
                int optionIndex;

                while (!int.TryParse(userInput, out optionIndex) || optionIndex < 1 || optionIndex >= counter)
                {
                    _presenter.WriteLine("Incorrect input!");
                    try
                    {
                        userInput = _presenter.Read();
                    }
                    catch (OptionInterruptedByUserException)
                    {
                        //exit the menu
                        return;  
                    }
                }

                optionIndex -= 1;
                _presenter.Clear();
                try
                {
                    availableOptions[optionIndex].Execute();
                    _presenter.WriteLine("Press enter to continue.");
                    _presenter.Pause();
                }
                catch (OptionInterruptedByUserException)
                {
                    //continue looping, exited from option
                }
               
                _presenter.Clear();
            }
        }
        protected Menu(IPresenter presenter, Session session, IEnumerable<IOption> options)
        {
            _session = session;
            _options = options.ToList();
            _presenter = presenter;
        }
    }
}