using CafeApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure;

public sealed class StaffConfiguration
    : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("Staff");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        // [TODO]Staff 1 ---- * Orders 
        builder.HasMany<Order>()//(x => x.Orders)
            .WithOne()
            .HasForeignKey(x => x.CreatedByStaffId)
            .OnDelete(DeleteBehavior.Restrict);

        // [TODO] Staff 1 ---- * TableSessions
        builder.HasMany<TableSession>()//(x => x.TableSessions)
            .WithOne()
            .HasForeignKey(x => x.ServedByStaffId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}