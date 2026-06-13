namespace CafeApp.Domain;

public class TableSeessionStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public enum TableSessionStatusEnum
{
    Opened = 1,
    Active = 2,
    Closed = 3
}