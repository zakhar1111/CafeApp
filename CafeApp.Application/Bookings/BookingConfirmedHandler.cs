using CafeApp.Domain;

namespace CafeApp.Application.Bookings;

public sealed class BookingConfirmedHandler
    : IDomainEventHandler<BookingConfirmed>
{
    public async Task HandleAsync(BookingConfirmed domainEvent,CancellationToken ct)
    {
        Console.WriteLine($"Booking {domainEvent.BookingId} confirmed.");

        await Task.CompletedTask;
    }
}
