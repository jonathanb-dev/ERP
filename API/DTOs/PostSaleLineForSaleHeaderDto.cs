namespace API.DTOs
{
    public class PostSaleLineForSaleHeaderDto
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal VatRate { get; set; }
    }
}