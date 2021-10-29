using System.Collections.Generic;
using System.Linq;
using useless.OperationAccessTypes;

namespace useless
{
    public class RegisteredUserMenu : Menu
    {
        public RegisteredUserMenu(IEnumerable<IUserOperation> operations)
        {
            _operations = operations.Cast<IMenuOperation>().ToList();
        }
    }
}