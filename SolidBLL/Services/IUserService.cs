using System.Collections.Generic;
using SolidDAL.Entities;

namespace SolidBLL.Services
{
    public interface IUserService
    {
        User GetUserByLoginPassword(string login, string password);
        User GetUserByLogin(string login);
        User GetUserByEmail(string email);
        void RegisterUser(User user);
        User Guest { get; }
        void UpdateUser(User user);
        IEnumerable<User> GetAllUsersByString(string strToFind);
    }
}