using MediatR;

namespace Core.Commands.UserCommands;

public class DeleteUserCommand : IRequest<bool>
{
	public int Id { get; set; }
}
