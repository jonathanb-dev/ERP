using System.Collections.Generic;

namespace DL.Entities
{
    public class SaleHeader
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalVatExcluded { get; set; }
        public decimal TotalVatIncluded { get; set; }
        public ICollection<SaleLine> SaleLines { get; set; }

        public void Compute()
        {
            foreach (SaleLine saleLine in SaleLines)
            {
                TotalVatExcluded += saleLine.TotalNetVatExcluded = saleLine.Quantity * saleLine.UnitPrice * (1 - saleLine.DiscountRate);
                TotalVatIncluded += saleLine.TotalNetVatIncluded = saleLine.TotalNetVatExcluded * (1 + saleLine.VatRate);
            }
        }
    }
}