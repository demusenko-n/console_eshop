namespace SolidDAL.Entities
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
       
        public User(string login, string password, string name, string email)
        {
            Login = login;
            Password = password;
            Name = name;
            Email = email;
            Role = Role.User;
        }
    }
}