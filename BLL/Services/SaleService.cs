using DAL;
using DL.Entities;
using DL.Services;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SaleService : ISaleService
    {
        private readonly DataContext _context;

        public SaleService(DataContext context)
        {
            _context = context;
        }

        public async Task<SaleHeader> GetAsync(int id)
        {
            return await _context.Sales.FindAsync(id);
        }
    }
}