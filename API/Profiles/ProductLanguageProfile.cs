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
            CreateMap<ProductLanguage, PostProductLanguageForProductDto>();

            // DTO to Entity
            CreateMap<ProductLanguageForProductDto, ProductLanguage>();
            CreateMap<PostProductLanguageForProductDto, ProductLanguage>();
        }
    }
}