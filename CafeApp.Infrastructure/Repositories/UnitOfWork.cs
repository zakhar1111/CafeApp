using CafeApp.Domain.Repositories;

namespace CafeApp.Infrastructure.Repositories;

public sealed class UnitOfWork(ApplicationDbContext context)
    : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _context.SaveChangesAsync(ct);
    }
}
