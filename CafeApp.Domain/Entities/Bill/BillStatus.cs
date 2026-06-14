namespace CafeApp.Domain;

// trade-off - Look-up table need only If status values are managed by administrators  
//public class BillStatus
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
public enum BillStatusEnum
{
    Generated = 1,
    Finalized = 2,
    PartiallyPaid = 3,
    Paid = 4,
    Void = 5
}