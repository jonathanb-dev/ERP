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
            CreateMap<Product, PostProductDto>();
            CreateMap<Product, PutAndPatchProductDto>();

            // DTO to Entity
            CreateMap<ProductDto, Product>();
            CreateMap<PostProductDto, Product>();
            CreateMap<PutAndPatchProductDto, Product>();
        }
    }
}