using API.DTOs;
using AutoMapper;
using DL.Entities;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Entity to DTO
            CreateMap<AppUser, UserDto>();

            // DTO to Entity
            CreateMap<UserDto, AppUser>();
        }
    }
}