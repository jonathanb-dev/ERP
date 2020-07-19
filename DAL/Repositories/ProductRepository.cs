using DL.Entities;
using DL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Product>> GetProductsWithTranslationsAsync()
        {
            return await _context.Products.Include(x => x.ProductLanguages)
                .ThenInclude(x => x.Language)
                .ToListAsync();
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