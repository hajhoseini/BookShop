using Core.Commands.UserCommands;
using Core.IRepositories;
using MediatR;

namespace Core.Service.CommandHandlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.Update(request);
    }
}
