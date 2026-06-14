namespace CafeApp.Domain;

// trade-off - Look-up table need only If status values are managed by administrators
//public class OrderType
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
public enum OrderTypeEnum
{
    DineIn = 1,
    TakeAway = 2,
    Delivery = 3
}