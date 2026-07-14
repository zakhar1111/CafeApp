using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class BillAdjustmentConfiguration
    : IEntityTypeConfiguration<BillAdjustment>
{
    public void Configure(EntityTypeBuilder<BillAdjustment> builder)
    {
        builder.ToTable("BillAdjustment");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Reason)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.BillId)
            .IsRequired();
    }
}
