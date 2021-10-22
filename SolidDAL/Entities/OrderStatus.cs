namespace SolidDAL.Domain.Entities
{
    public enum OrderStatus
    {
        New = 1,
        Payed = 2,
        Sent = 3,
        Received = 4,
        Completed = 5,
        CancelledByUser = 6,
        CancelledByAdmin = 7,
    }
}