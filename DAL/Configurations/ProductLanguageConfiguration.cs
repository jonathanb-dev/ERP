using DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class ProductLanguageConfiguration : IEntityTypeConfiguration<ProductLanguage>
    {
        public void Configure(EntityTypeBuilder<ProductLanguage> builder)
        {
            // Properties
            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(500)")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            // Relationships
            builder.HasKey(pl => new { pl.ProductId, pl.LanguageId });

            builder.HasOne(pl => pl.Product)
                .WithMany(p => p.ProductLanguages)
                .HasForeignKey(pl => pl.ProductId);

            builder.HasOne(pl => pl.Language)
                .WithMany(l => l.ProductLanguages)
                .HasForeignKey(pl => pl.LanguageId);
        }
    }
}