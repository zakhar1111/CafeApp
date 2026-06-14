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
//Invariants:
//   Cannot double-book same table/time slot
//   PeopleNumber must be > 0
//   Cannot confirm past reservation time

//Commands
//   CreateBooking
//   ConfirmBooking
//   CancelBooking

//State machine
//   Pending → Confirmed → Seated → Completed
//           ↘ Cancelled

//Events
//   BookingCreated
//   BookingConfirmed
//   BookingCancelled