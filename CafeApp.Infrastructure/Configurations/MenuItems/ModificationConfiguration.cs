using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class ModificationConfiguration
    : IEntityTypeConfiguration<Modification>
{
    public void Configure(EntityTypeBuilder<Modification> builder)
    {
        builder.ToTable("Modification");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.AdditionalCost)
            .HasColumnType("decimal(18,2)");
    }
}