using System.Collections.Generic;

namespace SolidDAL.Entities
{
    public class Order : Entity
    {
        public User Client { get; set; }
        public Dictionary<Product, int> Goods { get; }
        public OrderStatus Status { get; set; }
        public Order(User client)
        {
            Goods = new Dictionary<Product, int>();
            Status = OrderStatus.New;
            Client = client;
        }
    }
}
