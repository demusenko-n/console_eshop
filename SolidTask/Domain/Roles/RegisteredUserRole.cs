namespace SolidTask.Domain.Roles
{
    public class RegisteredUserRole : IRole
    {
        string IRole.RoleName => "User";
    }
}