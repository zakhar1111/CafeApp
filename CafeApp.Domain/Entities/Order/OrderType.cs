namespace CafeApp.Domain;

public class OrderType
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public enum OrderTypeEnum
{
    DineIn = 1,
    TakeAway = 2,
    Delivery = 3
}