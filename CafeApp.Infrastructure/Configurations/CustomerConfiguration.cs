using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class CustomerConfiguration
    : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(255);

        builder.Property(x => x.Phone)
            .HasMaxLength(30);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        // Customer 1 ---- * Booking [TODO]
        //builder.HasMany(x => x.Bookings)
        //    .WithOne()
        //    .HasForeignKey(x => x.CustomerId)
        //    .OnDelete(DeleteBehavior.Restrict);

        // Customer 1 ---- * Payment [TODO]
        //builder.HasMany(x => x.Payments)
        //    .WithOne()
        //    .HasForeignKey(x => x.CustomerId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}
