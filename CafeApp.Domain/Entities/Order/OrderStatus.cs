namespace CafeApp.Domain;

// trade-off - Look-up table need only If status values are managed by administrators  
//public class OrderStatus 
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
public enum OrderStatusEnum
{
    Draft = 0,
    Created = 1,
    Confirmed = 2,
    Priparing = 3,
    Ready = 4,
    Served = 5,
    Closed = 6,
    Cancelled = 7
}