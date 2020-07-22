using DAL.Configurations;
using DL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleHeader> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductLanguageConfiguration());
            builder.ApplyConfiguration(new SaleHeaderConfiguration());
            builder.ApplyConfiguration(new SaleLineConfiguration());
        }
    }
}