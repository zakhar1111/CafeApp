namespace CafeApp.Domain;

public class BillAdjustment
{
    public int Id { get; set; }
    public int BillId { get; set; } //FK
    public decimal Amount { get; set; }
    public string Reason { get; set; }
}
