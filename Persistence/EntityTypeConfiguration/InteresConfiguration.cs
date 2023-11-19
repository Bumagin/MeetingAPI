using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfiguration;

public class InteresConfiguration : IEntityTypeConfiguration<Interes>
{
    public void Configure(EntityTypeBuilder<Interes> builder)
    {
        builder.HasKey(interes => interes.Id);
        builder.HasIndex(interes => interes.Id).IsUnique();
        builder.Property(interes => interes.Name).HasMaxLength(50);
    }
}