using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public interface IOption
    {
        //Menu ParentMenu { get; }
        string Name { get; }
        Role AccessRequired { get; }
        bool ForbidForHigherRoles { get; }
        void Execute();
    }
}