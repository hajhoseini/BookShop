using MediatR;

namespace Core.Commands.UserCommands;

public class DeleteUserCommand : IRequest<bool>
{
	public Guid Guid { get; set; }
}
