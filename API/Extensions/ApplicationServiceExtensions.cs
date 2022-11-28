using Application.Core;
using Application.Disciplines;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationExtensions(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<DataContext>(opt =>
			{
				opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
			});
			services.AddCors(opt =>
			{
				opt.AddPolicy("CorsPolicy", policy =>
				{
					policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
				});
			});
			services.AddMediatR(typeof(List.Handler).Assembly);
			services.AddAutoMapper(typeof(MappingProfiles).Assembly);
			return services;
		}
	}
}