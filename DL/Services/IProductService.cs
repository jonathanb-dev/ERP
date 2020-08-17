using DL.Entities;
using DL.Models;
using DL.Parameters;
using DL.Services.Base;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface IProductService : IBaseService<Product>
    {
        Task<PagedList<Product>> GetProductsWithTranslationsAsync(ProductParameters parameters);
        Task<Product> GetProduct(int id);
        Task<Product> GetProductWithTranslationsAsync(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task<bool> ProductExists(int id);
        Task DeleteProduct(int id);
    }
}