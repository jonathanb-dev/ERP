using API.DTOs;
using AutoMapper;
using DL.Entities;

namespace API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Entity to DTO
            CreateMap<Product, ProductDto>();

            // DTO to Entity
            CreateMap<ProductDto, Product>();
        }
    }
}