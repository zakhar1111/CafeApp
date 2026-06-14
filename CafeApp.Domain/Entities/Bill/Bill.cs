namespace CafeApp.Domain;

public class Bill
{
    public int Id { get; set; }
    public int OrderId { get; set; } //FK
    
    public decimal TotalAmount { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime DeliveredTime { get; set; }


    //public int BillStatusId { get; set; } //FK
    public BillStatusEnum BillStatus { get; set; }

    private readonly List<BillAdjustment> _adjustments = new();
    public IReadOnlyCollection<BillAdjustment> Adjustments
        => _adjustments.AsReadOnly();
}
