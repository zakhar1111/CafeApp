using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class OrderItemModificationConfiguration
    : IEntityTypeConfiguration<OrderItemModification>
{
    public void Configure(EntityTypeBuilder<OrderItemModification> builder)
    {
        builder.ToTable("OrderItemModification");

        builder.HasKey(x => new
        {
            x.OrderItemId,
            x.ModificationId
        });

        builder.Property(x => x.AdditionalCost)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne<Modification>()
            .WithMany()
            .HasForeignKey(x => x.ModificationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}