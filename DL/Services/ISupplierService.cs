using DL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> ListAsync();
        Task<Supplier> GetAsync(int id);
    }
}