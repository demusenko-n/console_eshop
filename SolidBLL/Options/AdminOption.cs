using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public abstract class AdminOption : IOption
    {
        //public abstract Menu ParentMenu { get; }
        public abstract string Name { get; }
        public Role AccessRequired => Role.Admin;
        public bool ForbidForHigherRoles => false;
        public abstract void Execute();
    }
}