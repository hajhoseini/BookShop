using Core.Common;

namespace Core.IRepositories;

public interface IGenericRepository<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand> 
				where TEntity : BaseEntity
{
	Task<bool> Create(TCreateCommand request);
	Task<bool> Update(TUpdateCommand request);
	Task<bool> Delete(TDeleteCommand request);
}
