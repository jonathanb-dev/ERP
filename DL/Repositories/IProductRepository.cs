using DL.Entities;
using DL.Models;
using DL.Parameters;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetProductsWithTranslationsAsync(ProductParameters parameters);
        Task<Product> GetProductWithTranslationsAsync(int id);
    }
}