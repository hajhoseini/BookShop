using Core.Commands.UserCommands;
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
			var result = await _unitOfWork.Users.Delete(request);
			if (result)
			{
				_unitOfWork.Complete();
			}

			return true;
		}
    }
}
