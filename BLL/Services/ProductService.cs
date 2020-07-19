using DAL;
using DL.Entities;
using DL.Repositories;
using DL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IProductRepository _productRepository;

        public ProductService(DataContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsWithTranslationsAsync()
        {
            return await _productRepository.GetProductsWithTranslationsAsync();
        }

        public async Task<Product> GetProductWithTranslationsAsync(int id)
        {
            return await _productRepository.GetProductWithTranslationsAsync(id);
        }
    }
}