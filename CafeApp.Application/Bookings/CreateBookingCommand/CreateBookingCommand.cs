namespace CafeApp.Application.Bookings;

public sealed record CreateBookingCommand(
    int CustomerId,
    DateTime ReservationTime,
    int PeopleNumber) : IRequest<int>;
