using AutoMapper;
using Core.Commands.UserCommands;
using Core.IRepositories;
using Core.Entities;	 
using Infrastructure.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
	private readonly BookShopDBContext _context;
	private readonly IMapper _mapper;

	public UserRepository(BookShopDBContext context, IMapper mapper)
	{
		this._context = context;
		this._mapper = mapper;
	}

	public async Task<bool> Create(CreateUserCommand request)
	{
		var user = _mapper.Map<User>(request);

		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Delete(DeleteUserCommand request)
	{
		var User = await _context.Users.FirstOrDefaultAsync(c => c.Id == request.Id);
		if (User == null)
		{
			return false;
		}

		_context.Users.Remove(User);
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> Update(UpdateUserCommand request)
	{
		var User = await _context.Users.FirstOrDefaultAsync(c => c.Id == request.Id);
		if (User == null)
		{
			return false;
		}

		_mapper.Map(request, User);
		await _context.SaveChangesAsync();

		return true;
	}
}
