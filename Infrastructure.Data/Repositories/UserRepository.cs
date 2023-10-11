using AutoMapper;
using Core.Commands.UserCommands;
using Core.IRepositories;
using Core.Entities;
using Infrastructure.Data.Data;

namespace Infrastructure.Data.Repositories;

public class UserRepository : GenericRepository<User, CreateUserCommand, UpdateUserCommand, DeleteUserCommand>, IUserRepository
{
	public UserRepository(BookShopDBContext context, IMapper mapper) : base(context, mapper)
	{
	}
}
