﻿namespace API.DTOs
{
    public class ProductLanguageForProductDto
    {
        public int LanguageId { get; set; }
        public LanguageDto Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}