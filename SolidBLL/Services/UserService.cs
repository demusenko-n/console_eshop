using SolidDAL.Domain.Entities;
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
        public User Guest { get; } = new("Guest", "", "Guest", "<Authorize first>") { Role = Role.Guest };
    }
}