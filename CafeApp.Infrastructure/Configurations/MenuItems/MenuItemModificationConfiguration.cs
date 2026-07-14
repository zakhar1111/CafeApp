using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class MenuItemModificationConfiguration
    : IEntityTypeConfiguration<MenuItemModification>
{
    public void Configure(EntityTypeBuilder<MenuItemModification> builder)
    {
        builder.ToTable("MenuItemModification");

        builder.HasKey(x => new
        {
            x.MenuItemId,
            x.ModificationId
        });

        //builder.Property(x => x.AdditionalPrice)
        //    .HasColumnType("decimal(18,2)");

        builder.HasOne<MenuItem>()
            .WithMany()//(x => x.Modifications)
            .HasForeignKey(x => x.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Modification>()
            .WithMany()
            .HasForeignKey(x => x.ModificationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}