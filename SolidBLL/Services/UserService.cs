using System;
using System.Collections.Generic;
using System.Linq;
using SolidDAL.Entities;
using SolidDAL.UoW;

namespace SolidBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUserByLoginPassword(string login, string password)
        {
            return _unitOfWork.UserRepository
                .GetAllByFilter(user => user.Login == login && user.Password == password).FirstOrDefault();
        }

        public User GetUserByLogin(string login)
        {
            return _unitOfWork.UserRepository
                .GetAllByFilter(user => user.Login == login).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository
                .GetAllByFilter(user => user.Email == email).FirstOrDefault();
        }

        public void RegisterUser(User user)
        {
            _unitOfWork.UserRepository.Create(user);
        }

        public User Guest { get; } = new("Guest", "", "Guest", "<Authorize first>") { Role = Role.Guest };
        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
        }

        public IEnumerable<User> GetAllUsersByString(string strToFind)
        {
            return _unitOfWork.UserRepository
                .GetAllByFilter(user => user.Name.Contains(strToFind, StringComparison.CurrentCultureIgnoreCase) 
                                        || user.Email.Contains(strToFind, StringComparison.CurrentCultureIgnoreCase) 
                                        || user.Login.Contains(strToFind, StringComparison.CurrentCultureIgnoreCase));
        }

       
    }
}