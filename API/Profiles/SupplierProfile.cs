using API.DTOs;
using AutoMapper;
using DL.Entities;

namespace API.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            // Entity to DTO
            CreateMap<Supplier, SupplierDto>();

            // DTO to Entity
            CreateMap<SupplierDto, Supplier>();
        }
    }
}