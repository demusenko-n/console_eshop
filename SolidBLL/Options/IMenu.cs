using System.Collections.Generic;

namespace SolidBLL.Options
{
    public interface IMenu : IOption
    {
        List<IOption> Options { get; }
    }
}