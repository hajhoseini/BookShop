using Core.Entities;
using MediatR;

namespace Core.Queries.UserQueries;

public class GetUserQuery : IRequest<User>
{
	public int Id { get; set; }
}
