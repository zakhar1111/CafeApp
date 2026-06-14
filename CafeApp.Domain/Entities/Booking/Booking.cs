namespace CafeApp.Domain;

public class Booking
{
    public int Id { get; set; }


    public int? TableId { get; set; } //FK
    public int CustomerId { get; set; } //FK
    

    public BookingStatusEnum BookingState { get; set; } 


    public DateTime ReservationTime { get; set; }
    public int PeopleNumber { get; set; }
}
