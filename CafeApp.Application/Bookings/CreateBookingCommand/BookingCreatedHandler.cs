using CafeApp.Domain;
using CafeApp.Domain.Repositories;

namespace CafeApp.Application.Bookings;

public sealed class BookingCreatedHandler(
    IBookingRepository repository, 
    IUnitOfWork unitOfWork)
    : IDomainEventHandler<BookingCreated>
{
    private readonly IBookingRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task HandleAsync(BookingCreated domainEvent, CancellationToken ct)
    {
        Console.WriteLine($"Booking {domainEvent.BookingId} created.");

        await Task.CompletedTask;
    }
}
