using System;
using SolidBLL;
using SolidBLL.Options;
using SolidPL.Utility;

namespace SolidPL
{
    public class PresenterConsole : IPresenter
    {
        public string Read()
        {
            if (!ConsoleUtility.CancelableReadLine(out var result)) throw new OptionInterruptedByUserException();
            return result;
        }
        public void WriteLine(string text) => Console.WriteLine(text);
        public void Clear() => /*ConsoleUtility.CustomClear();*/Console.Clear();
        public void Pause() => Console.ReadKey();
    }
}