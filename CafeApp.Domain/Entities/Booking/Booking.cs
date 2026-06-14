namespace CafeApp.Domain;

public class Booking
{
    public int Id { get; set; }
    public int? TableId { get; set; } //FK
    public int CustomerId { get; set; } //FK
    //public int BookingStatusId { get; set; } //FK duplication 
    public BookingStatusEnum BookingState { get; set; } // keep state in enum + conversion. State immutable no Admin
    public DateTime ReservationTime { get; set; }
    public int PeopleNumber { get; set; }
}
