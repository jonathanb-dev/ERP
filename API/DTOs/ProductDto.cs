using System.Collections.Generic;

namespace API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public List<ProductLanguageForProductDto> ProductLanguages { get; set; }
    }
}