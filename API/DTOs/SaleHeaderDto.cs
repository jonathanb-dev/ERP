using System.Collections.Generic;

namespace API.DTOs
{
    public class SaleHeaderDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public decimal TotalVatExcluded { get; set; }
        public decimal TotalVatIncluded { get; set; }
        public ICollection<SaleLineDto> SaleLines { get; set; }
    }
}