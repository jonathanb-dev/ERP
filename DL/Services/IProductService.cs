using DL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsWithTranslationsAsync();
        Task<Product> GetProductWithTranslationsAsync(int id);
    }
}