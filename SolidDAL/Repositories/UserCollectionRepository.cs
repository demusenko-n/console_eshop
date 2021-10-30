using System;
using System.Collections.Generic;
using System.Linq;
using SolidDAL.Context;
using SolidDAL.Entities;

namespace SolidDAL.Repositories
{
    public class UserCollectionRepository : IRepository<User>
    {
        private readonly IStoreContext _context;

        public UserCollectionRepository(IStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllByFilter(Func<User, bool> predicate)
        {
            return _context.Users.Where(predicate);
        }

        public User GetById(Guid id)
        {
            return _context.Users.First(user => user.Id == id);
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
        }

        public void Delete(User item)
        {
            _context.Users.Remove(item);
        }

        public void Update(User item)
        {
            var index = _context.Users.FindIndex(user => user.Equals(item));
            if (index == -1)
            {
                throw new InvalidOperationException("Item doesn't exist in collection");
            }
            _context.Users[index] = item;
        }
    }
}