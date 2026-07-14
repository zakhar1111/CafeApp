using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class BillConfiguration
    : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.OrderId)
            .IsRequired();

        builder.Property(x => x.TotalAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.CreatedTime)
            .IsRequired();

        builder.Property(x => x.DeliveredTime);

        builder.Property(x => x.BillStatus)
            .HasConversion<int>()
            .IsRequired();

        builder.HasIndex(x => x.OrderId)
            .IsUnique();

        builder.HasMany(x => x.Adjustments)
            .WithOne()//(x => x.Bill)
            .HasForeignKey(x => x.BillId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Payments)
            .WithOne()//(x => x.Bill)
            .HasForeignKey(x => x.BillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
