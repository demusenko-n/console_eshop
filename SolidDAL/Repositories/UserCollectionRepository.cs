using System;
using System.Collections.Generic;
using System.Linq;
using SolidDAL.Context;
using SolidDAL.Domain.Entities;

namespace SolidDAL.Repositories
{
    public class UserCollectionRepository : IRepository<User>
    {
        private readonly StoreContext _context;

        public UserCollectionRepository(StoreContext context)
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
            int index = _context.Users.FindIndex(user => user.Equals(item));
            if (index == -1)
            {
                throw new InvalidOperationException("Item doesn't exist in collection");
            }
            _context.Users[index] = item;
        }
    }
}