using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class TableConfiguration
    : IEntityTypeConfiguration<Tables>
{
    public void Configure(EntityTypeBuilder<Tables> builder)
    {
        builder.ToTable("Tables");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Number)
            .IsRequired();

        builder.Property(x => x.SeatsNumber)
            .IsRequired();

        builder.HasIndex(x => x.Number)
            .IsUnique();

        // Backing field for sessions collection
        //builder.Metadata
        //    .FindNavigation(nameof(Table.TableSessions))!
        //    .SetPropertyAccessMode(PropertyAccessMode.Field);

        //builder.HasMany()//(x => x.TableSessions)
        //    .WithOne()
        //    .HasForeignKey(x => x.TableId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}
