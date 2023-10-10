using Core.Entities;
using Infrastructure.Data.Data.Configs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Data;

public class BookShopDBContext : DbContext
{
	public BookShopDBContext(DbContextOptions<BookShopDBContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//روش اضافه کردن کل دایرکتوری
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
	}


	public DbSet<User> Users { get; set; }
}
