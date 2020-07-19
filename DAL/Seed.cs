using DL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public static class Seed
    {
        public static void SeedData(DataContext context)
        {
            List<Language> Languages = new List<Language>
            {
                new Language { IsoCode2 = "fr" },
                new Language { IsoCode2 = "nl" },
                new Language { IsoCode2 = "en" }
            };

            if (!context.Languages.Any())
            {
                context.Languages.AddRange(Languages);
            }

            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer { Name = "Default customer" });
            }

            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier { Name = "Default supplier" });
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(new Product[]
                {
                    new Product
                    {
                        Price = 100M,
                        ProductLanguages = new List<ProductLanguage>()
                        {
                            new ProductLanguage
                            {
                                Name = "Default product 1",
                                Description = "This is a generic product.",
                                Language = Languages.Single(x => x.IsoCode2 == "fr" )
                            }
                        }
                    },
                    new Product
                    {
                        Price = 499.99M,
                        ProductLanguages = new List<ProductLanguage>()
                        {
                            new ProductLanguage
                            {
                                Name = "Default product 2",
                                Description = "This is a generic product.",
                                Language = Languages.Single(x => x.IsoCode2 == "nl" )
                            }
                        }
                    },
                    new Product
                    {
                        Price = 1000M,
                        ProductLanguages = new List<ProductLanguage>()
                        {
                            new ProductLanguage
                            {
                                Name = "Default product 3",
                                Description = "This is a generic product.",
                                Language = Languages.Single(x => x.IsoCode2 == "en" )
                            }
                        }
                    }
                });
            }

            if (context.ChangeTracker.HasChanges())
            {
                context.SaveChanges();
            }
        }
    }
}