using Core.Entities;

namespace Core.IRepositories;

public interface IGenericReader<TEntity, TGet, TGetList> where TEntity : class
{
	Task<TEntity> GetById(TGet request);
	Task<List<TEntity>> GetList(TGetList request);
}
