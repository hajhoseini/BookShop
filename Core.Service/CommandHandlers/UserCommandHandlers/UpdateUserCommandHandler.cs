using Core.Commands.UserCommands;
using Core.IRepositories;
using MediatR;

namespace Core.Service.CommandHandlers
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
	{
		private readonly IUserRepository UserRepository;

		public UpdateUserCommandHandler(IUserRepository UserRepository)
		{
			this.UserRepository = UserRepository;
		}

		public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			return await UserRepository.Update(request);
		}
	}
}
