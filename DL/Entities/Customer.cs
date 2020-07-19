namespace DL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}