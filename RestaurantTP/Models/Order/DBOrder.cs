namespace RestaurantTP.Models.Order
{
    public class DBOrder
    {
        public int ID { get; set; }
        public EOrderStatus Status { get; set; }
    }

    public enum EOrderStatus
    {
        inProgress,
        Done
    }
}
