using System.Collections;
using System.Linq;
using useless.OperationAccessTypes;

namespace useless
{
    public class GuestMenu : Menu
    {
        public GuestMenu(IEnumerable<IGuestOperation> operations)
        {
            _operations = operations.Cast<IMenuOperation>().ToList();
        }
    }
}