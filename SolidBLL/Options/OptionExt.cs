using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public static class OptionExt
    {
        public static bool HasAccess(this IOption option, Role role)
        {
            return option.ForbidForHigherRoles ? role.Equals(option.AccessRequired) : role >= option.AccessRequired;
        }
    }
}