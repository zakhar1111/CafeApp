namespace CafeApp.Domain;

public enum BillStatusEnum
{
    Generated = 1,
    Finalized = 2,
    PartiallyPaid = 3,
    Paid = 4,
    Void = 5
}