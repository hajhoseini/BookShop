using AutoMapper;
using Core.IRepositories;
using Infrastructure.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly BookShopDBContext _context;

		public UnitOfWork(BookShopDBContext context, IMapper mapper)
		{
			_context = context;
			Users = new UserRepository(_context, mapper);
		}

		public IUserRepository Users { get; private set; }
		
		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
