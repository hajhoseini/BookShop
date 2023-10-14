using MediatR;
using Core.IRepositories;
using Core.Commands.UserCommands;
using Core.Entities;

namespace Core.Service.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateUserCommandHandler(IUnitOfWork unitOfWork)
	{
		this._unitOfWork = unitOfWork;
	}

	public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var result = await _unitOfWork.genericReposity<User, CreateUserCommand, UpdateUserCommand, DeleteUserCommand>().Create(request);
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
