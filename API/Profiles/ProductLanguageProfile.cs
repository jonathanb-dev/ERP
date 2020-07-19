using API.DTOs;
using AutoMapper;
using DL.Entities;

namespace API.Profiles
{
    public class ProductLanguageProfile : Profile
    {
        public ProductLanguageProfile()
        {
            // Entity to DTO
            CreateMap<ProductLanguage, ProductLanguageForProductDto>();

            // DTO to Entity
            CreateMap<ProductLanguageForProductDto, ProductLanguage>();
        }
    }
}