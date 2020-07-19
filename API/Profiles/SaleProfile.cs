using API.DTOs;
using AutoMapper;
using DL.Entities;

namespace API.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            // Entity to DTO
            CreateMap<SaleHeader, SaleHeaderDto>();
            CreateMap<SaleLine, SaleLineDto>();

            // DTO to Entity
            CreateMap<SaleHeaderDto, SaleHeader>();
            CreateMap<SaleLineDto, SaleLine>();
        }
    }
}