using Core.Commands.UserCommands;

namespace Core.IRepositories
{
	public interface IUserRepository
	{
		Task<bool> Create(CreateUserCommand request);
		Task<bool> Update(UpdateUserCommand request);
		Task<bool> Delete(DeleteUserCommand request);
	}
}
