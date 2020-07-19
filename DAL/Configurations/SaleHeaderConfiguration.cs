using DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class SaleHeaderConfiguration : IEntityTypeConfiguration<SaleHeader>
    {
        public void Configure(EntityTypeBuilder<SaleHeader> builder)
        {
            builder.Property(x => x.TotalVatExcluded)
                .HasColumnType("DECIMAL(18, 2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.TotalVatIncluded)
                .HasColumnType("DECIMAL(18, 2)")
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}