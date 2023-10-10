using Core.Entities;
using MediatR;

namespace Core.Queries.UserQueries;

public class GetUserQuery : IRequest<User>
{
	public Guid Guid { get; set; }
}
