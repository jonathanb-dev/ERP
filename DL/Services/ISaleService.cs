using DL.Entities;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface ISaleService
    {
        Task<SaleHeader> GetAsync(int id);
    }
}