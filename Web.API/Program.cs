using Core.IReaders;
using Core.IRepositories;
using Core.Service.CommandHandlers;
using Infrastructure.Data.Data;
using Infrastructure.Data.Readers;
using Infrastructure.Data.Repositories;
using Infrastructure.MapperProfiles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Web.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<BookShopDBContext>(options =>
						options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);

			builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

			builder.Services.AddControllers();

			// Add services to the container.
			//builder.Services.AddAuthorization();

			builder.Services.AddScoped<IUserReader, UserReader>();
			//builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			//app.UseAuthorization();

			app.MapControllers();
			app.UseRouting();

			app.Run();
		}
	}
}