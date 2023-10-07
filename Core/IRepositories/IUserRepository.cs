using Core.Commands.UserCommands;
using Core.Entities;

namespace Core.IRepositories;

public interface IUserRepository :
	IGenericRepository<User, CreateUserCommand, UpdateUserCommand, DeleteUserCommand>
{

}

/*
public interface IUserRepository
{
	Task<bool> Create(CreateUserCommand request);
	Task<bool> Update(UpdateUserCommand request);
	Task<bool> Delete(DeleteUserCommand request);
}
*/
