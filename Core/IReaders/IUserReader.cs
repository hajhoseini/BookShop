using Core.Entities;
using Core.IRepositories;
using Core.Queries.UserQueries;

namespace Core.IReaders;

public interface IUserReader : IGenericReader<User, GetUserQuery, GetListUsersQuery>
{

}

/*
public interface IUserReader
{
	Task<User> GetById(GetUserQuery request);
	Task<List<User>> GetList(GetListUsersQuery request);
}
*/