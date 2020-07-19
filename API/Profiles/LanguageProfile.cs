using API.DTOs;
using AutoMapper;
using DL.Entities;

namespace API.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            // Entity to DTO
            CreateMap<Language, LanguageDto>();

            // DTO to Entity
            CreateMap<LanguageDto, Language>();
        }
    }
}