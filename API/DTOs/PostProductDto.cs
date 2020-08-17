using System.Collections.Generic;

namespace API.DTOs
{
    public class PostProductDto
    {
        public decimal Price { get; set; }
        public ICollection<PostProductLanguageForProductDto> ProductLanguages { get; set; }
    }
}