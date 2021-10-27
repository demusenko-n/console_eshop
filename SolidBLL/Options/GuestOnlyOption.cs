using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public abstract class GuestOnlyOption : IOption
    {
        //public abstract IMenu ParentMenu { get; }
        public abstract string Name { get; }
        public Role AccessRequired => Role.Guest;
        public bool ForbidForHigherRoles => true;
        public abstract void Execute();
    }
}