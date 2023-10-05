using Core.Entities;
using Core.IReaders;
using Core.Queries.UserQueries;
using MediatR;

namespace Core.Service.QueryHandlers
{
	public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
	{
		private readonly IUserReader _userReader;

		public GetUserQueryHandler(IUserReader userReader)
		{
			this._userReader = userReader;
		}

		public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			return await _userReader.GetById(request);
		}
	}
}
