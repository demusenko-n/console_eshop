using System.Collections.Generic;
using System.Linq;
using useless.OperationAccessTypes;

namespace useless
{
    public class AdminMenu : Menu
    {
        public AdminMenu(IEnumerable<IAdminOperation> operations)//сюда попадут все зарегистрированые IAdminOperation
        {
            this._operations = operations.Cast<IMenuOperation>().ToList();
        }
    }
}