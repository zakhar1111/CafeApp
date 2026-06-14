namespace CafeApp.Domain;

public class OrderItem
{
    public int Id { get; set; }


    public int OrderId { get; set; } //FK
    public int MenuItemId { get; set; } //FK


    public int Quantity { get; set; }
    public decimal Price { get; set; }

    private readonly List<OrderItemModification> _modifications = new(); 
    public IReadOnlyCollection<OrderItemModification> Modifications 
        => _modifications.AsReadOnly();


    private OrderItem() { }

    #region Factory Method
    public static OrderItem Create(
        int orderId, 
        int menuItemId, 
        int quantity, 
        decimal price)
    {
        if (quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero.");
        var item = new OrderItem
        {
            Id = default, // TODO - like Guid.NewGuid(), DB auto generated
            OrderId = orderId,
            MenuItemId = menuItemId,
            Quantity = quantity,
            Price = price
        };
        return item;
    }
    #endregion

    #region Commands (Behavior)
    public void Increase(int quantity)
    {
        if (quantity <= 0)
            throw new InvalidOperationException();

        Quantity += quantity;
    }
    #endregion 
}
