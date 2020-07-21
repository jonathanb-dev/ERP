using BLL.Exceptions;
using DAL;
using DL.Entities;
using DL.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly DataContext _context;

        public SupplierService(DataContext context)
        {
            _context = context;
        }

        public async Task<Supplier> GetAsync(int id)
        {
            Supplier supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
                throw new RestException(HttpStatusCode.NotFound, new { supplier = "Not found" });

            return supplier;
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }
    }
}