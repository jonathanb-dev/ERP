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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliers()
        {
            IEnumerable<Supplier> suppliers = await _supplierService.ListAsync();

            IEnumerable<SupplierDto> result = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetSupplier(int id)
        {
            Supplier supplier = await _supplierService.GetAsync(id);

            SupplierDto result = _mapper.Map<SupplierDto>(supplier);

            return Ok(result);
        }
    }
}