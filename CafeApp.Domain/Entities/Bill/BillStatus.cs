namespace CafeApp.Domain;

public class BillStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public enum BillStatusEnum
{
    Draft = 1,
    Issued = 2,
    Paid = 3,
    Refunded = 4
}