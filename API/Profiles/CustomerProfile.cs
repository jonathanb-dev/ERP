using API.DTOs;
using AutoMapper;
using DL.Entities;

namespace API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Entity to DTO
            CreateMap<Customer, CustomerDto>();

            // DTO to Entity
            CreateMap<CustomerDto, Customer>();
        }
    }
}