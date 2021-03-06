using SolidDAL.Entities;

namespace SolidBLL.Options
{
    public interface IOption
    {
        string Name { get; }
        Role AccessRequired { get; }
        bool ForbidForHigherRoles { get; }  
        void Execute();
    }
}