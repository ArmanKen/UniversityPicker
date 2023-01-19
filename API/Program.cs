using API.Extensions;
using API.Middleware;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class Program
{
	private static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddControllers();
		builder.Services.AddApplicationExtensions(builder.Configuration);
		builder.Services.AddIdentityServices(builder.Configuration);
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();
		using var scope = app.Services.CreateScope();
		var services = scope.ServiceProvider;
		try
		{
			var context = services.GetRequiredService<DataContext>();
			var userManager = services.GetRequiredService<UserManager<AppUser>>();
			await context.Database.MigrateAsync();
			await Seed.SeedData(context,userManager);
		}
		catch (Exception ex)
		{
			var logger = services.GetRequiredService<ILogger<Program>>();
			logger.LogError(ex, "An error occured during migration");
		}
		app.UseMiddleware<ExceptionMiddleware>();
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}
		app.UseCors("CorsPolicy");
		app.UseAuthorization();
		app.MapControllers();
		await app.RunAsync();
	}
}