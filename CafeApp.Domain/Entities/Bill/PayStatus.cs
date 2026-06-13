namespace CafeApp.Domain;

public class PayStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public enum PayStatusEnum
{
    Pending = 1,
    Completed = 2,
    Failed = 3
}