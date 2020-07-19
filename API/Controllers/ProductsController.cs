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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            IEnumerable<Product> products = await _productService.GetProductsWithTranslationsAsync();

            IEnumerable<ProductDto> result = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            Product product = await _productService.GetProductWithTranslationsAsync(id);

            ProductDto result = _mapper.Map<ProductDto>(product);

            return Ok(result);
        }
    }
}