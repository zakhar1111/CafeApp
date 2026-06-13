namespace CafeApp.Domain;

public class OrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public enum OrderStatusEnum
{
    Created = 1,
    Confirmed = 2,
    Pending = 3,
    Ready = 4,
    Closed = 5
}