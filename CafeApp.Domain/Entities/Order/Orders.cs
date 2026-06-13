namespace CafeApp.Domain;

public class Orders
{
    public int Id { get; set; }
    public int OrderStatusId { get; set; } //FK
    public int CreatedByStaffId { get; set; } //FK
    public int TableSessionId { get; set; } //FK
    public DateTime CreatedTime { get; set; }
    public int OrderTypeId { get; set; } //FK
}
