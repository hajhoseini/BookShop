using Core.Commands.UserCommands;
using Core.Entities;

namespace Core.IRepositories;

public interface IUserRepository :
	IGenericRepository<User, CreateUserCommand, UpdateUserCommand, DeleteUserCommand>
{

}
