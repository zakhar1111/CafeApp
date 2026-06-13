namespace CafeApp.Domain;

public class  OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; } //FK
    public int MenuItemId { get; set; } //FK
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
