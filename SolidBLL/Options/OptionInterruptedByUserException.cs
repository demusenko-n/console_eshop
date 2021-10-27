using System;

namespace SolidBLL.Options
{
    public class OptionInterruptedByUserException : Exception
    {
        public OptionInterruptedByUserException()
        {
        }

        public OptionInterruptedByUserException(string message)
            : base(message)
        {
        }

        public OptionInterruptedByUserException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}