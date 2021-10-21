namespace SolidTask.Domain.Roles
{
    public class AdminRole : IRole
    {
        string IRole.RoleName => "Administrator";
    }
}