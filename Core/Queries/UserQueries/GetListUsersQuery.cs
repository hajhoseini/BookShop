using Core.Entities;
using MediatR;

namespace Core.Queries.UserQueries;

public class GetListUsersQuery : IRequest<List<User>>
{
}
