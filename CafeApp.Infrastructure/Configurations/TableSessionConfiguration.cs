using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CafeApp.Infrastructure;

public sealed class TableSessionConfiguration
    : IEntityTypeConfiguration<TableSession>
{
    public void Configure(EntityTypeBuilder<TableSession> builder)
    {
        builder.ToTable("TableSession");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.TableId)
            .IsRequired();

        builder.Property(x => x.BookingId)
            .IsRequired(false);

        builder.Property(x => x.ServedByStaffId)
            .IsRequired();

        builder.Property(x => x.StartTime)
            .IsRequired();

        builder.Property(x => x.EndTime);

        builder.Property(x => x.PartySize)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        // Table
        builder.HasOne<Table>()
            .WithMany()//(x => x.TableSessions)
            .HasForeignKey(x => x.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        // Booking
        builder.HasOne<Booking>()
            .WithMany()
            .HasForeignKey(x => x.BookingId)
            .OnDelete(DeleteBehavior.Restrict);

        // Staff
        builder.HasOne<Staff>()
            .WithMany()//(x => x.TableSessions)
            .HasForeignKey(x => x.ServedByStaffId)
            .OnDelete(DeleteBehavior.Restrict);

        // Orders collection backing field
        //builder.Metadata
        //    .FindNavigation(nameof(TableSession.Orders))!
        //    .SetPropertyAccessMode(PropertyAccessMode.Field);

        //builder.HasMany(x => x.Orders)
        //    .WithOne()
        //    .HasForeignKey(x => x.TableSessionId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}