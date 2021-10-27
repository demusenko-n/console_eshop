using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public abstract class OpenOption : IOption
    {
        // public abstract IMenu ParentMenu { get; }
        public abstract string Name { get; }
        public Role AccessRequired => Role.Guest;
        public bool ForbidForHigherRoles => false;
        public abstract void Execute();
    }
}