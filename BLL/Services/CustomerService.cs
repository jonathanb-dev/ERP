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
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetAsync(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                throw new RestException(HttpStatusCode.NotFound, new { customer = "Not found" });

            return customer;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}