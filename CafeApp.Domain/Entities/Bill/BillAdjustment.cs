namespace CafeApp.Domain;

public class BillAdjustment
{
    private BillAdjustment() { }
    public int Id { get; private set; }
    public int BillId { get; private set; } //FK
    public decimal Amount { get; private set; }
    public string Reason { get; private set; }

    public static BillAdjustment Create(decimal amount,string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new InvalidOperationException();

        return new BillAdjustment
        {
            Amount = amount,
            Reason = reason
        };
    }
}
