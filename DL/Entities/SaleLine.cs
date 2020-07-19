namespace DL.Entities
{
    public class SaleLine
    {
        public int Id { get; set; }
        public int SaleHeaderId { get; set; }
        public SaleHeader SaleHeader { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal VatRate { get; set; }
        public decimal TotalNetVatExcluded { get; set; }
        public decimal TotalNetVatIncluded { get; set; }
    }
}