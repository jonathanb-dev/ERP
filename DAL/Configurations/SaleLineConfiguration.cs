using DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class SaleLineConfiguration : IEntityTypeConfiguration<SaleLine>
    {
        public void Configure(EntityTypeBuilder<SaleLine> builder)
        {
            builder.Property(x => x.Quantity)
                .HasColumnType("DECIMAL(9, 2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.UnitPrice)
                .HasColumnType("DECIMAL(9, 2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.DiscountRate)
                .HasColumnType("DECIMAL(3, 2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.VatRate)
                .HasColumnType("DECIMAL(3, 2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.TotalNetVatExcluded)
                .HasColumnType("DECIMAL(18, 2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.TotalNetVatIncluded)
                .HasColumnType("DECIMAL(9, 2)")
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}