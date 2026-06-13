namespace CafeApp.Domain;

public class Booking
{
    public int Id { get; set; }
    public int TableId { get; set; } //FK
    public int CustomerId { get; set; } //FK
    public int BookingStatusId { get; set; } //FK
    public DateTime ReservationTime { get; set; }
    public int PeopleNumber { get; set; }
}
