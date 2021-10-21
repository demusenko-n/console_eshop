using SolidTask.Domain.Entities;
using SolidTask.Domain.Roles;
using SolidTask.Repositories;

namespace SolidTask.Business_Logic.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Guest { get; } = new("Guest", "", "Guest", "<Authorize first>", new GuestRole());
    }
}