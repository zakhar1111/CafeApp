namespace CafeApp.Domain;

public class OrderItemModification
{
    public int OrderItemId { get; set; } //FK + PK
    public int ModificationId { get; set; } //FK + PK
    public decimal AdditionalCost { get; set; }
}
