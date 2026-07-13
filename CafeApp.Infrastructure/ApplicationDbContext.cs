using CafeApp.Application;
using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CafeApp.Infrastructure;

public class ApplicationDbContext
    : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;
    public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options,
           IDomainEventDispatcher dispatcher)
           : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public DbSet<Bill> Bills => Set<Bill>();

    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<TableSession> TableSessions => Set<TableSession>();

    public DbSet<MenuItem> MenuItems => Set<MenuItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema("cafe");
    }
    public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        var domainEntities = ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(e => e.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(e => e.Entity.DomainEvents)
            .ToList();

        var result = await base.SaveChangesAsync(ct);

        //foreach (var domainEvent in domainEvents)
        //{
        //    await _publisher.Publish(domainEvent, ct); MediatR
        //}

        foreach (var entity in domainEntities)
        {
            entity.Entity.ClearEvents();
        }
        await _dispatcher.DispatchAsync(domainEvents,ct);

        return result;
    }
}