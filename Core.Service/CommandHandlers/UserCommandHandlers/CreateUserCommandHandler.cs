﻿using MediatR;
using Core.IRepositories;
using Core.Commands.UserCommands;

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
        return await _unitOfWork.Users.Create(request);
    }
}
