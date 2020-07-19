using System.Collections.Generic;

namespace API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductLanguageForProductDto> ProductLanguages { get; set; }
    }
}