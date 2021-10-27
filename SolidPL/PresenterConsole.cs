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
        public void Write(string text) => Console.Write(text);
        public void Clear() => ConsoleUtility.CustomClear();
        public void Pause() => Console.ReadKey();
    }
}