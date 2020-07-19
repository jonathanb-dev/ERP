namespace DL.Entities
{
    public class ProductLanguage
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}