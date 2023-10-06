using Core.IRepositories;
using Infrastructure.Data.Data;

namespace Infrastructure.Data.Readers;

public class GenericReader<TEntity, TGet, TGetList> : 
			IGenericReader<TEntity, TGet, TGetList> where TEntity : class
{
	private readonly BookShopDBContext _context;

	public GenericReader(BookShopDBContext context)
	{
		_context = context;
	}

	public async Task<TEntity> GetById(TGet request)
	{
		var id = request.GetType().GetProperty("Id").GetValue(request);
		return _context.Set<TEntity>().Find(id);
	}

	public async Task<List<TEntity>> GetList(TGetList request)
	{
		return _context.Set<TEntity>().ToList();
	}
}
