using MediatR;
using Core.IRepositories;
using Core.Commands.UserCommands;

namespace Core.Service.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.Create(request);
    }
}
