using System.Collections.Generic;
using System.Linq;
using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public static class OptionExt
    {
        public static bool HasAccess(this IOption option, Role role)
        {
            return option.ForbidForHigherRoles ? role.Equals(option.AccessRequired) : role >= option.AccessRequired;
        }

        public static IEnumerable<IOption> GetOptionsForRole(this IMenu menu, Role userRole)
        {
            return menu.Options.Where(option => option.HasAccess(userRole));
        }
    }
}