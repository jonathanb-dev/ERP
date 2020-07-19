namespace API.DTOs
{
    public class SaleLineDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal VatRate { get; set; }
        public decimal TotalNetVatExcluded { get; set; }
        public decimal TotalNetVatIncluded { get; set; }
    }
}