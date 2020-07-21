using System.Collections.Generic;

namespace API.DTOs
{
    public class PostSaleHeaderDto
    {
        public int CustomerId { get; set; }
        public ICollection<PostSaleLineForSaleHeaderDto> SaleLines { get; set; }
    }
}