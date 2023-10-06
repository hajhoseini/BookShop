using Core.IReaders;

namespace Core.IRepositories;

public interface IUnitOfWork : IDisposable
{
	IUserRepository Users { get; }	

	int Complete();
}
