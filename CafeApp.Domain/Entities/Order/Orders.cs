namespace CafeApp.Domain;

public class Orders
{
    public int Id { get; set; }
    

    public int CreatedByStaffId { get; set; } //FK
    public int TableSessionId { get; set; } //FK


    public DateTime CreatedTime { get; set; }
    


    private readonly List<OrderItem> _items = new ();
    public IReadOnlyCollection<OrderItem> OrderItems => _items.AsReadOnly();


    public OrderStatusEnum OrderStatus { get; set; }
    public OrderTypeEnum OrderType { get; set; }
}
