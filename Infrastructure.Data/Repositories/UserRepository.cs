using AutoMapper;
using Core.Commands.UserCommands;
using Core.Entities;
using Core.IRepositories;
using Infrastructure.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.IRepositories
{
	public class UserRepository : IUserRepository
	{
		private readonly BookShopDBContext context;
		private readonly IMapper mapper;

		public UserRepository(BookShopDBContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<bool> Create(CreateUserCommand request)
		{
			var User = mapper.Map<User>(request);

			await context.Users.AddAsync(User);
			await context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> Delete(DeleteUserCommand request)
		{
			var User = await context.Users.FirstOrDefaultAsync(c => c.Guid == request.Guid);
			if (User == null)
			{
				return false;
			}

			context.Users.Remove(User);
			await context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Update(UpdateUserCommand request)
		{
			var User = await context.Users.FirstOrDefaultAsync(c => c.Guid == request.Guid);
			if (User == null)
			{
				return false;
			}

			mapper.Map(request, User);
			await context.SaveChangesAsync();

			return true;
		}
	}
}
