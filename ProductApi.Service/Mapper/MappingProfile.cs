using AutoMapper;
using ProductApi.Data.Model;
using ProductApi.Dto.Dtos;

namespace ProductApi.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}