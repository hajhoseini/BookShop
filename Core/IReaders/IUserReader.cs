using Core.Entities;
using Core.Queries.UserQueries;

namespace Core.IReaders;

public interface IUserReader
{
		Task<User> GetById(GetUserQuery request);
		Task<List<User>> GetList(GetListUsersQuery request);
}
