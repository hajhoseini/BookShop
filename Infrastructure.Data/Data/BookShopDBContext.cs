using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Data;

public class BookShopDBContext : DbContext
{
	public BookShopDBContext(DbContextOptions<BookShopDBContext> options) : base(options)
	{
	}
}
