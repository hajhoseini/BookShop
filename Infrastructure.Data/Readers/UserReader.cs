using Core.Entities;
using Core.IReaders;
using Core.Queries.UserQueries;
using Infrastructure.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Readers
{
	public class UserReader : IUserReader
	{
		private readonly BookShopDBContext context;

		public UserReader(BookShopDBContext context)
		{
			this.context = context;
		}

		public async Task<List<User>> GetList(GetListUsersQuery request)
		{
			return await context.Users.ToListAsync();
		}

		public async Task<User> GetById(GetUserQuery request)
		{
			return await context.Users.FirstOrDefaultAsync(x => x.Guid == request.Guid);
		}
	}
}
