using SolidTask.Utility;

namespace SolidTask.Domain
{

    public sealed class OrderStatus : Enumeration
    {
        public static OrderStatus New = new(1, nameof(New));
        public static OrderStatus Payed = new(2, nameof(Payed));
        public static OrderStatus Sent = new(3, nameof(Sent));
        public static OrderStatus Received = new(4, nameof(Received));
        public static OrderStatus Completed = new(5, nameof(Completed));
        public static OrderStatus CancelledByUser = new(6, nameof(CancelledByUser));
        public static OrderStatus CancelledByAdmin = new(7, nameof(CancelledByAdmin));

        private OrderStatus(int id, string name) : base(id, name) { }
    }
}