using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public interface IOption
    {
        //IMenu ParentMenu { get; }
        string Name { get; }
        Role AccessRequired { get; }
        bool ForbidForHigherRoles { get; }
        void Execute();
    }
}