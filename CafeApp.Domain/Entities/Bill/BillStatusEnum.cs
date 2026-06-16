namespace CafeApp.Domain;

public enum BillStatusEnum
{
    Draft = 0,
    Generated = 1,
    //Finalized = 2,
    PartiallyPaid = 3,
    Paid = 4,
    Closed = 5
}