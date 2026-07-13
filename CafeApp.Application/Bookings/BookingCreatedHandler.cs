using CafeApp.Domain;

namespace CafeApp.Application.Bookings;

public sealed class BookingCreatedHandler
    : IDomainEventHandler<BookingCreated>
{
    public async Task HandleAsync(BookingCreated domainEvent, CancellationToken ct)
    {
        Console.WriteLine($"Booking {domainEvent.BookingId} created.");

        await Task.CompletedTask;
    }
}
