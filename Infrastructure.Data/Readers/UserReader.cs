using Core.Entities;
using Core.IReaders;
using Core.Queries.UserQueries;
using Infrastructure.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Readers;

public class UserReader : IUserReader
{
	private readonly BookShopDBContext _context;

	public UserReader(BookShopDBContext context)
    {
		this._context = context;
	}

    public async Task<User> GetById(GetUserQuery request)
	{
		return await _context.Users.FirstOrDefaultAsync(c => c.Id == request.Id);
	}

	public async Task<List<User>> GetList(GetListUsersQuery request)
	{
		return await _context.Users.ToListAsync();
	}
}
