using System.Collections.Generic;
using SolidDAL.Entities;

namespace SolidDAL.Context
{
    public class StoreContext
    {
        public List<Order> Orders { get; }

        public List<User> Users { get; }

        public List<Product> Products { get; }

        public StoreContext()
        {
            Orders = new List<Order>();
            Users = new List<User>
            {
                new("admin1", "admin", "Alex", "admin1@gmail.com"){Role=Role.Admin},
                new("admin2", "admin", "John", "admin2@gmail.com"){Role=Role.Admin},
                new("admin3", "admin", "Fred", "admin3@gmail.com"){Role=Role.Admin},
                new("user1", "user1", "Max", "user1@gmail.com"),
                new("user2", "user2", "Ivan", "user2@gmail.com"),
                new("user3", "user3", "James", "user3@gmail.com"),
                new("user4", "user4", "Oliver", "user4@gmail.com"),
                new("user5", "user5", "William", "user5@gmail.com"),
                new("user6", "user6", "Ethan", "user6@gmail.com")
            };
            Products = new List<Product>
            {
                new("prod1", "desc1", 1),
                new("prod2", "desc2", 2),
                new("prod3", "desc3", 3),
                new("prod4", "desc4", 4),
                new("prod5", "desc5", 5),
                new("prod6", "desc6", 6)
            };
        }
    }
}