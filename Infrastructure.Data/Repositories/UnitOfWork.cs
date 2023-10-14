using AutoMapper;
using Core.Commands.UserCommands;
using Core.Common;
using Core.Entities;
using Core.IRepositories;
using Infrastructure.Data.Data;
using Infrastructure.Data.Repositories;
using System.Collections;

public class UnitOfWork : IUnitOfWork
{
	private readonly BookShopDBContext _context;
	private readonly IMapper _mapper;

	public UnitOfWork(BookShopDBContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper; 

		//Users = new UserRepository(_context, mapper); 
	}

	//public IUserRepository Users { get; private set; } 

	public int Complete()
	{
		return _context.SaveChanges();
	}

	public void Dispose()
	{
		_context.Dispose();
	}

	private Hashtable _repositories;
	private static readonly Dictionary<Type, Type> dic = new Dictionary<Type, Type>
	{
		{ 
			typeof(GenericRepository<User, CreateUserCommand, UpdateUserCommand, DeleteUserCommand>), typeof(UserRepository) 
		}
	};

	public IGenericRepository<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand> genericReposity<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand>() where TEntity : BaseEntity
	{
		if (_repositories == null)
		{
			_repositories = new Hashtable();
		}

		var type = typeof(TEntity).Name;
		if (_repositories.ContainsKey(type))
		{
			return (IGenericRepository<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand>)_repositories[type];
		}

		var closedRepositoryType = typeof(GenericRepository<,,,>).MakeGenericType(typeof(TEntity), typeof(TCreateCommand), typeof(TUpdateCommand), typeof(TDeleteCommand));
		if (dic.ContainsKey(closedRepositoryType))
		{
			closedRepositoryType = dic[closedRepositoryType];
		}

		_repositories.Add(type, Activator.CreateInstance(closedRepositoryType, _context, _mapper));

		return (IGenericRepository<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand>)_repositories[type];
	}
}