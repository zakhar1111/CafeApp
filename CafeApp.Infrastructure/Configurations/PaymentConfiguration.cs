using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class PaymentConfiguration
    : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.BillId)
            .IsRequired();

        builder.Property(x => x.CustomerId);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2);

        builder.Property(x => x.PaymentTime)
            .IsRequired();

        builder.Property(x => x.PayStatus)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.PayType)
            .HasConversion<int>()
            .IsRequired();
    }
}