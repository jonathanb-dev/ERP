using DL.Entities;
using System.Linq;

namespace DAL
{
    public static class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer { Name = "Default customer" });
            }

            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier { Name = "Default supplier" });
            }

            if (context.ChangeTracker.HasChanges())
            {
                context.SaveChanges();
            }
        }
    }
}