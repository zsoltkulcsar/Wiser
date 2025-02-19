using AutoMapper;
using Wiser.Identity.CQRS.Contracts.Users.Dtos;
using Wiser.Identity.Domain.Entities;

namespace Wiser.Identity.CQRS.Handlers.Users.MappingProfiles
{
    public sealed class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, AddUserDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}
