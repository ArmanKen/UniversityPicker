using Application.Universities;
using Application.Core;
using Application.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastracture.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationExtensions(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddFluentValidationAutoValidation()
					.AddFluentValidationClientsideAdapters()
					.AddValidatorsFromAssemblyContaining<Create>();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
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
			services.AddScoped<IUserAccessor, UserAccessor>();
			return services;
		}
	}
}