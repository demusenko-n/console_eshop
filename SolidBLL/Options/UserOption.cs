using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public abstract class UserOption : IOption
    {
        //public abstract Menu ParentMenu { get; }
        public abstract string Name { get; }
        public Role AccessRequired => Role.User;
        public bool ForbidForHigherRoles => false;
        public abstract void Execute();
    }
}