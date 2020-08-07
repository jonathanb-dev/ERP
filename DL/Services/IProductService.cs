using DL.Entities;
using DL.Models;
using DL.Parameters;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface IProductService
    {
        Task<PagedList<Product>> GetProductsWithTranslationsAsync(ProductParameters parameters);
        Task<Product> GetProductWithTranslationsAsync(int id);
    }
}