using Core.Commands.UserCommands;
using Core.Entities;
using Core.IRepositories;
using MediatR;

namespace Core.Service.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.genericReposity<User, CreateUserCommand, UpdateUserCommand, DeleteUserCommand>().Delete(request);
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
}
