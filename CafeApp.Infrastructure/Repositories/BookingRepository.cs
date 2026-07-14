using CafeApp.Domain;
using CafeApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Infrastructure.Repositories;

public sealed class BookingRepository(ApplicationDbContext db)
    : IBookingRepository
{
    private readonly ApplicationDbContext _db = db;

    public async Task AddAsync(Booking booking,CancellationToken ct)
    {
        await _db.Bookings.AddAsync(
            booking,
            ct);
    }

    public Task<Booking?> GetByIdAsync(int id,CancellationToken ct)
    {
        return _db.Bookings
            .Include(x => x.TableSessions)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                ct);
    }

    public Task<bool> ExistsAsync(int tableId,DateTime reservationTime,CancellationToken ct)
    {
        return _db.Bookings.AnyAsync(
            x => x.TableId == tableId &&
                 x.ReservationTime == reservationTime,
            ct);
    }

}
