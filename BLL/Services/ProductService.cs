using BLL.Exceptions;
using DAL;
using DL.Entities;
using DL.Models;
using DL.Parameters;
using DL.Repositories;
using DL.Services;
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

        public async Task<PagedList<Product>> GetProductsWithTranslationsAsync(ProductParameters parameters)
        {
            return await _productRepository.GetProductsWithTranslationsAsync(parameters);
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