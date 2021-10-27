using SolidDAL.Utility;

namespace SolidDAL.Entities
{
    public class OrderStatus : Enumeration
    {
        public static readonly OrderStatus New = new(1, "New");
        public static readonly OrderStatus Payed = new(2, "Payed");
        public static readonly OrderStatus Sent = new(3, "Sent");
        public static readonly OrderStatus Received = new(4, "Received");
        public static readonly OrderStatus Completed = new(5, "Completed");
        public static readonly OrderStatus CancelledByUser = new(6, "CancelledByUser");
        public static readonly OrderStatus CancelledByAdmin = new(7, "CancelledByAdmin");
        

        private OrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}