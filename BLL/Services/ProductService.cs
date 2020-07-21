using BLL.Exceptions;
using DAL;
using DL.Entities;
using DL.Repositories;
using DL.Services;
using System.Collections.Generic;
using System.Net;
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
            Product product = await _productRepository.GetProductWithTranslationsAsync(id);

            if (product == null)
                throw new RestException(HttpStatusCode.NotFound, new { product = "Not found" });

            return product;
        }
    }
}