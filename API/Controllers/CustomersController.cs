using API.DTOs;
using AutoMapper;
using DL.Entities;
using DL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            IEnumerable<Customer> customers = await _customerService.ListAsync();

            IEnumerable<CustomerDto> result = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            Customer customer = await _customerService.GetAsync(id);

            CustomerDto result = _mapper.Map<CustomerDto>(customer);

            return Ok(result);
        }
    }
}