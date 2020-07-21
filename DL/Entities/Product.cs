using System.Collections.Generic;

namespace DL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductLanguage> ProductLanguages { get; set; }
        public ICollection<SaleLine> SaleLines { get; set; }
    }
}