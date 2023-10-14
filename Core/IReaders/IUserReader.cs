using Core.Entities;
using Core.Queries.UserQueries;

namespace Core.IReaders
{
	public interface IUserReader
	{
		Task<List<User>> GetList(GetListUsersQuery request);
		Task<User> GetById(GetUserQuery request);
	}
}
