using DL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsWithTranslationsAsync();
        Task<Product> GetProductWithTranslationsAsync(int id);
    }
}