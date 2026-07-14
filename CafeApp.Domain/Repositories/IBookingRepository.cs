namespace CafeApp.Domain.Repositories;

public interface IBookingRepository
{
    Task AddAsync(Booking booking,CancellationToken ct);

    Task<Booking?> GetByIdAsync(int id,CancellationToken ct);

    Task<bool> ExistsAsync(int tableId,DateTime reservationTime,CancellationToken ct);

}
