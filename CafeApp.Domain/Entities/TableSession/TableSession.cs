using System;

namespace CafeApp.Domain;

public class TableSession
{
    public int Id { get; set; }

    public int TableId { get; set; } //FK
    public int? BookingId { get; set; } //FK
    public int ServedByStaffId { get; set; } //FK
    

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    

    public int PartySize { get; set; }
}
//Invariants:
//   EndTime must be after StartTime
//   Cannot start session if table is occupied
//   Session must link to either Booking OR walk-in, not both null

//Commands
//   StartSession
//   AssignBooking
//   EndSession

//State machine
//   Active → Ended

//Events
//   TableSessionStarted
//   TableAssigned
//   SessionEnded
