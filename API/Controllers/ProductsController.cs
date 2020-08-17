using API.DTOs;
using API.Helpers;
using AutoMapper;
using DL.Entities;
using DL.Models;
using DL.Parameters;
using DL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery]ProductParameters parameters)
        {
            PagedList<Product> products = await _productService.GetProductsWithTranslationsAsync(parameters);

            IEnumerable<ProductDto> result = _mapper.Map<IEnumerable<ProductDto>>(products);

            Response.AddPagination(products.CurrentPage, products.TotalPages, products.ItemsPerPage, products.TotalCount);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            Product product = await _productService.GetProductWithTranslationsAsync(id);

            ProductDto result = _mapper.Map<ProductDto>(product);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(PostProductDto postProductDto)
        {
            Product product = _mapper.Map<Product>(postProductDto);

            await _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, _mapper.Map<ProductDto>(product));
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(int id, PutAndPatchProductDto putAndPatchProductDto)
        {
            if (id != putAndPatchProductDto.Id)
            {
                return BadRequest();
            }

            Product product = _mapper.Map<Product>(putAndPatchProductDto);

            try
            {
                await _productService.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _productService.ProductExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> PatchProduct(int id, PutAndPatchProductDto putAndPatchProductDto)
        {
            if (id != putAndPatchProductDto.Id)
            {
                return BadRequest();
            }

            Product product = _mapper.Map<Product>(putAndPatchProductDto);

            try
            {
                await _productService.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _productService.ProductExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);

            return NoContent();
        }
    }
}