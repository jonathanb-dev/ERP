using DL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<Customer> GetAsync(int id);
    }
}