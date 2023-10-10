using Core.Commands.UserCommands;
using Core.IRepositories;
using MediatR;

namespace Core.Service.CommandHandlers
{
	public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
	{
		private readonly IUserRepository UserRepository;

		public DeleteUserCommandHandler(IUserRepository UserRepository)
		{
			this.UserRepository = UserRepository;
		}

		public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			return await UserRepository.Delete(request);
		}
	}
}
