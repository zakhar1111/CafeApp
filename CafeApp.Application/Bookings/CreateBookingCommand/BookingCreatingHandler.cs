using CafeApp.Domain;
using CafeApp.Domain.Repositories;

namespace CafeApp.Application.Bookings;

public sealed class CreateBookingHandler(
        IBookingRepository repository,
        IUnitOfWork unitOfWork)
    : IOperationHandler<CreateBookingCommand, int>
{
    private readonly IBookingRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<int> HandleAsync(
        CreateBookingCommand command,
        CancellationToken ct)
    {
        var booking = Booking.Create(
            command.CustomerId,
            command.ReservationTime,
            command.PeopleNumber);

        await _repository.AddAsync(
            booking,
            ct);

        await _unitOfWork.SaveChangesAsync(ct);

        return booking.Id;
    }

}
