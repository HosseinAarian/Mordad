using BNPL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BNPL.Infrastructure.Repository.FluentConfigurations;

public class ProformaDetailFluentConfiguration : IEntityTypeConfiguration<ProformaDetail>
{
    public void Configure(EntityTypeBuilder<ProformaDetail> builder)
    {
        builder.Metadata.SetSchema("FT");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(d => d.Amount)
            .HasColumnType("decimal(18,2)");
    }
}
