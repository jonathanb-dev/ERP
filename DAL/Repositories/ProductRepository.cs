using DL.Entities;
using DL.Models;
using DL.Parameters;
using DL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Product>> GetProductsWithTranslationsAsync(ProductParameters parameters)
        {
            var products = _context.Products.Include(x => x.ProductLanguages)
                .ThenInclude(x => x.Language)
                .Where(x => x.Price >= parameters.MinPrice && x.Price <= parameters.MaxPrice);

            if (!string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                switch (parameters.OrderBy)
                {
                    case "priceAsc":
                        products = products.OrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        products = products.OrderByDescending(x => x.Price);
                        break;
                }
            }

            return await PagedList<Product>.CreateAsync(products, parameters.PageNumber, parameters.ItemsPerPage);
        }

        public async Task<Product> GetProductWithTranslationsAsync(int id)
        {
            return await _context.Products.Where(x => x.Id == id)
                .Include(x => x.ProductLanguages)
                .ThenInclude(x => x.Language)
                .SingleOrDefaultAsync();
        }
    }
}