using System.Collections.Generic;

namespace DL.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string IsoCode2 { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<ProductLanguage> ProductLanguages { get; set; }
    }
}