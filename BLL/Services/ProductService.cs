using BLL.Exceptions;
using DAL;
using DL.Entities;
using DL.Models;
using DL.Parameters;
using DL.Repositories;
using DL.Services;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ILanguageService _languageService;

        public ProductService(
            DataContext context,
            IProductRepository productRepository,
            ILanguageService languageService)
        {
            _context = context;
            _productRepository = productRepository;
            _languageService = languageService;
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            Product product = await GetProduct(id);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product == null)
                throw new RestException(HttpStatusCode.NotFound, new { product = "Not found" });

            return product;
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

        public async Task<bool> ProductExists(int id)
        {
            return await _context.Products.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Validate(Product product)
        {
            return;
        }
    }
}