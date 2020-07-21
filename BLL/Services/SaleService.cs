using BLL.Exceptions;
using DAL;
using DL.Entities;
using DL.Services;
using System.Net;
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

        public void Create(SaleHeader saleHeader)
        {
            saleHeader.Compute();

            _context.Sales.Add(saleHeader);
        }

        public async Task<SaleHeader> GetAsync(int id)
        {
            SaleHeader saleHeader = await _context.Sales.FindAsync(id);

            if (saleHeader == null)
                throw new RestException(HttpStatusCode.NotFound, new { sale = "Not found" });

            return saleHeader;
        }
    }
}