using AutoMapper;
using FlyTrips.DTO.Auth;
using FlyTrips.DTO.Role;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoleCreateUpdateDto, Role>();
            CreateMap<Role, RoleResponseDto>();

            CreateMap<User, RegisterResponse>();
            CreateMap<RegisterDto, User>();
        }
    }
}
