using MediatR;
using Core.IRepositories;
using Core.Commands.UserCommands;

namespace Core.Service.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
	private readonly IUserRepository UserRepository;

	public CreateUserCommandHandler(IUserRepository UserRepository)
	{
		this.UserRepository = UserRepository;
	}

	public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		return await UserRepository.Create(request);
	}
}
