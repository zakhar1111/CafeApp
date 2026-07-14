using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CafeApp.Infrastructure;

public sealed class BookingConfiguration
    : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.Property(x => x.TableId)
            .IsRequired(false);

        builder.Property(x => x.ReservationTime)
            .IsRequired();

        builder.Property(x => x.PeopleNumber)
            .IsRequired();

        builder.Property(x => x.BookingState)
            .HasConversion<int>()
            .IsRequired();

        // Domain events are runtime only
        builder.Ignore(x => x.DomainEvents);

        // Customer FK
        builder.HasOne<Customer>()
            .WithMany()//(c => c.Bookings)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Table FK (optional)
        builder.HasOne(b => b.Tables)
            .WithMany()
            .HasForeignKey(x => x.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        // TableSession has the FK to Booking
        builder.HasMany(b => b.TableSessions)
            .WithOne()//(ts => ts.Booking)
            .HasForeignKey(ts => ts.BookingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
