using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class MenuItemConfiguration
    : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItem");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CurrentPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.MenuCategoryId)
            .IsRequired();

        builder.HasOne<MenuCategory>()//(x => x.Modifications)
            .WithMany()
            .HasForeignKey(x => x.MenuCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
