namespace CafeApp.Domain;

public class BookingStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public enum BookingStatusEnum
{
    Canceled = 1,
    Confirmed = 2,
    Seated = 3,
    Completed = 4
}