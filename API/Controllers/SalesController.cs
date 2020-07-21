using API.DTOs;
using AutoMapper;
using DL.Entities;
using DL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        private readonly IMapper _mapper;

        public SalesController(ISaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleHeaderDto>> GetSale(int id)
        {
            SaleHeader saleHeader = await _saleService.GetAsync(id);

            SaleHeaderDto result = _mapper.Map<SaleHeaderDto>(saleHeader);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SaleHeaderDto>> PostSale(PostSaleHeaderDto postSaleHeaderDto)
        {
            SaleHeader result = _mapper.Map<SaleHeader>(postSaleHeaderDto);

            _saleService.Create(result);

            return CreatedAtAction(nameof(GetSale), new { id = result.Id }, _mapper.Map<SaleHeaderDto>(result));
        }
    }
}