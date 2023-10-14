using Core.Commands.UserCommands;
using Core.Entities;
using Core.IRepositories;
using MediatR;

namespace Core.Service.CommandHandlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.genericReposity<User, CreateUserCommand, UpdateUserCommand, DeleteUserCommand>().Update(request);
        if (result)
        {
            _unitOfWork.Complete();
        }
		else
		{
			_unitOfWork.Dispose();
		}

		return true;
    }
}
