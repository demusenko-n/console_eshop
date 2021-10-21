using System;
using System.Collections.Generic;
using System.Linq;
using SolidTask.Domain.Entities;
using SolidTask.Domain.Roles;

namespace SolidTask.Repositories
{
    public class UserCollectionRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserCollectionRepository()
        {
            _users = new List<User>
            {
                new User("admin1", "admin", "Alex", "admin1@gmail.com", new AdminRole()),
                new User("admin2", "admin", "John", "admin2@gmail.com", new AdminRole()),
                new User("admin3", "admin", "Fred", "admin3@gmail.com", new AdminRole()),
                new User("user1", "user1", "Max", "user1@gmail.com", new RegisteredUserRole()),
                new User("user2", "user2", "Ivan", "user2@gmail.com", new RegisteredUserRole()),
                new User("user3", "user3", "James", "user3@gmail.com", new RegisteredUserRole()),
                new User("user4", "user4", "Oliver", "user4@gmail.com", new RegisteredUserRole()),
                new User("user5", "user5", "William", "user5@gmail.com", new RegisteredUserRole()),
                new User("user6", "user6", "Ethan", "user6@gmail.com", new RegisteredUserRole())

            };
        }
        public IEnumerable<User> GetAllByFilter(Func<User, bool> predicate)
        {
            return _users.Where(predicate);
        }

        public User GetById(Guid id)
        {
            return _users.First(user => user.Id == id);
        }

        public void Create(User item)
        {
            _users.Add(item);
        }

        public void Delete(User item)
        {
            _users.Remove(item);
        }

        public void Update(User item)
        {
            int index = _users.FindIndex(user => user.Equals(item));
            if (index == -1)
            {
                throw new InvalidOperationException("Item doesn't exist in collection");
            }
            _users[index] = item;
        }
    }
}