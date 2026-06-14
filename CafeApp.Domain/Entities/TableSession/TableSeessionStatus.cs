namespace CafeApp.Domain;

// trade-off - Look-up table need only If status values are managed by administrators  
//public class TableSeessionStatus
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
public enum TableSessionStatusEnum
{
    Opened = 1,
    Active = 2,
    Closed = 3
}