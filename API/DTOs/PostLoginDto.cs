using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PostLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}