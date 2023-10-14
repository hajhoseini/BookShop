using Core.Common;

namespace Core.IRepositories;

public interface IUnitOfWork : IDisposable
{
	//IUserRepository Users { get; }
	IGenericRepository<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand> genericReposity<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand>() where TEntity : BaseEntity;

	int Complete();
}
