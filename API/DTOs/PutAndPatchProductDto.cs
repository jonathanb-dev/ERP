using System.Collections.Generic;

namespace API.DTOs
{
    public class PutAndPatchProductDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public ICollection<PostProductLanguageForProductDto> ProductLanguages { get; set; }
    }
}