using SolidDAL.Utility;

namespace SolidDAL.Entities
{
    public class Role : Enumeration
    {
        public static readonly Role Guest = new(1, "Guest");
        public static readonly Role User = new(2, "User");
        public static readonly Role Admin = new(3, "Admin");

        private Role(int id, string name) : base(id, name)
        {
        }
    }
}