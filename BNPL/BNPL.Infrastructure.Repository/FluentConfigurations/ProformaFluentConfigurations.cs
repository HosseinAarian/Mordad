using BNPL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BNPL.Infrastructure.Repository.FluentConfigurations;

internal class ProformaFluentConfigurations : IEntityTypeConfiguration<Proforma>
{
    public void Configure(EntityTypeBuilder<Proforma> builder)
    {
        builder.Metadata.SetSchema("FT");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasMany(p => p.ProformaDetails)
               .WithOne(d => d.Proforma)
               .HasForeignKey(d => d.ProformaId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
