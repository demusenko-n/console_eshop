namespace SolidTask.Domain.Roles
{
    public class GuestRole : IRole
    {
        string IRole.RoleName => "Guest";
    }
}