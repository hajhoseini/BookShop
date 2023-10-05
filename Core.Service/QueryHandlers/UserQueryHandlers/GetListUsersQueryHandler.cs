using Core.Entities;
using Core.IReaders;
using Core.Queries.UserQueries;
using MediatR;

namespace Core.Service.QueryHandlers
{
    public class GetListUsersQueryHandler : IRequestHandler<GetListUsersQuery, List<User>>
    {
        private readonly IUserReader _userReader;

        public GetListUsersQueryHandler(IUserReader userReader)
        {            
            this._userReader = userReader;
        }

        public async Task<List<User>> Handle(GetListUsersQuery request, CancellationToken cancellationToken)
        {            
            return await _userReader.GetList(request);
        }
    }
}
