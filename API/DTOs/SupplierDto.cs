using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}