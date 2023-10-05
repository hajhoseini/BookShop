using AutoMapper;
using Core.Commands.UserCommands;
using Core.Entities;

namespace Infrastructure.MapperProfiles
{
	public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
