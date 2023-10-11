using AutoMapper;
using Core.IRepositories;
using Infrastructure.Data.Data;

namespace Infrastructure.Data.Repositories;

public class GenericRepository<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand> : 
			IGenericRepository<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand> 
							where TEntity : class
{
	private readonly BookShopDBContext _context;
	private readonly IMapper _mapper;

	public GenericRepository(BookShopDBContext context, IMapper mapper)
    {
		_context = context;
		_mapper = mapper;
	}

    public async Task<bool> Create(TCreateCommand request)
	{
		var entity = _mapper.Map<TEntity>(request);
		await _context.Set<TEntity>().AddAsync(entity);
		_context.SaveChanges();

		return true;
	}

	public async Task<bool> Delete(TDeleteCommand request)
	{
		var guid = request.GetType().GetProperty("Guid").GetValue(request);
		var entity = await _context.Set<TEntity>().FindAsync(guid);
		if (entity == null)
		{
			return false;
		}

		_context.Set<TEntity>().Remove(entity);
		_context.SaveChanges();

		return true;
	}

	public async Task<bool> Update(TUpdateCommand request)
	{
		var guid = request.GetType().GetProperty("Guid").GetValue(request);
		var entity = await _context.Set<TEntity>().FindAsync(guid);
		if (entity == null)
		{
			return false;
		}

		entity = _mapper.Map(request, entity);
		_context.Set<TEntity>().Update(entity);
		_context.SaveChanges();

		return true;
	}
}
